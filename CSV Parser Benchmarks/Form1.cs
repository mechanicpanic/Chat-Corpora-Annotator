using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CsvHelper;
using SoftCircuits.CsvParser;


namespace CSV_Parser_Benchmarks
{
    public partial class Form1 : Form
    {
        public string csvPath;
        public List<dynamic> records;
        public List<string[]> data;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
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
            LoadData();

        }
        //private void LoadData()
        //{
        //    using (var reader = new StreamReader(csvPath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        //records = csv.GetRecords<dynamic>().ToList();
        //        using (var dr = new CsvDataReader(csv))
        //        {
        //            dt = new DataTable();
        //            dt.Load(dr);
        //        }
                
        //    }

        //}

        private void LoadData()
        {
            data = new List<string[]>();
            using (CsvReader reader = new CsvReader(csvPath))
            {
                string[] columns = null;
                while (reader.ReadRow(ref columns))
                    data.Add(columns);

                    
            }
        }
    }
}
