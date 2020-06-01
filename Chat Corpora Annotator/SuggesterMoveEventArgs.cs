using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public class SuggesterMoveEventArgs: EventArgs
    {
        public int Index { get; set; }
        public string Type { get; set; }

    }
    public delegate void SuggesterMoveEventHandler(object sender, SuggesterMoveEventArgs args);
}
