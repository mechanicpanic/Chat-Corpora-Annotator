using BrightIdeasSoftware;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;



namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
        public TextFieldParser parser;
        public string[] fields;
        private List<string> selectedFields;
        private List<Message> messages = new List<Message>();

        private readonly string[] allowedColumns = new string[] { "date", "from", "to", "body" }; 
        private Dictionary<string, string> columnMetadata = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
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

            LaunchDataHeaderSelection();
            LoadData();
            UpdateListView();


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
            this.AddOwnedForm(hf);
            hf.Show();
            hf.ShowFields(fields);
            hf.FieldButtonClicked += new EventHandler(FieldButtonHandler);
            
       }
        private void LoadDataHeader()
        {
            if (selectedFields != null)
            {
                foreach (var field in selectedFields)
                {
                    OLVColumn columnHeader = new OLVColumn();
                    columnHeader.Text = field;
                    fastObjectListView1.AllColumns.Add(columnHeader);
                    fastObjectListView1.RebuildColumns();
                }
                

            }
        }
        private void FieldButtonHandler(object sender, EventArgs e)
        {
            HeaderForm hf = sender as HeaderForm;
            if (hf != null)
            {
                selectedFields = hf.SelectedFields;
                LoadDataHeader();
            }
            
        }
        private void HeaderForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            GenerateMetadata();
        }

        private void GenerateMetadata()
        {
            
        }
        private void LoadData()
        {
            while(!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                //Console.WriteLine(String.Join(" ", row));
                //messages.Add(row);
            }
            
        }

        private void UpdateListView()
        {
            fastObjectListView1.SetObjects(messages);
            fastObjectListView1.Refresh();
        }  
    }
}
