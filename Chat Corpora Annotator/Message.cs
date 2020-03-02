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
        public Dictionary<string, string> properties;
        
        public DynamicMessage(string[] fields, string[] data)
        {
            this.Id = new Guid();
            properties = new Dictionary<string, string>();
            for (int i = 0; i < fields.Length; i++)
            {
                properties.Add(fields[i], data[i]);
            }

        }
        private void DisplayDynamicMessage(List<DynamicMessage> msgList)
        {

            List<string> data = new List<string>();
            foreach (var msg in msgList)
            {
                foreach (KeyValuePair<string, string> kvp in msg.properties)
                {
                    data.Add(kvp.Value);

                }
            }
            
        }
        
    }
        
}
