using IndexingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{

    public interface ISuggesterView: IView
    {

        event SuggesterMoveEventHandler MoveSituation;

        event EventHandler LoadCode;
        event EventHandler LoadMeet;
        event EventHandler LoadSoft;
        event EventHandler LoadJob;
        void DisplaySituation(string type);

        List<DynamicMessage> CurrentSoft { get; set; }
        List<DynamicMessage> CurrentMeet { get; set; }
        List<DynamicMessage> CurrentJob { get; set; }
        List<DynamicMessage> CurrentCode { get; set; }

    }
}
