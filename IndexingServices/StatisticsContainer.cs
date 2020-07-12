using IndexEngine;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.TokenAttributes;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<int> AllTokenNumbers { get; private set; }

        public List<int> AllTokenLengths { get; private set; }
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

            this.AllTokenNumbers = new List<int>();
            this.AllTokenLengths = new List<int>();
            for (int i = 0; i < LuceneService.DirReader.MaxDoc; i++)
            {
                GetTokenDataForDoc(LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue());
            }


        }



        private void GetTokenDataForDoc(string document)
        {
            TokenStream stream = LuceneService.Analyzer.GetTokenStream(IndexService.TextFieldKey, new StringReader(document));
            var index = 0;
            var charTermAttribute = stream.AddAttribute<ICharTermAttribute>();
            stream.Reset();

            while (stream.IncrementToken())
            {
                //Token token = new Token();
                //int startOffset = offsetAttribute.StartOffset;
                //int endOffset = offsetAttribute.EndOffset;
                String term = charTermAttribute.ToString();
                index++;
                AllTokenLengths.Add(term.Length);

            }
            AllTokenNumbers.Add(index);
            stream.ClearAttributes();
            stream.End();
            stream.Dispose();
            
        }

        
        private int GetQuestionNumber() { return 0; }
        private int GetNounPhraseNumber() { return 0; }
    }
}
