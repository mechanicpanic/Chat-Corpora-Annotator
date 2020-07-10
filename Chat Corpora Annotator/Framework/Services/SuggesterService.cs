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
        
        public List<int> Parse(string query) 
        {
            return Parser.parse(query);
        }



    }
    public interface ISuggestService
    {
        BTreeDictionary<int, List<DynamicMessage>> Suggestions { get; set; }

        List<int> Parse(string query);
        
    }
}
