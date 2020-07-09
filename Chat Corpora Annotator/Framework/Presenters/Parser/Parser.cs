using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace Viewer.Framework.Presenters.Parser
{
    class Parser
    {
        public static void parse(string query) 
        { 
            StringBuilder text = new StringBuilder(query);

            AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
            ChatLexer speakLexer = new ChatLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
            ChatParser speakParser = new ChatParser(commonTokenStream);

            var tree = speakParser.query();

            var visitor = new MyChatVisitor();
            var rlist = visitor.Visit(tree);

            /*foreach (Restriction r in rlist)
            {
                string cur = r.restrictionText;
                Console.WriteLine(cur);
            }*/
        }
    }
}
