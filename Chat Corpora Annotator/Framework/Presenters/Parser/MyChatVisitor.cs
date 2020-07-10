using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Retrievers;
using Viewer.UI;

namespace Viewer.Framework.Presenters.Parser
{
    public class MyChatVisitor : ChatBaseVisitor<object>
    {
        private List<List<int>> restrictions = new List<List<int>>();
        public Dictionary<string, List<string>> dicts;

        public override object VisitQuery([NotNull] ChatParser.QueryContext context)
        {
            return VisitBody(context.body());
        }

        public override object VisitBody([NotNull] ChatParser.BodyContext context)
        {
            //foreach (var r in context.restriction_expr())
            //{
            //    restrictions.Add((List<int>)VisitRestriction_expr(r));
            //}

            return (List<int>)VisitRestriction_expr(context.restriction_expr(0));
        }

        public override object VisitRestriction_expr([NotNull] ChatParser.Restriction_exprContext context)
        {
            if (context.InWin() != null)
            {
                return null;
            }
            else
            {
                return VisitRestriction(context.restriction());
            }
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
                return null;
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
                return Retrievers.Retrievers.HasWordOfList(dicts[dictname]);
            }

            return null;
        }
    }

}
