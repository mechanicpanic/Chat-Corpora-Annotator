﻿using IndexingServices;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Viewer.Framework.Services
{
    public interface ITagFileWriter
    {
        void WriteMessage(string messageId, string text, string user, string date);
        //void WriteSituation(List<Dictionary<string, string>> messages, string situation);
        void WriteSituation(List<DynamicMessage> messages, string situation);
        void CloseWriter();
        void OpenWriter();


    }
    public class TagFileWriter : IDisposable, ITagFileWriter
    {
        private int index = 0;
        private XmlWriter writer;


        public void OpenWriter()
        {
            writer = XmlWriter.Create(@"C:\Users\voidl\CCA\XMLTest\tagged" + index.ToString() + ".xml");

            writer.WriteStartDocument();
            writer.WriteStartElement("Corpus");
            index++;
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

        public void WriteSituation(List<Dictionary<string, string>> messages, string situation)
        {
            writer.WriteStartElement("Situation", situation);
            foreach (var msg in messages)
            {
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

        public void WriteSituation(List<DynamicMessage> messages, string situation)
        {
            writer.WriteStartElement("Situation", situation);
            foreach (var msg in messages)
            {
                WriteMessage(msg.Id, msg.contents[IndexService.TextFieldKey].ToString(), msg.contents[IndexService.SenderFieldKey].ToString(), msg.contents[IndexService.DateFieldKey].ToString());
            }
            writer.WriteEndElement();
        }
    }
}