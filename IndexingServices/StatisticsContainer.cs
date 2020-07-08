using IndexEngine;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine
{
    public class StatisticsContainer
    {
        public int NumberOfDocs { get; private set; }
        public long NumberOfSymbols { get; private set; }
        public ulong NumberOfTokens { get; private set; }
        public int NumberOfUsers { get; private set; }
        public double AverageLength { get; private set; }
        public double AverageMessagesPerDay { get; private set; }
        public List<int> AllLengths { get; private set; }
        public StatisticsContainer()
        {
            SetMessageNumber();
            SetUserNumber();
            SetLengthData();

            SetAvgLength();
            SetAverageMessagesPerDay();
            SetTokenNumber();
        }


        private void SetMessageNumber()
        {
            this.NumberOfDocs =  LuceneService.DirReader.NumDocs;
        }
        private void  SetUserNumber()
        {
            this.NumberOfUsers = IndexService.UserKeys.Count;
        }

        private void SetLengthData()
        {
            List<int> lengths = new List<int>();
            long length = 0;
            for (int i = 0; i < this.NumberOfDocs; i++)
            {
                var temp = LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue().Length;
                length += temp;
                lengths.Add(temp);
            }

            this.NumberOfSymbols = length;
            this.AllLengths = lengths;
        }
        private void SetAvgLength()
        {

            this.AverageLength = (double) this.NumberOfSymbols / (double)this.NumberOfDocs;
        }
        private void SetAverageMessagesPerDay()
        {
            this.AverageMessagesPerDay = (double)IndexService.MessagesPerDay.Keys.Count / (double)this.NumberOfDocs;
        }

        private void SetTokenNumber() {
            CollectionStatistics stat = LuceneService.Searcher.CollectionStatistics(IndexService.TextFieldKey);
            this.NumberOfTokens = (ulong)stat.SumTotalTermFreq;

            
        }
        private int GetQuestionNumber() { return 0; }
        private int GetNounPhraseNumber() { return 0; }
    }
}
