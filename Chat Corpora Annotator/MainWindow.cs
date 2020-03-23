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


        
        private List<DynamicMessage> messages = new List<DynamicMessage>();
        private BTreeDictionary<DateTime, int> messagesPerDay = new BTreeDictionary<DateTime, int>();

        //private BTreeDictionary<DateTime, ChatMessageBlock> messageTree = new BTreeDictionary<DateTime,ChatMessageBlock>();
        //private VirtualBLockTreeDataSource blockTree;
        //private List<ArrayMessage> messages = new List<ArrayMessage>();


   
        List<Color> heatMapColors = new List<Color>();
       

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

        private void DisplayData()
        {

            chatTable.SetObjects(messages);
            
            List<OLVColumn> columns = new List<OLVColumn>();
            
            foreach(var key in selectedFields)
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
        private void SetUpIndex()
        {
            var AppLuceneVersion = LuceneVersion.LUCENE_48;

            indexLocation = @"C:\Index";
            dir = FSDirectory.Open(indexLocation);
            

            //create an analyzer to process the text
            analyzer = new StandardAnalyzer(AppLuceneVersion);

            //create an index writer
            indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            writer = new IndexWriter(dir, indexConfig);
            writer.DeleteAll();
            writer.Commit();

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
                        ArrayMessage message = new ArrayMessage(row, allFields, selectedFields, dateFieldKey);


                        date = DateTime.Parse(row[dateIndex]);
                        userKeys.Add(row[senderIndex]);


                        var day = date.Date;
                        if (!messagesPerDay.Keys.Contains(day))
                        {
                            messagesPerDay.Add(day, 1);
                        }
                        else
                        {
                            int temp = messagesPerDay[day];
                            messagesPerDay.TryUpdate(day, temp++);
                        }
                        #region
                        //if (!messageTree.Keys.Contains(day))
                        //{
                        //    messageTree.Add(day, new ChatMessageBlock(day, selectedFields));
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
                        #endregion
                        Document document = new Document();

                        for (int i = 0; i < selectedFields.Count; i++)
                        {
                            int textindex = Array.IndexOf(selectedFields.ToArray(), textFieldKey);
                            int dateindex = Array.IndexOf(selectedFields.ToArray(), dateFieldKey);
                            if (i != textindex && i !=dateindex)
                            {
                                document.Add(new StringField(selectedFields[i], message.Contents[i], Field.Store.YES));
                            }
                            else if(i == textindex)
                            {
                                document.Add(new TextField(selectedFields[i], message.Contents[i], Field.Store.YES));
                            }
                            else
                            {
                                var temp = DateTools.DateToString(date, DateTools.Resolution.MINUTE);
                                document.Add(new StringField(selectedFields[i],temp, Field.Store.YES));
                            }
                        }

                        writer.AddDocument(document);



                    }
                    writer.Commit();
                    writer.Flush(triggerMerge: false, applyAllDeletes: false);
                    writer.Dispose();
                }

                PopulateSenderColors();

                DataLoaded();



            }
        }
        private void LoadSomeDocuments(int n)
        {
            var reader = DirectoryReader.Open(dir);
            
            for (int i = 0; i < n; i++)
            {
                List<string> temp = new List<string>();
                var document = reader.Document(i);
                foreach (var field in selectedFields)
                {
                    
                    temp.Add(document.GetField(field).GetStringValue());
                }
                DynamicMessage succ = new DynamicMessage(temp,selectedFields,dateFieldKey);
                messages.Add(succ);
                
                
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


            double max = messagesPerDay.Values.Max();
            double min = messagesPerDay.Values.Min();

            foreach (var date in messagesPerDay.Keys)
            {
                double x = messagesPerDay[date];
                heatMapColors.Add(HeatMapColor(x, min, max));
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
                LoadSomeDocuments(50);
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
                textFieldKey = cm.textFieldKey;
                PopulateData();
                cm.Close();

            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            ChartForm cf = new ChartForm();
            cf.InitializeChart(messagesPerDay.Keys.ToList(), messagesPerDay.Values.ToList());

        }


        public void SetDateView()
        {
            listView1.View = View.Details;
            listView1.VirtualMode = true;
            listView1.VirtualListSize = messagesPerDay.Keys.Count;
            RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            listView1.RetrieveVirtualItem += handler;


        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index = e.ItemIndex;
            string date = messagesPerDay.Keys.ElementAt<DateTime>(index).ToShortDateString();
            e.Item = new ListViewItem(date);

        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ListView lw = sender as ListView;

            //ListView.SelectedIndexCollection index = listView1.SelectedIndices;
            //string date = listView1.Items[index[0]].SubItems[0].Text;
            //DateTime key = DateTime.Parse(date);

            //int i = chatTable.IndexOf(message[key].Block[0]);
            //var item = chatTable.GetItem(i);

            //chatTable.SelectedItem = item;
            //chatTable.EnsureVisible(chatTable.GetItemCount() - 1);
            //chatTable.EnsureVisible(i);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopulateHeatmap();
            LinearHeatmapForm swf = new LinearHeatmapForm();
            swf.InitializeHeatMap(heatMapColors);
            swf.Show();
            swf.DrawHeatMap();
            swf.Draw();
        }
    }
}

