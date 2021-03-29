using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.MyEventArgs
{
    public class OpenEventArgs
    {
        public string Path { get; set; }
        public string FilePath { get; set; }
    }
    public delegate void OpenEventHandler(object sender, OpenEventArgs args);
}
