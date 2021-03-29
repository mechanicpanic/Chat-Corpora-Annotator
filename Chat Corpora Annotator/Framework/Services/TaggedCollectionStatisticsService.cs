using IndexEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Viewer.Framework.Services
{
    public class TaggedCollectionStatisticsService : ITaggedStatisticsService
    {
        public int WindowCount { get; private set; }

        public int AverageUsersPerSituation { get; private set; }
        public Dictionary<string, int> AverageUsersInSituationPerTag { get; private set; } = new Dictionary<string, int>();

        public Dictionary<string, int> SituationsPerTag { get; private set; } = new Dictionary<string, int>();

        public int NumberOfDocs { get; private set; }

        public long NumberOfSymbols { get; private set; }

        public ulong NumberOfTokens { get; private set; }

        public int NumberOfUsers { get; private set; }

        public double AverageLength { get; private set; }

        public double AverageMessagesPerUnit { get; private set; }

        public List<int> AllLengths => throw new NotImplementedException();

        public List<int> AllTokenNumbers => throw new NotImplementedException();

        public List<int> AllTokenLengths => throw new NotImplementedException();

        public Dictionary<string, double> AllFields { get; private set; } = new Dictionary<string, double>();

        public bool IsCalculated { get; private set; }

        public TimeSpan Duration { get; private set; }

        public int AverageWindowLength { get; private set; }

        public int IntertwinedCount { get; private set; }

        private HashSet<Tuple<int, int>> intervals = new HashSet<Tuple<int, int>>();
        private HashSet<Tuple<Tuple<int, int>, Tuple<int, int>>> mem = new HashSet<Tuple<Tuple<int, int>, Tuple<int, int>>>();

        public void CalculateAll()
        {
            AllFields.Clear();
            SetSimpleCounts();
            CountIntertwined();
            IsCalculated = true;

        }
        private void SetSimpleCounts()
        {
            int prev = 0; //prev id
            List<int> windows = new List<int>(); // all windows lengths;
            int count = 0; //all messages in all situations
            int symcount = 0; //all symbols in all situations
            int sitcount = SituationIndex.SituationCount(); //the number of all situations

            HashSet<string> usersInSituation = new HashSet<string>(); //counts all unique users in a situation
            Dictionary<string, int> userPerSituationPerTagCounts = new Dictionary<string, int>(); //the sum of unique users in each tag

            foreach (var kvp in SituationIndex.TagsetCounter)
            {
                userPerSituationPerTagCounts.Add(kvp.Key, 0);
                this.AverageUsersInSituationPerTag.Add(kvp.Key, 0);
            }

            foreach (var kvp in SituationIndex.Index)
            {
                count += kvp.Value.Values.Count;
                foreach (var dict in kvp.Value)
                {
                    prev = dict.Value[0];
                    foreach (var index in dict.Value)
                    {
                        if (index - prev > 1)
                        {
                            count++;
                            windows.Add(index - prev);
                        }
                        prev = index;
                        symcount += LuceneService.DirReader.Document(index).GetField(IndexService.TextFieldKey).GetStringValue().Length;
                        usersInSituation.Add(LuceneService.DirReader.Document(index).GetField(IndexService.SenderFieldKey).GetStringValue());
                    }

                    userPerSituationPerTagCounts[kvp.Key] += usersInSituation.Count;
                    usersInSituation.Clear();
                }
            }
            this.NumberOfDocs = count;
            this.AverageMessagesPerUnit = count / sitcount;
            this.NumberOfSymbols = symcount;
            this.AverageLength = symcount / count;
            this.AverageWindowLength = windows.Sum() / windows.Count;
            this.AverageUsersPerSituation = userPerSituationPerTagCounts.Values.Sum() / sitcount;
            foreach (var kvp in userPerSituationPerTagCounts)
            {
                this.AverageUsersInSituationPerTag[kvp.Key] = kvp.Value / SituationIndex.Index[kvp.Key].Count;
                this.SituationsPerTag.Add(kvp.Key, SituationIndex.Index[kvp.Key].Count);
                this.AllFields.Add("Average number of users in " + kvp.Key, AverageUsersInSituationPerTag[kvp.Key]);
                this.AllFields.Add(kvp.Key, SituationIndex.Index[kvp.Key].Count);

            }

            this.AllFields.Add("Number of tagged messages", this.NumberOfDocs);
            this.AllFields.Add("Number of symbols", this.NumberOfSymbols);
            this.AllFields.Add("Average number of messages per situation", this.AverageUsersPerSituation);
            this.AllFields.Add("Average length of a tagged message", AverageLength);
            this.AllFields.Add("Average window length", AverageWindowLength);
            this.AllFields.Add("Number of windows", windows.Count);

        }
        private void CountIntertwined()
        {
            int count = 0;
            if (!IsCalculated)
            {

                Tuple<int, int> tuple;
                foreach (var kvp in SituationIndex.Index)
                {
                    foreach (var dict in kvp.Value)
                    {
                        tuple = new Tuple<int, int>(dict.Value.First(), dict.Value.Last());
                        intervals.Add(tuple);

                    }
                }
            }
            foreach (var tup in intervals)
            {
                foreach (var tup2 in intervals)
                {
                    if (!mem.Contains(new Tuple<Tuple<int, int>, Tuple<int, int>>(tup, tup2)))
                    {
                        if (!(tup.Item1 == tup2.Item1 && tup.Item2 == tup2.Item2))
                        {
                            if (tup.Item1 <= tup2.Item2 && tup2.Item1 <= tup.Item2)
                            {
                                count++;
                            }
                            mem.Add(new Tuple<Tuple<int, int>, Tuple<int, int>>(tup, tup2));
                        }
                    }

                }
            }

            IntertwinedCount = count;
            AllFields.Add("Intertwined situations", count);
        }
    }
}

