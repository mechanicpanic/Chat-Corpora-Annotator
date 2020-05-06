using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{
    public interface IConcordanceView: IView
    {
        bool IsControl { get;}
        string Term { get; set; }
        void DisplayConcordance(string[] con);
        event EventHandler ConcordanceClick;
        
    }
}
