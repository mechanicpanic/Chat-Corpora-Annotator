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

        
    }
        
}
