using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator
{
    public class ChatMessage
    {
        private List<object> contents;

        public List<object> Contents { get { return contents; } set { contents = value; } }

        private string date;

        public ChatMessage()
        {
            contents = new List<object>();
        }
        public ChatMessage(List<object> init)
        {
            contents = init;
        }

        //TODO: Redesign this.
        public ChatMessage(string[] data, string[] fields, List<string> selectedFields, string dateFieldKey)
        {
            contents = new List<object>();
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == dateFieldKey && selectedFields.Contains(fields[i]))
                {

                    contents.Add(DateTime.Parse(data[i].ToString()));
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
