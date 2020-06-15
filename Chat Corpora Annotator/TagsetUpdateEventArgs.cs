using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public class TagsetUpdateEventArgs : EventArgs
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }

    }
    public delegate void TagsetUpdateEventHandler(object sender, TagsetUpdateEventArgs args);
}
}
