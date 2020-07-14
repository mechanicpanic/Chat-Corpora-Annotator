﻿using IndexEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Framework.Views
{

    public interface ISuggesterView: IView
    {
       void DisplaySituation();

        event EventHandler RunQuery;
        string QueryString { get; set; }
        List<DynamicMessage> CurrentSituation { get; set; }
        List<List<List<int>>> QueryResult { get; set; }
        int DisplayIndex { get; set; }
        int GroupIndex { get; set; }
        //Dictionary<string, List<string>> UserDicts { get; set; }
        void SetCounts();
        event UserDictsEventHandler AddUserDict;

        event UserDictsEventHandler DeleteUserDict;

    }
}
