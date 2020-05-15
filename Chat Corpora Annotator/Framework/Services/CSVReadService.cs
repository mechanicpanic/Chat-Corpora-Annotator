using Microsoft.VisualBasic.FileIO;
using SoftCircuits.CsvParser;

namespace Viewer.Framework.Services
{

    public interface ICSVReadService
    {
        //Dictionary<string, int> MessagesPerDay { get; set; }
        string[] GetFields(string path);
        int GetLineCount(string path);



    }




    public class CSVReadService : ICSVReadService
    {
        public string[] GetFields(string path)
        {
            string[] allFields;
            using (var parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(","); //TODO: Delimiter select

                allFields = parser.ReadFields();
            }
            return allFields;
        }

        public int GetLineCount(string path)
        {
            string[] row = null;
            int count = 0;
            using (var csv = new CsvReader(path))
            {
                csv.ReadRow(ref row); //header read;
                while (csv.ReadRow(ref row))
                {
                    count++;
                }
            }
            return count;
        }


    }
}
