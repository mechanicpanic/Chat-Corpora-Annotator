using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Corpora_Annotator
{
    public class DynamicMessage
    {
        private Guid id { get; set; }
        public Dictionary<string, object> properties;
        
        public DynamicMessage(string[] fields, object[] data)
        {
            this.id = new Guid();
            properties = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                properties.Add(fields[i], data[i]);
            }

        }
        private List<string> DisplayDynamicMessage()
        {

            List<string> data = new List<string>();
            foreach (KeyValuePair<string, object> kvp in properties)
            {
                data.Add(kvp.Value.ToString());

            }
            return data;
        }
        
    }
        
}
