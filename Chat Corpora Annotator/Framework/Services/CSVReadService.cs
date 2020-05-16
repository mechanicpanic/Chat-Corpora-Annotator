using Microsoft.VisualBasic.FileIO;
using SoftCircuits.CsvParser;

namespace Viewer.Framework.Services
{

    public interface ICSVReadService
    {
        //Dictionary<string, int> MessagesPerDay { get; set; }
        string[] GetFields(string path,string delimiter);
        int GetLineCount(string path, bool header);



    }




    public class CSVReadService : ICSVReadService
    {
        public string[] GetFields(string path,string delimiter)
        {
            string[] allFields;
            using (var parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(delimiter); //TODO: Delimiter select

                allFields = parser.ReadFields();
            }
            return allFields;
        }

        public int GetLineCount(string path, bool header)
        {
            string[] row = null;
            int count = 0;
            using (var csv = new CsvReader(path))
            {
                if (header)
                {
                    csv.ReadRow(ref row); //header read;
                }
                
                while (csv.ReadRow(ref row))
                {
                    count++;
                }
            }
            return count;
        }


    }
}
