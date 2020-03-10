using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chat_Corpora_Annotator
{
    public partial class HeatmapForm : Form
    {
        List<DateTime> dates;
        List<DateTime> selectedWeek;
        List<string> users;

        int[,] counts;

        ChartValues<HeatPoint> values;
        
        public HeatmapForm(List<DateTime> dates, List<string> users)
        {
            this.dates = dates;
            InitializeComponent();
        }

        public void InitializeHeatpoints()
        {
            //X for user, Y for day
            for (int i = 0; i < counts.GetLength(0); i++)
            {
                for(int j = 0; j < counts.GetLength(1); j++)
                {
                    values.Add(new HeatPoint((double)i, (double)j, (double)counts[i, j]));
                }
            }
        }
        private void SelectWeek()
        {
            SelectWeekForm sw = new SelectWeekForm();
            sw.Show();
        }
        private void FindUsersByWeek(List<DynamicMessage> messages)
        {
            //TODO: We surely can't iterate over all messages. 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectWeek();
        }
    }
}
