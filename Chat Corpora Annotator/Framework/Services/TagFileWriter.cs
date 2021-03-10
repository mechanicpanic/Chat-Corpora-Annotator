using IndexEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Viewer.Framework.Services
{
    public interface ITagFileWriter
    {
        void WriteMessage(int messageId, string text, string user, string date);
        //void WriteSituation(List<Dictionary<string, string>> messages, string situation);
        void WriteSituation(List<DynamicMessage> messages, string situation, int sid);
        void WriteSituation(List<int> messageIds, string situation, int sid);
        void CloseWriter();
        void OpenWriter();


    }

    
    public class TagFileWriter : ITagFileWriter
    {
        private XmlWriter writer;


        public void OpenWriter()
        {
           
            writer = XmlWriter.Create(IndexService.CurrentIndexPath + @"\info\output.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("Corpus");
        }

        public void WriteMessage(int messageId, string text, string user, string date)
        {
            writer.WriteStartElement("Message");
            writer.WriteAttributeString("id", messageId.ToString());
            writer.WriteElementString("Text", text);
            writer.WriteElementString("User", user);
            writer.WriteElementString("Date", date);
            writer.WriteEndElement();
        }
        
        public void CloseWriter()
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public void WriteSituation(List<DynamicMessage> messages, string situation, int sid)
        {
            writer.WriteStartElement("Situation", situation);
            writer.WriteAttributeString("SId", sid.ToString());
            foreach (var msg in messages)
            {
                WriteMessage(msg.Id, msg.Contents[IndexService.TextFieldKey].ToString(), msg.Contents[IndexService.SenderFieldKey].ToString(), msg.Contents[IndexService.DateFieldKey].ToString());
            }
            writer.WriteEndElement();
        }
        public void WriteSituation(List<int> messageIds, string situation, int sid)
        {
            writer.WriteStartElement("Situation", situation);
            writer.WriteAttributeString("SId", sid.ToString());

            foreach (var id in messageIds)
            {
                var msg = IndexService.RetrieveMessageById(id);
                WriteMessage(id, msg.Contents[IndexService.TextFieldKey].ToString(), msg.Contents[IndexService.SenderFieldKey].ToString(), msg.Contents[IndexService.DateFieldKey].ToString());
            }
            writer.WriteEndElement();
        }
    }
}
