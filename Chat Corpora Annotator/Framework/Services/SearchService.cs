using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
	public interface ISearchService
	{
		
		Query UserQuery { get; set; }
		FieldCacheTermsFilter UserFilter { get; set; }
		List<DynamicMessage> SearchText(string query);
		List<DynamicMessage> SearchText_UserFilter(string query, string[] users);
		List<DynamicMessage> SearchText_DateFilter(string query, string start, string finish);
	}



	public class SearchService : ISearchService

	{
		public Query UserQuery { get; set; }
		public FieldCacheTermsFilter UserFilter { get; set; }
		public List<DynamicMessage> SearchText(string query)
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
