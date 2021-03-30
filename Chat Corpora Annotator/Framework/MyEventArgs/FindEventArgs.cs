using System;

namespace Viewer.Framework.MyEventArgs
{
    public class FindEventArgs : EventArgs
    {
        public int id;
    }
    public delegate void FindEventHandler(object sender, FindEventArgs args);
}
