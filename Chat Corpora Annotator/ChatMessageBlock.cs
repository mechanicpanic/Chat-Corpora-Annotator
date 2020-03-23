using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;

namespace Chat_Corpora_Annotator
{
    public class ChatMessageBlock: IComparable
    {

        private DateTime day;
        public DateTime Day { get { return day; } }

        private List<ArrayMessage> block;
        public List<ArrayMessage> Block { get { return block; } }

        private List<string> fields;

        private int dateIndex;
        public int DateIndex { get { return dateIndex; } }

        private int senderIndex;
        public int SenderIndex { get { return senderIndex; } }

        
        public ChatMessageBlock(DateTime day, List<string> fields)
        {
            this.day = day;
            this.fields = fields;
            block = new List<ArrayMessage>();
            
        }


        public ChatMessageBlock(List<ArrayMessage> messages, DateTime date)
        {

            this.day = date.Date;
            block = new List<ArrayMessage>();
            foreach (var msg in messages)
            {
                block.Add(msg);
            }


        }



        public void AddMessage(ArrayMessage message)
        {
            DateTime temp = DateTime.Parse(message.Contents[dateIndex]);
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

            ChatMessageBlock otherMessageBlock = obj as ChatMessageBlock;
            if (otherMessageBlock != null)
            {

                return otherMessageBlock.day.CompareTo(this.day);

            }
            else
            {
                throw new ArgumentException("Object is not a ChatMessageBlock");
            }
        }
    }
}
