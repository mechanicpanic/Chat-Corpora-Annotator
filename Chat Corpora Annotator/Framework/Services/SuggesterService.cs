using CSharpTest.Net.Collections;
using IndexEngine;
using System;
using System.Collections.Generic;
using ExtractingServices;

namespace Viewer.Framework.Services
{
    public class SuggesterService : ISuggestService
    {
        public BTreeDictionary<int, List<DynamicMessage>> Suggestions { get; set; }

        public void Parse(string query) { }

    }
    public interface ISuggestService
    {
        BTreeDictionary<int, List<DynamicMessage>> Suggestions { get; set; }

        void Parse(string query);
        
    }
}
