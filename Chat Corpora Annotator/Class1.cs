using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator
{
    class Message
    {
        private Guid id { get; set; }
        private string from { get; set; }
        private string to { get; set; }
        private string body { get; set; }
        private DateTime date { get; set; }

        public Message(string from, string to, string body, DateTime date)
        {
            this.id = new Guid();
            this.from = from;
            this.to = to;
            this.date = date;
        }
        public Message(Dictionary<string,string> metaparsed)
        {
            this.id = new Guid();
            
        }
    }
}
