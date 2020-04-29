using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    interface IConcordanceView
    {
        string Term { get; set; }
        int OFFSET { get; set; }
        void DisplayConcordance(string[] con);
        event EventHandler ConcordanceClick;
        
    }
}
