using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Framework.Main
{
    public interface ITagView: IView
    {
        List<DynamicMessage> Messages { get; set; }
        event EventHandler WriteToDisk;
        event EventHandler TagsetClick;
        event EventHandler AddTag;
        event EventHandler RemoveTag;
        event EventHandler EditSituation;
    }
    
        
    
}
