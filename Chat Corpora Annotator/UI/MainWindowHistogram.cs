using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Viewer.Framework.Views;
using Viewer.UI;
using ZedGraph;

namespace Viewer
{
    public partial class MainWindow : Form, IMainView, ITagView, INotifyPropertyChanged

    {
		public void DisplayStatistics(StatisticsContainer stats)
		{

			listView1.Items.Add(new ListViewItem(new string[2] { "Average messsage length", stats.AverageLength.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Average messages per day", stats.AverageMessagesPerDay.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of messages", stats.NumberOfDocs.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of symbols", stats.NumberOfSymbols.ToString() }));
			listView1.Items.Add(new ListViewItem(new string[2] { "Number of tokens", stats.NumberOfTokens.ToString() }));

		}
		Dictionary<string, double> IMainView.Statistics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public PointPairList LengthHist { get; set; } = new PointPairList();
		public PointPairList TokenHist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			switch (listBox1.Items[listBox1.SelectedIndex].ToString())
			{
				case "Message length":
					VisualizeLengths?.Invoke(this, EventArgs.Empty);
					break;
				case "Token number by message":
					VisualizeTokens?.Invoke(this, EventArgs.Empty);
					break;
				case "Token lengths":
					VisualizeTokenLengths?.Invoke(this, EventArgs.Empty);
					break;
			}

		}

		public void VisualizeHist(PointPairList list, string name)
		{
			zedGraphControl1.GraphPane.GraphObjList.Clear();
			zedGraphControl1.GraphPane.CurveList.Clear();
			zedGraphControl1.GraphPane.AddBar(name, list, Color.CornflowerBlue);

			zedGraphControl1.GraphPane.YAxis.Title.Text = "Count";
			zedGraphControl1.GraphPane.XAxis.Title.Text = "Value";
			zedGraphControl1.AxisChange();
			zedGraphControl1.Refresh();
		}
	}
}
