﻿using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface IKeywordView:IView
    {
        BTreeDictionary<string,double> RakeKeywords { get; set; }
        int RakeWordCount { get; }
        Dictionary<List<string>,int> Keyphrases { get; set; }
        List<string> NounPhrases { get; set; }
       event EventHandler RakeClick;
        event EventHandler StanfordClick;
        void DisplayRakeKeywords();
        void DisplayKeyPhrases();
        int RakeLength { get; set; }

    }
}
