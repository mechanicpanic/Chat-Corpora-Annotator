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
        private int lineCount;
        

        private List<string[]> messages = new List<string[]>();
    

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
            LoadDataHeader();
            LoadData();
            SetListView();
           
        }


        private void openParser()
        {
            parser = new TextFieldParser(csvPath);
            parser.SetDelimiters(",");
        }
        public void LoadDataHeader()
        {          
            fields = parser.ReadFields();

            foreach (var field in fields) {
                listView1.Columns.Add(field);
            }
 
        }
        
        public void SetListView()
        {
            listView1.View = View.Details;
            listView1.VirtualMode = true;
            listView1.VirtualListSize = messages.Count;
            RetrieveVirtualItemEventHandler handler = new RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            listView1.RetrieveVirtualItem += handler;
            
            
        }

        private void LoadData()
        {
            while(!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                //Console.WriteLine(String.Join(" ", row));
                messages.Add(row);
            }
            if(parser.EndOfData)
            {
                MessageBox.Show("done");
            }
        }


        
        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
              
                    e.Item = new ListViewItem(messages[e.ItemIndex]);
                        
            } 
            
                
        

        
    }
}
