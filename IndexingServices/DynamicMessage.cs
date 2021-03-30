using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace IndexEngine
{
    public static class MessageContainer
    {
        public static List<DynamicMessage> Messages { get; set; } = new List<DynamicMessage>();
        //Should be sufficient for keeping some messages in-memory.

    }
    public class DynamicMessage 
    {
        public int Id { get; set; }

        public Dictionary<string, int> Situations { get; set; } = new Dictionary<string, int>();

        private Dictionary<string, object> contents;

        public Dictionary<string, object> Contents { get { return contents; } }

        public DynamicMessage(string[] fields, string[] data)
        {
            
            contents = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }

        }
        public DynamicMessage()
        {
          

        }

        public DynamicMessage(string[] fields, object[] data, List<string> selectedFields)
        {
            
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
            //this.dateFieldKey = dateFieldKey;

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

    }




}
