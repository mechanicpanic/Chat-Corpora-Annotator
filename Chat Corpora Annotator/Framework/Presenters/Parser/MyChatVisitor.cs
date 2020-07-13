using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using de.jollyday.util;
using IndexEngine;
using javax.xml.transform;
using org.omg.CORBA;
using Retrievers;
using Viewer.UI;

namespace Viewer.Framework.Presenters.Parser
{
    public class MyChatVisitor : ChatBaseVisitor<object>
    {
        public override object VisitQuery([NotNull] ChatParser.QueryContext context)
        {
            return VisitBody(context.body());
        }

        public override object VisitBody([NotNull] ChatParser.BodyContext context)
        {
            var rGroups = new List<List<List<int>>>();

            foreach (var rGroup in context.restriction_group())
            {
                rGroups.Add((List<List<int>>)VisitRestriction_group(rGroup));
            }

            return MergeRestrictionGroups(rGroups);
        }

        public override object VisitRestriction_group([NotNull] ChatParser.Restriction_groupContext context)
        {
            // Default window size is 50
            int windowSize = 50;

            if (context.InWin() != null)
            {
                windowSize = Int32.Parse(context.number().GetText());
            }

            var rList = (List<List<int>>)VisitRestrictions(context.restrictions());
            return MergeRestrictions(rList, windowSize);
        }

        public override object VisitRestrictions([NotNull] ChatParser.RestrictionsContext context)
        {
            var rList = new List<List<int>>();

            foreach (var r in context.restriction())
            {
                rList.Add((List<int>)VisitRestriction(r));
            }

            return rList;
        }

        public override object VisitRestriction([NotNull] ChatParser.RestrictionContext context)
        {
            if (context.And() != null)
            {
                List<int> lhs = (List<int>)VisitRestriction(context.restriction(0));
                List<int> rhs = (List<int>)VisitRestriction(context.restriction(1));

                return lhs.Intersect(rhs).ToList();
            }
            else if (context.Or() != null)
            {
                List<int> lhs = (List<int>)VisitRestriction(context.restriction(0));
                List<int> rhs = (List<int>)VisitRestriction(context.restriction(1));
                lhs.AddRange(rhs);
                lhs.Sort();

                return lhs;
            } 
            else if (context.Not() != null)
            {
                long tmp = LuceneService.DirReader.MaxDoc - 1;
                int msgCount = 1000000;
                if (msgCount > tmp)
                {
                    msgCount = (int)tmp;
                }

                var numberList = Enumerable.Range(1, msgCount).ToList();
                var excludeList = (List<int>)VisitRestriction(context.restriction(0));

                return numberList.Except(excludeList).ToList();
            } 
            else if (context.condition() != null)
            {
                return VisitCondition(context.condition());
            } 
            else
            {
                return VisitRestriction(context.restriction(0));
            }
        }

        public override object VisitCondition([NotNull] ChatParser.ConditionContext context)
        {
            if (context.HasUserMentioned() != null)
            {
                string username = context.huser().GetText();
                return Retrievers.Retrievers.HasUserMentioned(username);
            }
            else if (context.ByUser() != null)
            {
                string username = context.huser().GetText();
                return Retrievers.Retrievers.HasUser(username);
            }
            else if (context.HasLocation() != null)
            {
                return Retrievers.Retrievers.HasNERTag(NER.LOC);
            }
            else if (context.HasOrganization() != null)
            {
                return Retrievers.Retrievers.HasNERTag(NER.ORG);
            }
            else if (context.HasTime() != null)
            {
                return Retrievers.Retrievers.HasNERTag(NER.TIME);
            }
            else if (context.HasURL() != null)
            {
                return Retrievers.Retrievers.HasNERTag(NER.URL);
            }
            else if (context.HasQuestion() != null)
            {
                return Retrievers.Retrievers.HasQuestion();
            }
            else if (context.HasWordOfDict() != null)
            {
                string dictname = context.hdict().GetText();
                return Retrievers.Retrievers.HasWordOfList(UserDictsContainer.UserDicts[dictname]);
            }
            else if (context.HasDate() != null)
            {
                return Retrievers.Retrievers.HasNERTag(NER.DATE);
            }
            else
            {
                // Message about incorrect query
                return null;
            }
            
        }

        private List<List<int>> MergeRestrictions(List<List<int>> rList, int windowSize)
        {
            int _size = rList.Count;
            if (_size == 1)
            {
                return rList;
            }

            var result = new List<List<int>>();

            for (int fstInd = 0; fstInd < rList[0].Count; fstInd++)
            {
                int curPos = rList[0][fstInd];
                int fstPos = rList[0][fstInd];
                List<int> curMsgs = new List<int> { curPos };
                for (int i = 1; i < _size; i++)
                {
                    foreach (var _id in rList[i])
                    {
                        if (_id <= curPos)
                        {
                            continue;
                        }

                        if (_id - fstPos <= windowSize)
                        {
                            curMsgs.Add(_id);
                            curPos = _id;
                            break;
                        }
                    }
                }

                if (curMsgs.Count == _size)
                {
                    result.Add(curMsgs);
                }
            }

            return result;
        }


        // Merge some restriction groups to query answer
        // For example, we have 3 group X, Y, Z:
        // select qX1,...,qXk inwin n1, qY1,...,qYs inwin n2, qZ1...qZm inwin n3
        // Suppose, that answer for separate groups is: [X1, X2] [Y1, Y2, Y3] [Z1, Z2]
        // Result of MergeRestrictionGroups([[X1, X2] [Y1, Y2, Y3] [Z1, Z2]]) is:
        // [X1, Y1, Z1]
        // [X1, Y1, Z2]
        // [X1, Y2, Z1]
        // [X1, Y2, Z2]
        // ............
        // [X2, Y3, Z2]
        private List<List<List<int>>> MergeRestrictionGroups(List<List<List<int>>> rList)
        {
            var resultList = new List<List<List<int>>>();
            int _size = resultList.Count();

            List<int> curIndex = new List<int>();

            for (int i = 0; i < _size; i++)
            {
                curIndex.Add(0);
            }

            while (true)
            {
                bool can_end = true;
                
                var curAccomodation = new List<List<int>>();
                for (int i = 0; i < _size; i++)
                {
                    var elem = rList[i][curIndex[i]];
                    curAccomodation.Add(elem);
                }

                resultList.Add(curAccomodation);

                for (int i = _size - 1; i >= 0; i--)
                {
                    if (curIndex[i] < rList[i].Count())
                    {
                        can_end = false;
                        curIndex[i]++;
                        for (int j = i + 1; j < _size; j++)
                        {
                            curIndex[j] = 0;
                        }
                    }
                }

                if (can_end)
                {
                    break;
                }
            }

            return resultList;
        }
    }
}
