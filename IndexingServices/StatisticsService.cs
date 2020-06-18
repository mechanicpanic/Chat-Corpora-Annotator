using IndexEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine
{
    public static class StatisticsService
    {
        public static int GetMessageNumber()
        {
            return LuceneService.DirReader.NumDocs;
        }
        public static int GetUserNumber()
        {
            return IndexService.UserKeys.Count;
        }

        public static double GetAvgLength()
        {
            long length = 0;
            for(int i = 0; i < GetMessageNumber(); i++)
            {
                length += LuceneService.DirReader.Document(i).GetField(IndexService.TextFieldKey).GetStringValue().Length;
            }
            double result = length / (double)GetMessageNumber();
            return result;
        }
        public static double GetAverageMessagesPerDay()
        {
            double result = (double)IndexService.MessagesPerDay.Keys.Count / (double)GetMessageNumber();
            return result;
        }

        public static int GetTokenNumber() {
            return 0;
            
        }
        public static int GetQuestionNumber() { return 0; }
        public static int GetNounPhraseNumber() { return 0; }
    }
}
