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
        void CloseWriter();
        void OpenWriter();


    }

    
    public class TagFileWriter : IDisposable, ITagFileWriter
    {
        private int index = 0;
        private XmlWriter writer;


        public void OpenWriter()
        {
           
            writer = XmlWriter.Create(@"C:\Users\annae\" + index.ToString() + ".xml");

            writer.WriteStartDocument();
            writer.WriteStartElement("Corpus");
            index++;
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
        

        //public void WriteSituation(List<Dictionary<string, string>> messages, string situation)
        //{
        //    writer.WriteStartElement("Situation", situation);
        //    foreach (var msg in messages)
        //    {
        //        WriteMessage(msg["id"], msg["text"], msg["user"], msg["date"]);
        //    }
        //    writer.WriteEndElement();
        //}
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

        public void WriteAllSituations()
        {
            
        }


    }
}
