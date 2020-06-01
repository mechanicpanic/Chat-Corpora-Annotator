using CSharpTest.Net.Collections;
using IndexingServices;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Services
{
    public class SuggesterService : ISuggestService
    {
        public BTreeDictionary<int, List<DynamicMessage>> JobIndex { get; set; }
        public BTreeDictionary<int, List<DynamicMessage>> CodeIndex { get; set; }
        public BTreeDictionary<int, List<DynamicMessage>> MeetIndex { get; set; }
        public BTreeDictionary<int, List<DynamicMessage>> SoftIndex { get; set; }
        public void GetCodeSuggestions()
        {
            throw new NotImplementedException();
        }

        public void GetJobSuggestions()
        {
            throw new NotImplementedException();
        }

        public void GetMeetSuggestions()
        {
            throw new NotImplementedException();
        }


        public void GetSoftSuggestions()
        {
            throw new NotImplementedException();
        }
    }
    public interface ISuggestService
    {
        BTreeDictionary<int, List<DynamicMessage>> JobIndex { get; set; }
        BTreeDictionary<int, List<DynamicMessage>> CodeIndex { get; set; }
        BTreeDictionary<int, List<DynamicMessage>> MeetIndex { get; set; }
        BTreeDictionary<int, List<DynamicMessage>> SoftIndex { get; set; }
        void GetCodeSuggestions();
        void GetMeetSuggestions();
        void GetJobSuggestions();
        void GetSoftSuggestions();

    }
}
