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
        public Dictionary<string, object> contents;
        
        public DynamicMessage(string[] fields, string[] data)
        {
            this.Id = new Guid();
            contents = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }

        }
        public DynamicMessage()
        {
            this.Id = new Guid();
            contents = new Dictionary<string, object>();
            string[] fields = new string[] { "a", "b", "c", "d" };
            string[] data = new string[] { "a", "b", "c", "d" };
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }


        }

        public DynamicMessage(string[] fields, object[] data, List<string> selectedFields)
        {
            this.Id = new Guid();
            contents = new Dictionary<string, object>();
            Dictionary<string, object> tempContents = new Dictionary<string, object>();

            for (int i = 0; i < fields.Length; i++)
            {
                
                tempContents.Add(fields[i], data[i]);
            }
            var pf = fields.ToList().Intersect(selectedFields);
            List<string> projectedFields = pf.ToList<string>();



            for (int i = 0; i < projectedFields.Count(); i++)
            {
                string tempkey = projectedFields[i];
                object tempval = tempContents[tempkey];
                contents.Add(tempkey,tempval);
            }
            tempContents.Clear();
            //TODO: Read about disposing of CLR objects.

        }

        public DynamicMessage(string[] fields, string[] data, List<string> selectedFields,string dateFieldKey)
        {
            this.Id = new Guid();
            contents = new Dictionary<string, object>();
            Dictionary<string, object> tempContents = new Dictionary<string, object>();

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == dateFieldKey)
                {
                    tempContents.Add(fields[i], DateTime.Parse(data[i].ToString()));
                }
                else
                {
                    tempContents.Add(fields[i], data[i]);
                }
            }
            var pf = fields.ToList().Intersect(selectedFields);
            List<string> projectedFields = pf.ToList<string>();



            for (int i = 0; i < projectedFields.Count(); i++)
            {
                string tempkey = projectedFields[i];
                object tempval = tempContents[tempkey];
                contents.Add(tempkey, tempval);
            }
            tempContents.Clear();
            //TODO: Read about disposing of CLR objects.

        }

    }
        
}
