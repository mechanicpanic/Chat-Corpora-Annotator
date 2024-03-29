﻿namespace Viewer.Framework.MyEventArgs
{
    public class OpenEventArgs
    {
        public string Path { get; set; }
        public string FilePath { get; set; }
    }
    public delegate void OpenEventHandler(object sender, OpenEventArgs args);
}
