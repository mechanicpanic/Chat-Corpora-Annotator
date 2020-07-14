using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public static class UserDictsContainer
    {
        public static Dictionary<string, List<string>> UserDicts { get; set; }
        static UserDictsContainer()
        {
            UserDicts = new Dictionary<string, List<string>>();
        }
    }
}
