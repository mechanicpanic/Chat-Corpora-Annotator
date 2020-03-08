using System;
using System.Collections.Generic;

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
            this.Id = new Guid();
            contents = new Dictionary<string, object>();


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

    }

}
