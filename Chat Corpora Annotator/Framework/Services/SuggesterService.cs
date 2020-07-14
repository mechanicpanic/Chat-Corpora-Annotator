using CSharpTest.Net.Collections;
using IndexEngine;
using System;
using System.Collections.Generic;
using ExtractingServices;

using Viewer.Framework.Presenters.Parser;

namespace Viewer.Framework.Services
{
    public class SuggesterService : ISuggestService
    {
        public BTreeDictionary<int, List<DynamicMessage>> Suggestions { get; set; }
        
        



    }
    public interface ISuggestService
    {
        BTreeDictionary<int, List<DynamicMessage>> Suggestions { get; set; }

        //List<List<int>> Parse(string query);
        
    }
}
