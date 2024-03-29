﻿using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public interface IStatisticsService
    {
        bool IsCalculated { get; }
        int NumberOfDocs { get; }
        long NumberOfSymbols { get; }
        ulong NumberOfTokens { get; }
        int NumberOfUsers { get; }
        double AverageLength { get; }
        double AverageMessagesPerUnit { get; }
        List<int> AllLengths { get; }

        List<int> AllTokenNumbers { get; }

        List<int> AllTokenLengths { get; }
        TimeSpan Duration { get; }

        void CalculateAll();
        Dictionary<string, double> AllFields { get; }


    }

    public interface ITaggedStatisticsService : IStatisticsService
    {
        int WindowCount { get; }
        int AverageUsersPerSituation { get; }
        Dictionary<string, int> AverageUsersInSituationPerTag { get; }
        Dictionary<string, int> SituationsPerTag { get; }

        int AverageWindowLength { get; }
        int IntertwinedCount { get; }



    }

}



