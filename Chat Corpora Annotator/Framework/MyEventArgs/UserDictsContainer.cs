﻿using System.Collections.Generic;

namespace Viewer.Framework.MyEventArgs
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
