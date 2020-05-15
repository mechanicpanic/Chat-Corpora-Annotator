using System;

namespace Viewer.Framework.Views
{
    public interface IConcordanceView : IView
    {
        bool IsControl { get; }
        string Term { get; set; }
        void DisplayConcordance(string[] con);
        event EventHandler ConcordanceClick;

    }
}
