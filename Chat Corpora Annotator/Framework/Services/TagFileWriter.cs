using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Viewer.Framework.Services
{
    public interface ITagFileWriter
    {
        void WriteMessage(string messageId, string text, string user, string date);
        void WriteSituation(List<Dictionary<string, string>> messages, string situation);
       void CloseWriter();
       
    }
    public class TagFileWriter:IDisposable, ITagFileWriter
    {
        private XmlWriter writer; 
        
        public TagFileWriter()
        {
            writer = XmlWriter.Create("tagged.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Corpus");


        }
        
            public void WriteMessage(string messageId, string text, string user, string date)
        {
            writer.WriteStartElement("Message");
            writer.WriteAttributeString("id", messageId);
            writer.WriteElementString("Text", text);
            writer.WriteElementString("User", user);
            writer.WriteElementString("Date", date);
            writer.WriteEndElement();
        }

        public void WriteSituation(List<Dictionary<string,string>> messages, string situation)
        {
            writer.WriteStartElement("Situation", situation);
            foreach (var msg in messages) {
                WriteMessage(msg["id"], msg["text"], msg["user"], msg["date"]);
                    }
            writer.WriteEndElement();
        }
        public void CloseWriter()
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
