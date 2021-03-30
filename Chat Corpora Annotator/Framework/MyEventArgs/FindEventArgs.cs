using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.MyEventArgs
{
    public class FindEventArgs : EventArgs
    {
        public int id;
    }
    public delegate void FindEventHandler(object sender, FindEventArgs args);
}
