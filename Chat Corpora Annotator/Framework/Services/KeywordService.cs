using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexingServices;

namespace Viewer.Framework.Services
{
    public interface IKeywordService
    {
        Dictionary<string, double> GetRakeKeywords();
        void FlushKeywordsToDisk();
        List<string> ProcessKeywordList(List<string> keywords);
    }
    public class KeywordService: IKeywordService
    {
        public void FlushKeywordsToDisk()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, double> GetRakeKeywords()
        {
            Rake generator = new Rake();

            return generator.Run(this.BuildBigString(this.GetList()));
        }

        private string BuildBigString(List<string> list)
        {
            StringBuilder str = new StringBuilder();
            foreach(var item in list)
            {
                str.Append(item);
            }
            return str.ToString();
        }
        private List<string> GetList()
        {
            List<string> sents = new List<string>();
            for(int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
            {
                var document = LuceneService.DirReader.Document(i);
                sents.Add(document.GetField(IndexService.TextFieldKey).GetStringValue());
            }
            return sents;
            
        }
        public List<string> ProcessKeywordList(List<string> keywords)
        {
            keywords.RemoveAll(x => x.Contains("http"));
            keywords.RemoveAll(x => x.Contains("/"));
            keywords.RemoveAll(x => x.Contains("www"));
            keywords.RemoveAll(x => x.Contains(".com"));
            keywords.RemoveAll(x => x.Contains(".com"));
            keywords.RemoveAll(x => x.Contains("="));
            keywords.RemoveAll(x => x.Contains("&"));
            keywords.RemoveAll(x => x.Contains("#"));
            keywords.RemoveAll(x => x.Contains("?"));
            keywords.RemoveAll(x => x.Contains("%"));
            keywords.RemoveAll(x => x.Contains("@"));
            keywords.RemoveAll(x => x.Contains("+"));
            keywords.RemoveAll(x => x.Contains(")"));
            keywords.RemoveAll(x => x.Contains("("));
            keywords.RemoveAll(x => x.Contains("^"));
            keywords.RemoveAll(x => x.Contains("<"));
            keywords.RemoveAll(x => x.Contains(">"));
            keywords.RemoveAll(x => x.Contains("`"));
            keywords.RemoveAll(x => x.Contains("\\"));
            keywords.RemoveAll(x => x.Contains("*"));
            keywords.RemoveAll(x => x.Contains("["));
            keywords.RemoveAll(x => x.Contains("]"));
            keywords.RemoveAll(x => x.Contains("$"));
            keywords.RemoveAll(x => x.Contains("."));
            keywords.RemoveAll(x => x.Contains("!"));
            keywords.RemoveAll(x => x.Contains(","));
            return keywords;
        }
    }
}
