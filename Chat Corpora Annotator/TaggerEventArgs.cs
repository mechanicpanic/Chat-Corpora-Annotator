using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public class TaggerEventArgs : EventArgs
    {
        public string Tagset;

        public string Tag;

        public List<int> messages;

        public int Id;

        public Dictionary<string, object> AdditionalInfo;
    }
    public delegate void TaggerEventHandler(object sender, TaggerEventArgs args);
}
