using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface INGramView: IView
    {
        int minSize { get; set; }
        int maxSize { get; set; }
        bool ShowUnigrams { get; set; }
        string Term { get; set; }
        event EventHandler NGramClick;
        void DisplayNGrams(List<string> grams);
        void DisplayNGramCounts(List<int> counts);
    }
}
