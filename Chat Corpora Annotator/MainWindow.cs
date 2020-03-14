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

        
        private List<ChatMessage> messages = new List<ChatMessage>();
        private BTreeDictionary<DateTime, ChatMessageBlock> messageTree = new BTreeDictionary<DateTime,ChatMessageBlock>();
        //private List<DynamicMessageBlock> messageBlocks = new List<DynamicMessageBlock>();

        
        OrderedDictionary<DateTime,int> messagesPerDay = new OrderedDictionary<DateTime, int>();

        
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
            var tempcollect = messageTree.First().Value.Block;
            //chatTable.SetObjects(tempcollect);

            
            List<OLVColumn> columns = new List<OLVColumn>();
            foreach (var item in tempcollect[0].Contents)
            {

                OLVColumn cl = new OLVColumn();                
                cl.AspectGetter = delegate (object x)
                {
                    ChatMessage message = (ChatMessage)x;
                    int temp = tempcollect[0].Contents.IndexOf(item);
                    return message.Contents[temp];
                };
                cl.Text = selectedFields[tempcollect[0].Contents.IndexOf(item)];
                cl.WordWrap = true;

                columns.Add(cl);

            }
                chatTable.AllColumns.AddRange(columns);
                chatTable.RebuildColumns();
            
            AddDataToDisplay();

        }

        private void AddDataToDisplay()
        {
            //TODO: Create data loader out of this method.
            //So far this is just a normal addition of elements to chatTable.

            //Currently fairly slow. 
            foreach (var kvp in messageTree) {
                chatTable.AddObjects(kvp.Value.Block);
                    }
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
                DateTime date = new DateTime();

                var dateIndex = Array.IndexOf(allFields, dateFieldKey);
                var senderIndex = Array.IndexOf(allFields, senderFieldKey);

                string[] row = null;

                using (var csv = new CsvReader(csvPath))
                {
                    csv.ReadRow(ref row);
                    while (csv.ReadRow(ref row))
                    {
                        ChatMessage message = new ChatMessage(row, allFields, selectedFields, dateFieldKey);

                        date = DateTime.Parse(row[dateIndex]).Date;

                        userKeys.Add(row[senderIndex]);

                        if (!messageTree.Keys.Contains(date))
                        {
                            messageTree.Add(date, new ChatMessageBlock(date, selectedFields));
                        }
                        else
                        {
                            messageTree[date].AddMessage(message);
                        }


                    }
                }
                CountMessagesPerDay();
                PopulateSenderColors();
                DataLoaded();

            }
            else
            {
                throw new ArgumentNullException("No data to populate collection with");
            }
        }

        private void CountMessagesPerDay()
        {
            foreach(var kvp in messageTree)
            {
                messagesPerDay.Add(kvp.Key,kvp.Value.Block.Count());
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
            cf.InitializeChart(messagesPerDay.Keys.ToList(), messagesPerDay.Values.ToList());
            cf.Show();
        }
        private void PopulateDates()
        {
            foreach (var date in messageTree.Keys)
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
