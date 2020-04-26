using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
	public interface ISearchService
	{
		
		Query UserQuery { get; set; }
		FieldCacheTermsFilter UserFilter { get; set; }
		List<DynamicMessage> SearchText(int count);
		List<DynamicMessage> SearchText_UserFilter(int count,string[] users);
		List<DynamicMessage> SearchText_DateFilter(int count, string start, string finish);

		List<DynamicMessage> SearchText_WindowFilter();
	}



	public class SearchService : ISearchService

	{
		public Query UserQuery { get; set; }
		public FieldCacheTermsFilter UserFilter { get; set; }
		public List<DynamicMessage> SearchText(int count)
		{
			if (UserQuery != null)
			{
				TopDocs temp = LuceneService.Searcher.Search(UserQuery, count);
				
			}
		}

		public List<DynamicMessage> SearchText_DateFilter(string start, string finish)
		{
			throw new NotImplementedException();
		}

		public List<DynamicMessage> SearchText_UserFilter(string[] users)
		{
			throw new NotImplementedException();
		}

		public List<DynamicMessage> SearchText_WindowFilter()
		{
			throw new NotImplementedException();
		}
	}
}
