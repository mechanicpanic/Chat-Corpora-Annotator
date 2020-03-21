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
using Lucene.Net;
using Lucene.Net.Util;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;


namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
     

        public string[] allFields;
        public List<string> selectedFields = new List<string>();

        private string dateFieldKey;
        private string senderFieldKey;
        private string textFieldKey;

        private Random rnd = new Random();

        private Set<string> userKeys = new Set<string>();
        private Dictionary<string, Color> userColors = new Dictionary<string, Color>();

        
        private List<ChatMessage> messages = new List<ChatMessage>();
        private BTreeDictionary<DateTime, ChatMessageBlock> messageTree = new BTreeDictionary<DateTime,ChatMessageBlock>();
        private VirtualBLockTreeDataSource blockTree;

        
        OrderedDictionary<DateTime,int> messagesPerDay = new OrderedDictionary<DateTime, int>();
        List<Color> heatMapColors = new List<Color>();
        private Dictionary<int,DateTime> indexMessageMap = new Dictionary<int, DateTime>();

        string indexLocation;
        FSDirectory dir;
        IndexWriterConfig indexConfig;
        IndexWriter writer;

        StandardAnalyzer analyzer;

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

        //private void DisplayData()
        //{
        //    chatTable.SetObjects(messageTree);



        //    List<OLVColumn> columns = new List<OLVColumn>();
        //    for(int i = 0; i < selectedFields.Count; i++)
        //    {

        //        OLVColumn cl = new OLVColumn();
        //        cl.AspectGetter = delegate (object x)
        //        {
        //            ChatMessageBlock block = (ChatMessageBlock)x;
        //            return block.Block[0].Contents[i].ToString();
        //        };
        //        cl.Text = selectedFields[i];
        //        cl.WordWrap = true;

        //        columns.Add(cl);

        //    }
        //    chatTable.AllColumns.AddRange(columns);
        //    chatTable.RebuildColumns();
        //}

            //    AddDataToDisplay();

            //}

            //private void AddDataToDisplay()
            //{
            //    //TODO: Create data loader out of this method.
            //    //So far this is just a normal addition of elements to chatTable.

            //    //Currently extremely slow.
            //    foreach (var kvp in messageTree) {
            //        chatTable.AddObjects(kvp.Value.Block);
            //            }
            //    foreach (var cl in chatTable.AllColumns)
            //    {
            //        cl.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            //    }
            //    chatTable.FormatCell += ChatTable_FormatCell;
            //    chatTable.Refresh();

            //}




            private void SetUpIndex() {
            var AppLuceneVersion = LuceneVersion.LUCENE_48;

            indexLocation = @"C:\Index";
            dir = FSDirectory.Open(indexLocation);

            //create an analyzer to process the text
            analyzer = new StandardAnalyzer(AppLuceneVersion);

            //create an index writer
            indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            writer = new IndexWriter(dir, indexConfig);

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
            cm.PopulateTextBox(selectedFields.ToArray());

            cm.Show();
            cm.ColumnButtonClicked += new EventHandler(ColumnButtonHandler);
        }
        private void PopulateData()
        {
            if (selectedFields != null)
                SetUpIndex();
            {
                DateTime date = new DateTime();

                var dateIndex = Array.IndexOf(allFields, dateFieldKey);
                var senderIndex = Array.IndexOf(allFields, senderFieldKey);
                var textIndex = Array.IndexOf(allFields, textFieldKey);

                string[] row = null;

                int index = 0;
                using (var csv = new CsvReader(csvPath))
                {
                    csv.ReadRow(ref row);
                    while (csv.ReadRow(ref row))
                    {
                        //ChatMessage message = new ChatMessage(row, allFields, selectedFields, dateFieldKey);


                        date = DateTime.Parse(row[dateIndex]);
                        var day = date.Date;

                        userKeys.Add(row[senderIndex]);

                        //if (!messageTree.Keys.Contains(day))
                        //{
                        //   messageTree.Add(day, new ChatMessageBlock(day, selectedFields));
                        //    messageTree[day].AddMessage(message);
                        //    indexMessageMap.Add(index, date);
                        //    index++;
                        //}
                        //else
                        //{
                        //    messageTree[day].AddMessage(message);
                        //    indexMessageMap.Add(index, date);
                        //    index++;
                        //}
                        Document document = new Document
                        {
                            new StringField(dateFieldKey,DateTools.DateToString(date, DateTools.Resolution.DAY),Field.Store.YES),
                            new StringField(senderFieldKey,row[senderIndex],Field.Store.YES),
                            new TextField(textFieldKey,row[textIndex],Field.Store.YES)
                        };


                        writer.AddDocument(document);
                        


                    }
                    writer.Flush(triggerMerge: false, applyAllDeletes: false);
                    writer.Dispose();
                }
                //CountMessagesPerDay();
                //PopulateSenderColors();
                //PopulateHeatmap();
                DataLoaded();


            
            }
        }
        private void LoadSomeDocuments()
        {
            var reader = DirectoryReader.Open(dir);
            for (int i = 0; i < 200; i++)
            {
                Document d = reader.Document(i);
                var a = d.GetValues("text");
                Console.WriteLine(a[0]);
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
        public Color HeatMapColor(double value, double min, double max)
        {
            double val = (value - min) / (max - min);
            int r = Convert.ToByte(255 * val);
            int g = Convert.ToByte(255 * (1 - val));
            int b = 0;

            return Color.FromArgb(255, r, g, b);
        }
        private void PopulateHeatmap()
        {
            List<int> values = new List<int>();
           
            foreach (var val in messageTree.Values)
            {
                values.Add(val.Block.Count());
            }

            double max = values.Max();
            double min = values.Min();
            values.Clear();
            foreach(var date in messageTree.Keys)
            {
                double x = messageTree[date].Block.Count;
                heatMapColors.Add(HeatMapColor(x,min,max));
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
                SetDateView();
                //DisplayData();
                //SetChatTable();
                LoadSomeDocuments();
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
                textFieldKey = cm.textFieldKey;
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
            //cf.InitializeChart(messagesPerDay.Keys.ToList(), messagesPerDay.Values.ToList());

        }


        public void SetDateView()
        {
            listView1.View = View.Details;
            listView1.VirtualMode = true;
            listView1.VirtualListSize = messageTree.Keys.Count;
            RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            listView1.RetrieveVirtualItem += handler;


        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index = e.ItemIndex;
            string date = messageTree.Keys.ElementAt<DateTime>(index).ToShortDateString();
            e.Item = new ListViewItem(date);

        }






        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView lw = sender as ListView;

            ListView.SelectedIndexCollection index = listView1.SelectedIndices;
            string date = listView1.Items[index[0]].SubItems[0].Text;
            DateTime key = DateTime.Parse(date);

            int i = chatTable.IndexOf(messageTree[key].Block[0]);
            var item = chatTable.GetItem(i);

            chatTable.SelectedItem = item;
            chatTable.EnsureVisible(chatTable.GetItemCount() - 1);
            chatTable.EnsureVisible(i);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            LinearHeatmapForm swf = new LinearHeatmapForm();
            swf.InitializeHeatMap(heatMapColors);
            swf.Show();
            swf.DrawHeatMap();
            swf.Draw();
        }

        private void chatTable_Scroll(object sender, ScrollEventArgs e)
        {

            
        }

        private void chatTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
