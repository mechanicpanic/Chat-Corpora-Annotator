using CSharpTest.Net.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace IndexEngine
{
    public class ProjectData
    {
        public BTreeDictionary<DateTime, int> MessagesPerDay { get; set; } = new BTreeDictionary<DateTime, int>();

        public HashSet<string> UserKeys { get; set; } = new HashSet<string>();

        public Dictionary<string, Color> UserColors { get; set; } = new Dictionary<string, Color>();

        public List<string> SelectedFields { get; set; } = new List<string>();

        public int LineCount { get; set; }
    }
    public static class ProjectInfo
    {

        public static void LoadProject(string path)
        {
            UnloadData();
            SetPaths(path);
            var list = IndexService.LoadInfoFromDisk(KeyPath);
            SetKeys(list["DateFieldKey"], list["SenderFieldKey"], list["TextFieldKey"]);
            Data.LineCount = int.Parse(list["LineCount"]);
            Data.MessagesPerDay = IndexService.LoadStatsFromDisk(StatsPath);
            Data.UserKeys = IndexService.LoadUsersFromDisk(UsersPath);
            Data.SelectedFields = IndexService.LoadFieldsFromDisk(FieldsPath);
        }

        public static void CreateNewProject(string path, string date, string sender, string text)
        {
            UnloadData();
            SetPaths(path);
            SetKeys(date, sender, text);


        }

        public static void UnloadData()
        {
            Data.MessagesPerDay.Clear();
            Data.UserColors.Clear();
            Data.UserKeys.Clear();
            Data.SelectedFields.Clear();
            Data.LineCount = 0;
            IndexService.UnloadData();
        }
        private static void SetPaths(string path)
        {
            IndexPath = path;
            Name = Path.GetFileNameWithoutExtension(IndexPath);
            InfoPath = IndexPath + @"\info\";
            KeyPath = InfoPath + Name + @"-info.txt";
            FieldsPath = InfoPath + Name + @"-fields.txt";
            UsersPath = InfoPath + Name + @"-users.txt";
            StatsPath = InfoPath + Name + @"-stats.txt";

            SavedTagsPath = InfoPath  + Name + @"-savedtags.txt";
            TagCountsPath = InfoPath  + Name + @"-tagcounts.txt";
            TagsetPath = InfoPath + Name + @"-tagset.txt";
            SituationsPath = InfoPath + Name + @"-situations.txt";

        }

        private static void SetKeys(string date, string sender, string text)
        {
            DateFieldKey = date;
            SenderFieldKey = sender;
            TextFieldKey = text;
        }

        public static string Name { get; private set; }
        public static ProjectData Data { get; private set; } = new ProjectData();
        public static string IndexPath { get; private set; }
        public static string InfoPath { get; private set; }
        public static string KeyPath { get; private set; }
        public static string FieldsPath { get; private set; }
        public static string UsersPath { get; private set; }
        public static string StatsPath { get; private set; }
        public static string DateFieldKey { get; private set; }
        public static string TextFieldKey { get; private set; }
        public static string SenderFieldKey { get; private set; }

        public static string SituationsPath { get; private set;}
        public static string TagCountsPath { get; private set; }
        public static string SavedTagsPath { get; private set; }
        public static string TagsetPath { get; private set; }

        public static string Tagset { get; private set; }
    }
}
