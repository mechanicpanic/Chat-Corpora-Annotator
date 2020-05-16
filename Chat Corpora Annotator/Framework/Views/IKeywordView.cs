using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface IKeywordView:IView
    {
        List<string> RakeKeywords { get; set; }
        Dictionary<List<string>,int> Keyphrases { get; set; }

       event EventHandler RakeClick;
        void DisplayRakeKeywords();

    }
}
