using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;



namespace Chat_Corpora_Annotator
{
    public partial class MainWindow : Form
    {
        public string csvPath;
        public TextFieldParser parser;
        private int lineCount;
        
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
            updateListView();
            listView1.EndUpdate();

           
        }
        private void openParser()
        {
            parser = new TextFieldParser(csvPath);
            parser.SetDelimiters(",");
            
        }
        private void countLines()
        {
            StreamReader sr = new StreamReader(csvPath);
            {
                
                while ((sr.ReadLine()) != null)
                {
                    lineCount++;
                }
            }
            sr.Close();
        }
        private void updateListView()
        {
            listView1.BeginUpdate();
            countLines();

            listView1.View = View.Details;
            listView1.VirtualMode = true; 		
            listView1.VirtualListSize = lineCount;
            listView1.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView1_RetrieveVirtualItem);

        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                Console.WriteLine(String.Join(" ", row));
                ListViewItem rowitem = new ListViewItem(row);
                e.Item = rowitem;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
