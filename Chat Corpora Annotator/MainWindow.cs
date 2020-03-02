using BrightIdeasSoftware;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;



namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
        public TextFieldParser parser;
        public string[] fields;


        public List<DynamicMessage> messages = new List<DynamicMessage>();
        //public List<Dictionary<string,string>> messages = new List<Dictionary<string,string>>();



        public MainWindow()
        {
                       
            InitializeComponent();
            
            string[] fields = new string[] { "a", "b", "c", "d" };
            string[] data = new string[] { "a", "b", "c", "d" };
            DynamicMessage message = new DynamicMessage(fields, data);


            messages.Add(message);
            messages.Add(message);
            messages.Add(message);
            messages.Add(message);
            messages.Add(message);
            

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //if (messages[0].properties != null)
            {
                chatTable.SetObjects(messages);
                List<OLVColumn> columns = new List<OLVColumn>();
                
                foreach (var key in messages[0].properties.Keys)
                {
                    
                    OLVColumn cl = new OLVColumn();
                    cl.AspectGetter = delegate (object x)
                    {
                        DynamicMessage message = (DynamicMessage)x;
                        return message.properties[key];
                    };
                    cl.Text = key;
                    columns.Add(cl);
                    

                }
                chatTable.AllColumns.AddRange(columns);
                chatTable.RebuildColumns();
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
            LaunchDataHeaderSelection();
            LoadData();
        }


        private void openParser()
        {
            parser = new TextFieldParser(csvPath);
            parser.SetDelimiters(",");
        }
        
        public void LaunchDataHeaderSelection()
        {
            fields = parser.ReadFields();
            
            HeaderForm hf = new HeaderForm();
            AddOwnedForm(hf);
            hf.Show();
            hf.UpdateLabel(Path.GetFileName(csvPath));
            hf.ShowFields(fields);
            hf.FieldButtonClicked += new EventHandler(FieldButtonHandler);
            
       }
        private void LoadDataHeader()
        {
            //if (selectedFields != null)
            //{
            //    foreach (var field in selectedFields)
            //    {
            //        OLVColumn columnHeader = new OLVColumn();
            //        columnHeader.Text = field;
            //        fastObjectListView1.AllColumns.Add(columnHeader);
            //        fastObjectListView1.RebuildColumns();
            //    }
                

            //}
        }
        private void FieldButtonHandler(object sender, EventArgs e)
        {
            HeaderForm hf = sender as HeaderForm;
            if (hf != null)
            {
                //selectedFields = hf.SelectedFields;
                LoadDataHeader();
            }
            
        }
        private void HeaderForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
          
        }

        
        private void LoadData()
        {
            //while(!parser.EndOfData)
            //{
            //    string[] row = parser.ReadFields();
            //    //Console.WriteLine(String.Join(" ", row));
            //    //messages.Add(row);
            //}
            
        }

        
    }
}
