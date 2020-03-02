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
        public string[] allFields;


        public List<DynamicMessage> messages = new List<DynamicMessage>();
        
        private List<string> selectedFields = new List<string>();



        public MainWindow()
        {
                       
            InitializeComponent();
            
            
            //DynamicMessage message = new DynamicMessage(fields, data);


            //messages.Add(message);
            //messages.Add(message);
            //messages.Add(message);
            //messages.Add(message);
            //messages.Add(message);
            

        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
                     
            
                
            
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
            SelectData();

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
            chatTable.Refresh();
        }

        private void openParser()
        {
            parser = new TextFieldParser(csvPath);
            parser.SetDelimiters(",");
        }
        
        public void SelectData()
        {
            allFields = parser.ReadFields();
            
            HeaderForm hf = new HeaderForm();
            AddOwnedForm(hf);
            hf.Show();
            hf.UpdateLabel(Path.GetFileName(csvPath));
            hf.ShowFields(allFields);
            hf.FieldButtonClicked += new EventHandler(FieldButtonHandler);
            
       }
        public void PopulateData()
        {
            if (selectedFields != null)
            {
                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    DynamicMessage msg = new DynamicMessage(allFields, row, selectedFields);
                    messages.Add(msg);
                }
                if (parser.EndOfData)
                {
                    DataLoaded dl = new DataLoaded();
                    dl.Show();
                    dl.OKButtonClicked += new EventHandler(OKButtonHandler);
                    
                }
            }
        }
        private void FieldButtonHandler(object sender, EventArgs e)
        {
            HeaderForm hf = sender as HeaderForm;
            if (hf != null)
            {
                selectedFields = hf.SelectedFields;
                PopulateData();
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
        private void HeaderForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
          
        }

               
    }
}
