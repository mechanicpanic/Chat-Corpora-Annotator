using BrightIdeasSoftware;
using IndexEngine;
using System;
using System.Collections;
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
		public void DisplayStatistics(int type, Dictionary<string,double> args)
		{
			if (type == 0)
			{
				string specifier = "G";
				foreach (var param in args)
				{
					
					{
						statisticsListView.Items.Add(new ListViewItem(new string[] { param.Key, param.Value.ToString() }));
					}
					

				}
			}
			if (type == 1)
            {
				foreach(var param in args)
                {
					corpusStatisticsView.Items.Add(new ListViewItem(new string[] { param.Key, param.Value.ToString() }));
				}
			}

			}
	}

		
		
		//private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		//{
		//	switch (listBox1.Items[listBox1.SelectedIndex].ToString())
		//	{
		//		case "Message length":
		//			VisualizeLengths?.Invoke(this, EventArgs.Empty);
		//			break;
		//		case "Token number by message":
		//			VisualizeTokens?.Invoke(this, EventArgs.Empty);
		//			break;
		//		case "Token lengths":
		//			VisualizeTokenLengths?.Invoke(this, EventArgs.Empty);
		//			break;
		//	}

		//}

		//public void VisualizeHist(PointPairList list, string name)
		//{
		//	//zedGraphControl1.GraphPane.GraphObjList.Clear();
		//	//zedGraphControl1.GraphPane.CurveList.Clear();
		//	//zedGraphControl1.GraphPane.AddBar(name, list, Color.CornflowerBlue);

		//	//zedGraphControl1.GraphPane.YAxis.Title.Text = "Count";
		//	//zedGraphControl1.GraphPane.XAxis.Title.Text = "Value";
		//	//zedGraphControl1.AxisChange();
		//	//zedGraphControl1.Refresh();
		//}
	}

