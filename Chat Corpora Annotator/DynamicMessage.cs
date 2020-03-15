using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using BrightIdeasSoftware;

namespace Chat_Corpora_Annotator
{
    public class DynamicMessage : IComparable
    {
        private Guid Id { get; set; }
        private string dateFieldKey;
        public string DateFieldKey { get { return dateFieldKey; } set { this.dateFieldKey = value; } }

        public Dictionary<string, object> contents;

        public DynamicMessage(string[] fields, string[] data)
        {
            this.Id = Guid.NewGuid();
            contents = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                contents.Add(fields[i], data[i]);
            }

        }
        public DynamicMessage()
        {
            this.Id = Guid.NewGuid();
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
            this.Id = Guid.NewGuid();
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
            this.Id = Guid.NewGuid();
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


    public class DynamicMessageBlock: IComparable
    {
        public DateTime day;

        public List<DynamicMessage> block;

        public List<string> fields;
        
        public string senderFieldKey;
        public DynamicMessageBlock(DateTime day) {
            this.day = day;
            block = new List<DynamicMessage>();
           
        }
        public DynamicMessageBlock(List<DynamicMessage> messages)
        {
            if (messages != null) {
                var temp = (DateTime)messages[0].contents[messages[0].DateFieldKey];
                this.day = temp.Date;
                block = new List<DynamicMessage>();
                foreach (var msg in messages)
                {
                    block.Add(msg);
                }
                    }
            else
            {
                throw new ArgumentException("Empty block");
            }
        }



        public void AddMessage(DynamicMessage message)
        {
            var temp = (DateTime)message.contents[message.DateFieldKey];
            if (temp.Date == day)
            {
                this.block.Add(message);
            }
            else
            {
                throw new ArgumentException("Wrong date");
            }
        }

       
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            DynamicMessageBlock otherMessageBlock = obj as DynamicMessageBlock;
            if (otherMessageBlock != null)
            {

                return otherMessageBlock.day.CompareTo(this.day);

            }
            else
            {
                throw new ArgumentException("Object is not a DynamicMessageBlock");
            }
        }
    }

}
