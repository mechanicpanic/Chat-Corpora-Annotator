using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
    //VERY temporary solution. Will be redone soon
    public partial class DataLoaded : Form
    {
        public event EventHandler OKButtonClicked;
        public DataLoaded()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnOKButtonClicked(null);

        }

        protected virtual void OnOKButtonClicked(EventArgs e)
        {

            EventHandler eh = OKButtonClicked;
            eh?.Invoke(this, e);

        }
    }
    
}
