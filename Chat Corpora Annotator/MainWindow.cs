using BrightIdeasSoftware;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Wintellect.PowerCollections;

namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
        public TextFieldParser parser;

        //private bool headerInit = false;

        public string[] allFields;
        public List<string> selectedFields = new List<string>();

        private string dateFieldKey;
        private string senderFieldKey;

        private Random rnd = new Random();

        private HashSet<string> userKeys = new HashSet<string>();
        private Dictionary<string, Color> userColors = new Dictionary<string, Color>();


        private List<DynamicMessage> messages = new List<DynamicMessage>();
        private HashSet<DateTime> dayKeys = new HashSet<DateTime>();
        List<int> countValues = new List<int>();
        //private Dictionary<DateTime,int> dayCounts = new Dictionary<DateTime,int>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {


        }

        private void ChatTable_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column.Text == senderFieldKey)
            {


                e.SubItem.ForeColor = userColors[e.SubItem.Text];
            }
        }

        private void csvLoadButton_Click(object sender, EventArgs e)
        {
            openCsvDialog();
            csvDialog.ShowDialog();
        }


        private void openCsvDialog()
        {
            csvDialog = new OpenFileDialog();
            csvDialog.Filter = "CSV files (*.csv)|*.csv";
            csvDialog.Title = "Open a .csv file";
            csvDialog.FileOk += csvDialog_FileOk;
        }
        private void csvDialog_FileOk(object sender, CancelEventArgs e)
        {
            csvPath = csvDialog.FileName;
            openParser();
            SelectFields();

        }
        private void openParser()
        {
            parser = new TextFieldParser(csvPath);
            parser.SetDelimiters(",");
        }

        private void DisplayData()
        {
            chatTable.SetObjects(messages);
            List<OLVColumn> columns = new List<OLVColumn>();

            foreach (var key in messages[0].contents.Keys)
            {

                OLVColumn cl = new OLVColumn();
                cl.AspectGetter = delegate (object x)
                {
                    DynamicMessage message = (DynamicMessage)x;
                    return message.contents[key];
                };
                cl.Text = key;
                cl.WordWrap = true;

                columns.Add(cl);

            }
            chatTable.AllColumns.AddRange(columns);
            chatTable.RebuildColumns();

            foreach (var cl in chatTable.AllColumns)
            {
                cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            chatTable.FormatCell += ChatTable_FormatCell;

            chatTable.Refresh();

        }



        private void SelectFields()
        {
            allFields = parser.ReadFields();
            HeaderForm hf = new HeaderForm();
            AddOwnedForm(hf);
            hf.Show();
            hf.UpdateLabel(Path.GetFileName(csvPath));
            hf.ShowFields(allFields);
            hf.FieldButtonClicked += new EventHandler(FieldButtonHandler);

        }
        private void SelectFieldMetadata()
        {
            ColumnMetadata cm = new ColumnMetadata();
            cm.PopulateDateBox(selectedFields.ToArray());
            cm.PopulateSenderBox(selectedFields.ToArray());

            cm.Show();
            cm.ColumnButtonClicked += new EventHandler(ColumnButtonHandler);
        }
        private void PopulateData()
        {
            if (selectedFields != null)
            {
                int count = 0;
                int setCountPrev = 1;

                DateTime date = new DateTime();


                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    DynamicMessage msg = new DynamicMessage(allFields, row, selectedFields, dateFieldKey);
                    messages.Add(msg);
                    userKeys.Add(msg.contents[senderFieldKey].ToString());

                    date = (DateTime)msg.contents[dateFieldKey];
                    dayKeys.Add(date.Date);

                    if (setCountPrev == dayKeys.Count)
                    {
                        count++;
                        setCountPrev = dayKeys.Count;
                    }
                    else
                    {
                        countValues.Add(count);
                        count = 1;
                        setCountPrev = dayKeys.Count;

                    }

                }
                if (parser.EndOfData)
                {
                    PopulateSenderColors();
                    DataLoaded dl = new DataLoaded();
                    dl.Show();
                    dl.OKButtonClicked += new EventHandler(OKButtonHandler);
                    //      dayCounts = dayKeys.Zip(counts, (k, v) => new { k, v })
                    //.ToDictionary(x => x.k, x => x.v);

                }
            }
        }
        private void PopulateSenderColors()
        {
            foreach (var user in userKeys)
            {
                Color tempColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                userColors.Add(user, tempColor);
            }
        }
        private void FieldButtonHandler(object sender, EventArgs e)
        {

            HeaderForm hf = sender as HeaderForm;
            if (hf != null)
            {
                selectedFields = hf.SelectedFields;
                SelectFieldMetadata();
                hf.Close();
            }



        }


        private void OKButtonHandler(object sender, EventArgs e)
        {
            DataLoaded dl = sender as DataLoaded;
            if (dl != null)
            {
                DisplayData();
                dl.Close();
            }

        }

        private void ColumnButtonHandler(object sender, EventArgs e)
        {
            ColumnMetadata cm = sender as ColumnMetadata;
            if (cm != null)
            {
                dateFieldKey = cm.dateFieldKey;
                senderFieldKey = cm.senderFieldKey;
                PopulateData();
                cm.Close();

            }

        }


        private void HeaderForm_FormClosed(Object sender, FormClosedEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChartForm cf = new ChartForm();
            cf.InitializeChart(dayKeys.ToList(), countValues);
            cf.Show();
        }
    }
}
