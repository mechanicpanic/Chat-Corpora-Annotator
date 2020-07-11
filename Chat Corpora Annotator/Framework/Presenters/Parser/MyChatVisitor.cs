using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using de.jollyday.util;
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
            var rGroups = new List<List<int>>();
            foreach (var rGroup in context.restriction_group())
            {
                rGroups.Add((List<int>)VisitRestriction_group(rGroup));
            }

            return rGroups;
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
                int msgCount = 10000;
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
            else
            {
                // Message about incorrect query
                return null;
            }
            
        }

        private List<int> MergeRestrictions(List<List<int>> rList, int windowSize)
        {
            int _size = rList.Count;
            if (_size == 1)
            {
                return rList[0];
            }

            List<int> result = new List<int>();

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
                    result.AddRange(curMsgs);
                }
            }

            return result;
        }
    }
}
