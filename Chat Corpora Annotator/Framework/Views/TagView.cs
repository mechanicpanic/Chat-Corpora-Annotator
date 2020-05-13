using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexingServices;

namespace Viewer.Framework.Views
{
    public interface ITagView: IView
    {
        
        //Dictionary<List<string>,Tuple<string,int>> SituationIndex { get; set; }
        Tuple<List<string>, string> CurrentSituation { get; set; }
        event EventHandler WriteToDisk;
        event EventHandler TagsetClick;
        event EventHandler AddTag;
        event EventHandler RemoveTag;
        event EventHandler EditSituation;
        event EventHandler LoadMore;
        void UpdateTagset(List<string> tags);
        void DisplayDocuments();

        void UpdateTagIndex(List<string> tags);

    }
    
        
    
}
