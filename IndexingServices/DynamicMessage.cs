using Lucene.Net.Documents;
using System;
using System.Collections.Generic;

namespace IndexEngine
{
    public static class MessageContainer
    {
        public static List<DynamicMessage> Messages { get; set; }
        //Should be sufficient for keeping some messages in-memory.

    }
    public class DynamicMessage : IComparable
    {
        public int Id { get; set; }
        private string dateFieldKey;
        public string DateFieldKey { get { return dateFieldKey; } set { this.dateFieldKey = value; } }

        public Dictionary<string, object> contents;

        public DynamicMessage(string[] fields, string[] data)
        {
            //this.Id = Guid.NewGuid();
            contents = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }

        }
        public DynamicMessage()
        {
            //this.Id = Guid.NewGuid();
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
            //this.Id = Guid.NewGuid();
            contents = new Dictionary<string, object>();


            for (int i = 0; i < fields.Length; i++)
            {
                if (selectedFields.Contains(fields[i]))
                {
                    contents.Add(fields[i], data[i]);
                }
                else
                {
                    continue;

                }
            }
        }

        public DynamicMessage(string[] fields, string[] data, List<string> selectedFields, string dateFieldKey)
        {
            //this.Id = Guid.NewGuid();
            contents = new Dictionary<string, object>();
            this.dateFieldKey = dateFieldKey;

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == dateFieldKey && selectedFields.Contains(fields[i]))
                {
                    contents.Add(fields[i], DateTime.Parse(data[i].ToString()));
                }
                else if (selectedFields.Contains(fields[i]))
                {
                    contents.Add(fields[i], data[i]);
                }
                else
                {
                    continue;
                }
            }

        }

        public DynamicMessage(List<string> data, List<string> selectedFields, string dateFieldKey, int id)
        {
            //this.Id = Guid.NewGuid();
            this.Id = id;
            if (data.Count != selectedFields.Count)
            {
                throw new Exception("Wrong array size");

            }
            else
            {
                this.contents = new Dictionary<string, object>();
                for (int i = 0; i < data.Count; i++)
                {
                    if (selectedFields[i] == dateFieldKey)
                    {
                        contents.Add(selectedFields[i], DateTools.StringToDate(data[i]));

                    }
                    else
                    {
                        contents.Add(selectedFields[i], data[i]);
                    }
                }
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            DynamicMessage otherMessage = obj as DynamicMessage;
            if (otherMessage != null)
            {

                DateTime temp = (DateTime)contents[dateFieldKey];
                return temp.CompareTo(otherMessage.contents[dateFieldKey]);

            }
            else
            {
                throw new ArgumentException("Object is not a DynamicMessage");
            }
        }
    }




}
