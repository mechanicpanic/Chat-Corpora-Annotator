using IndexingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Deprecated
{
    public class DynamicMessageBlock : IComparable
    {
        public DateTime day;

        public List<DynamicMessage> block;

        public List<string> fields;

        public string senderFieldKey;
        public DynamicMessageBlock(DateTime day)
        {
            this.day = day;
            block = new List<DynamicMessage>();

        }
        public DynamicMessageBlock(List<DynamicMessage> messages)
        {
            if (messages != null)
            {
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
