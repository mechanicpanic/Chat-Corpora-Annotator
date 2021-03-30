using System;

namespace Viewer.Framework.MyEventArgs
{
    public class NgramEventArgs : EventArgs
    {
        public int minSize { get; set; }
        public int maxSize { get; set; }
        public bool ShowUnigrams { get; set; }
        public string Term { get; set; }
    }
    public delegate void NgramEventHandler(object sender, NgramEventArgs args);

}
