using IndexEngine;
using IndexEngine.Paths;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public class DatasetStatisticsService : IStatisticsService
    {

        public int NumberOfDocs { get; private set; }
        public long NumberOfSymbols { get; private set; }
        public ulong NumberOfTokens { get; private set; }
        public int NumberOfUsers { get; private set; }
        public double AverageLength { get; private set; }
        public double AverageMessagesPerUnit { get; private set; }
        public List<int> AllLengths { get; private set; } = new List<int>();

        public List<int> AllTokenNumbers { get; private set; } = new List<int>();

        public List<int> AllTokenLengths { get; private set; } = new List<int>();

        public bool IsCalculated { get; private set; } = false;

        public TimeSpan Duration { get; private set; }

        public Dictionary<string, double> AllFields { get; private set; } = new Dictionary<string, double>();

        private void SetDuration()
        {

            var test = LuceneService.DirReader.Document(LuceneService.DirReader.MaxDoc - 1).GetField(ProjectInfo.DateFieldKey).GetStringValue();
            var end = DateTools.StringToDate(test);
            var start = DateTools.StringToDate(LuceneService.DirReader.Document(0).GetField(ProjectInfo.DateFieldKey).GetStringValue());

            Duration = end - start;
            AllFields.Add("Duration in days", Math.Ceiling(Duration.TotalDays));

        }
        private void SetMessageNumber()
        {
            this.NumberOfDocs = LuceneService.DirReader.NumDocs;
            AllFields.Add("Number of messages", this.NumberOfDocs);
        }
        private void SetUserNumber()
        {
            this.NumberOfUsers = ProjectInfo.Data.UserKeys.Count;
            AllFields.Add("Number of users", this.NumberOfUsers);
        }

        private void SetLengthData()
        {
            long length = 0;
            for (int i = 0; i < this.NumberOfDocs; i++)
            {
                var temp = LuceneService.DirReader.Document(i).GetField(ProjectInfo.TextFieldKey).GetStringValue().Length;
                length += temp;
                AllLengths.Add(temp);
            }

            this.NumberOfSymbols = length;
            AllFields.Add("Number of symbols in corpus", this.NumberOfSymbols);
        }
        private void SetAvgLength()
        {

            this.AverageLength = (double)this.NumberOfSymbols / (double)this.NumberOfDocs;
            AllFields.Add("Average length of a message", this.AverageLength);
        }
        private void SetAverageMessagesPerDay()
        {
            this.AverageMessagesPerUnit = (double)this.NumberOfDocs / (double)ProjectInfo.Data.MessagesPerDay.Keys.Count;
            AllFields.Add("Average number of messages per day", this.AverageMessagesPerUnit);
        }

        private void SetTokenNumber()
        {
            CollectionStatistics stat = LuceneService.Searcher.CollectionStatistics(ProjectInfo.TextFieldKey);
            this.NumberOfTokens = (ulong)stat.SumTotalTermFreq;
            for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
            {
                LuceneService.GetTokenDataForDoc(LuceneService.DirReader.Document(i).GetField(ProjectInfo.TextFieldKey).GetStringValue());
            }
            AllFields.Add("Tokens", this.NumberOfTokens);

        }

        public void CalculateAll()
        {
            if (!IsCalculated)
            {
                SetDuration();
                SetMessageNumber();
                SetUserNumber();
                SetLengthData();
                SetAvgLength();
                SetAverageMessagesPerDay();
                SetTokenNumber();

                IsCalculated = true;
            }

        }
    }
}
