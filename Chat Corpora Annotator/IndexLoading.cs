using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class IndexLoading : Form
    {
        public IndexLoading(int max)
        {
            InitializeComponent();
            progressBar1.Maximum = max;
            progressBar1.Minimum = 0;
            
        }
        public void UpdateBar(int step)
        {
            progressBar1.Value += step;
        }
    }
}
