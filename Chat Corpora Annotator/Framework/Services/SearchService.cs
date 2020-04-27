﻿using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using Lucene.Net.Queries;

namespace Viewer.Framework.Services
{
	public interface ISearchService
	{
		
		Query UserQuery { get; set; }
		FieldCacheTermsFilter UserFilter { get; set; }

		TopDocs Hits { get; set; }
		void ConstructUserFilter(string senderFieldKey, string[] users);
		void ConstructDateFilter(string dateFieldKey, DateTime start, DateTime finish);
		void SearchText(int count);
		void SearchText_UserFilter(int count);
		void SearchText_DateFilter(int count);
		void SearchText_UserDateFilter(int count);
		void SearchText_WindowFilter();

		List<DynamicMessage> MakeSearchResultsReadable(List<string> selectedFields, string dateFieldKey);
		
	}



	public class SearchService : ISearchService

	{
		public TopDocs Hits { get; set; }
		public Query UserQuery { get; set; }
		public FieldCacheTermsFilter UserFilter { get; set; }

		public FieldCacheRangeFilter<string> DateFilter { get; set; }

		public void ConstructDateFilter(string dateFieldKey, DateTime start, DateTime finish)
		{
			var startString = DateTools.DateToString(start, DateTools.Resolution.MILLISECOND);
			var finishString = DateTools.DateToString(finish, DateTools.Resolution.MILLISECOND);
			DateFilter = FieldCacheRangeFilter.NewStringRange(dateFieldKey,
				 lowerVal: startString, includeLower: true,
				 upperVal: finishString, includeUpper: true);
		}

		public void ConstructUserFilter(string senderFieldKey, string[] users) { UserFilter = new FieldCacheTermsFilter(senderFieldKey, users); }

		public List<DynamicMessage> MakeSearchResultsReadable(List<string> selectedFields, string dateFieldKey)
		{
			List<DynamicMessage> searchResults = new List<DynamicMessage>();
			for (int i = 0; i < Hits.TotalHits; i++)
			{
				List<string> data = new List<string>();
				ScoreDoc d = Hits.ScoreDocs[i];
				Document idoc = LuceneService.Searcher.Doc(d.Doc);
				foreach (var field in selectedFields)
				{
					data.Add(idoc.GetField(field).GetStringValue());
				}
				DynamicMessage message = new DynamicMessage(data, selectedFields, dateFieldKey);
				searchResults.Add(message);
			}
			return searchResults;
		}

		public void SearchText(int count)
		{
			
			if (UserQuery != null)
			{

				Hits = LuceneService.Searcher.Search(UserQuery, count);
				
			}

		}

		public void SearchText_DateFilter(int count)
		{
			if (UserQuery!= null)
			{
				if (DateFilter != null)
				{
					Hits = LuceneService.Searcher.Search(UserQuery, DateFilter, count);
				}
			}
		}

		public void SearchText_UserDateFilter(int count)
		{
			if (UserQuery != null)
			{
				if (DateFilter != null)
				{
					if (UserFilter != null)

					{
						var filter = new BooleanFilter();
						filter.Add(new FilterClause(DateFilter, Occur.MUST));
						filter.Add(new FilterClause(UserFilter, Occur.MUST));
						Hits = LuceneService.Searcher.Search(UserQuery, filter, count);
					}
				}
			}
		}

		public void SearchText_UserFilter(int count)
		{
			
			if (UserQuery != null)
			{
				if (UserFilter != null)
				{
					Hits = LuceneService.Searcher.Search(UserQuery, UserFilter, count);
					
				}
			}
			
		}

		public void SearchText_WindowFilter()
		{
			throw new NotImplementedException();
		}
	}
}
