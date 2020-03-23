using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace Chat_Corpora_Annotator
{
    public class ArrayMessage
    {
        private List<string> contents = new List<string>();
        
        public List<string> Contents { get { return contents; } set { contents = value; } }

        private DateTime date;
        public DateTime Date { get { return date; } }



        public ArrayMessage(List<string> init)
        {
            foreach(var str in init)
            {
                contents.Add(str);
            }
        }

        public ArrayMessage(List<string> init, int dateIndex)
        {
            foreach (var str in init)
            {
                if (Array.IndexOf(init.ToArray(), str) == dateIndex)
                {
                    contents.Add(str);
                    this.date = DateTools.StringToDate(str);
                }
                else
                {
                    contents.Add(str);
                }
            }
        }

        //TODO: Redesign this.
        public ArrayMessage(string[] data, string[] fields, List<string> selectedFields, string dateFieldKey)
        {
            contents = new List<string>();
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == dateFieldKey && selectedFields.Contains(fields[i]))
                {
                    contents.Add(data[i]);
                    date = DateTime.Parse(data[i]);
                }
                else if (selectedFields.Contains(fields[i]))
                {
                    contents.Add(data[i]);
                }
                else
                {
                    continue;
                }
            }

        }


    }
}
