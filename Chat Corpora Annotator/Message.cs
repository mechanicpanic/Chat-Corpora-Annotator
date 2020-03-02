using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator
{
    public class DynamicMessage
    {
        private Guid Id { get; set; }
        public Dictionary<string, string> contents;
        
        public DynamicMessage(string[] fields, string[] data)
        {
            this.Id = new Guid();
            contents = new Dictionary<string, string>();
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }

        }
        public DynamicMessage()
        {
            this.Id = new Guid();
            contents = new Dictionary<string, string>();
            string[] fields = new string[] { "a", "b", "c", "d" };
            string[] data = new string[] { "a", "b", "c", "d" };
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }


        }

        public DynamicMessage(string[] fields, string[] data, List<string> selectedFields)
        {
            this.Id = new Guid();
            contents = new Dictionary<string, string>();
            Dictionary<string, string> tempContents = new Dictionary<string, string>();

            for (int i = 0; i < fields.Length; i++)
            {
                tempContents.Add(fields[i], data[i]);
            }
            var pf = fields.ToList().Intersect(selectedFields);
            List<string> projectedFields = pf.ToList<string>();



            for (int i = 0; i < projectedFields.Count(); i++)
            {
                string tempkey = projectedFields[i];
                string tempval = tempContents[tempkey];
                contents.Add(tempkey,tempval);
            }
            tempContents.Clear();
            //TODO: Read about disposing of CLR objects.

        }

    }
        
}
