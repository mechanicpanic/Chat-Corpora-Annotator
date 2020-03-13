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
using CSharpTest.Net.Collections;
using SoftCircuits.CsvParser;



namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
        //public TextFieldParser parser;

        //private bool headerInit = false;

        public string[] allFields;
        public List<string> selectedFields = new List<string>();

        private string dateFieldKey;
        private string senderFieldKey;

        private Random rnd = new Random();

        private Set<string> userKeys = new Set<string>();
        private Dictionary<string, Color> userColors = new Dictionary<string, Color>();

        
        private List<DynamicMessageExp> messages = new List<DynamicMessageExp>();
        private BTreeDictionary<DateTime, DynamicMessageBlock> messageTree = new BTreeDictionary<DateTime,DynamicMessageBlock>();
        //private List<DynamicMessageBlock> messageBlocks = new List<DynamicMessageBlock>();

        private OrderedSet<DateTime> dayKeys = new OrderedSet<DateTime>();
        List<int> countValues = new List<int>();

        
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
            SelectFields();

        }

        private void DisplayData()
        {
            var tempcollect = messageTree.First().Value.blockexp;
            chatTable.SetObjects(tempcollect);
            List<OLVColumn> columns = new List<OLVColumn>();
            foreach (var item in tempcollect[0].contents)
            {

                OLVColumn cl = new OLVColumn();                
                cl.AspectGetter = delegate (object x)
                {
                    DynamicMessageExp message = (DynamicMessageExp)x;
                    int temp = tempcollect[0].contents.IndexOf(item);
                    return message.contents[temp];
                };
                cl.Text = selectedFields[tempcollect[0].contents.IndexOf(item)];
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
               using (var parser = new TextFieldParser(csvPath))
                {
                parser.SetDelimiters(",");

                allFields = parser.ReadFields();
                }
            
            
            HeaderForm hf = new HeaderForm();
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
                DateTime? previousDate = null;
                DateTime date = new DateTime();

                var dateindex = Array.IndexOf(allFields, dateFieldKey);
                var senderindex = Array.IndexOf(allFields, senderFieldKey);

                var selecteddateindex = Array.IndexOf(selectedFields.ToArray(), dateFieldKey);
                var selectedsenderindex = Array.IndexOf(selectedFields.ToArray(), senderFieldKey);

                List<DynamicMessageExp> blockList = new List<DynamicMessageExp>();
                string[] row = null;
                
                using (var csv = new CsvReader(csvPath))
                {
                    csv.ReadRow(ref row);
                    while (csv.ReadRow(ref row))
                    {

                        
                        DynamicMessageExp msg2 = new DynamicMessageExp(row, allFields, selectedFields, dateFieldKey);

                        date = DateTime.Parse(row[dateindex]).Date;

                        userKeys.Add(row[senderindex]);
                        dayKeys.Add(date);

                        if (!messageTree.Keys.Contains(date))
                        {
                            messageTree.Add(date, new DynamicMessageBlock(date));
                        }
                        else
                        {
                            messageTree[date].AddMessageExp(msg2, selecteddateindex);
                        }

                        //DynamicMessage msg = new DynamicMessage(allFields, row, selectedFields, dateFieldKey);
                        //messages.Add(msg);

                        //date = (DateTime)msg.contents[dateFieldKey];
                        //date = date.Date;

                        //userKeys.Add(msg.contents[senderFieldKey].ToString());
                        //if (previousDate == null || previousDate == date)
                        //{

                        //    count++;
                        //    blockList.Add(msg2);

                        //}

                        //else
                        //{
                        //    countValues.Add(count);
                        //    count = 0;
                        //    DynamicMessageBlock block = new DynamicMessageBlock(blockList, date);
                        //    //messageTree.Add(block);
                        //    //messageBlocks.Add(block);
                        //    blockList.Clear();
                        //    blockList.Add(msg2);
                        //}
                        //previousDate = date;


                    }


                    PopulateSenderColors();
                    DataLoaded();
                    
                    
                }
                
            }
        }

        
        private void DataLoaded()
        {
            DataLoaded dl = new DataLoaded();
            dl.Show();
            dl.OKButtonClicked += new EventHandler(OKButtonHandler);
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
                PopulateDates();
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
        private void PopulateDates()
        {
            foreach (var date in dayKeys)
            {
                listBox1.Items.Add(date.ToShortDateString());
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void chatTable_Scroll(object sender, ScrollEventArgs e)
        {

            
        }
    }
}
