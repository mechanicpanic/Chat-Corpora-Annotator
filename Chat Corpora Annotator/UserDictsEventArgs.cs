using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public class UserDictsEventArgs: EventArgs
    {
        public string Name { get; set; }
        public List<string> Words { get; set; }

    }
    public delegate void UserDictsEventHandler(object sender, UserDictsEventArgs args);

   
}
