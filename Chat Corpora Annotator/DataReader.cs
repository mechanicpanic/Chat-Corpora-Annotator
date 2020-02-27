using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deedle;
using Microsoft.VisualBasic.FileIO;
using Deedle;

namespace Chat_Corpora_Annotator
{
   

    public class DataDisplayer
    {
        private ListView listview { get; set; }
        DataDisplayer(ListView listview)
        {
            this.listview = listview;
           



        }

        private void displayData()
        {
            
            listview.BeginUpdate();
            
            listview.EndUpdate();
        }
    }

    
}
