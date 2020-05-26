using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;

namespace Viewer.Framework.Views
{
    public interface INGramView : IView
    {
        int minSize { get; set; }
        int maxSize { get; set; }
        bool ShowUnigrams { get; set; }
        string Term { get; set; }
        event EventHandler NGramClick;
        void DisplayNGrams(BPlusTree<string, int> bigrams, BPlusTree<string, int> trigrams, BPlusTree<string, int> fourgrams, BPlusTree<string, int> fivegrams);
        //void DisplayNGramCounts(List<int> counts);
    }
}
