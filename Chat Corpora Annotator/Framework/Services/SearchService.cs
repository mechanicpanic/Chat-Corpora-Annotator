using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator.Framework.Services
{
    public interface ISearchService
    {

        List<DynamicMessage> SearchText(string query, QueryParser parser, IndexSearcher searcher);
        List<DynamicMessage> SearchText_UserFilter(string query, string[] users);
        List<DynamicMessage> SearchText_DateFilter(string query, string start, string finish);
    }



    public class SearchService : ISearchService
    {

        public List<DynamicMessage> SearchText(string query, QueryParser parser, IndexSearcher searcher)
        {
            throw new NotImplementedException();
        }

        public List<DynamicMessage> SearchText_DateFilter(string query, string start, string finish)
        {
            throw new NotImplementedException();
        }

        public List<DynamicMessage> SearchText_UserFilter(string query, string[] users)
        {
            throw new NotImplementedException();
        }
    }
}
