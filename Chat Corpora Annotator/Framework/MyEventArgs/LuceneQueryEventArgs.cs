using System;

namespace Viewer.Framework.MyEventArgs
{
    public class LuceneQueryEventArgs : EventArgs
    {
        private readonly string query;
        private readonly int count;
        private readonly string[] users;
        private readonly DateTime start;
        private readonly DateTime finish;
        private readonly bool window;
        private readonly bool user;
        private readonly bool date;
        public LuceneQueryEventArgs(string query, int count, string[] users, DateTime[] dates, bool window)
        {
            this.query = query;
            this.count = count;
            this.start = dates[0];
            this.finish = dates[1];
            this.users = users;
            user = true;
            date = true;
            this.window = window;
        }

        public LuceneQueryEventArgs(string query, int count, DateTime[] dates, bool window)
        {
            this.query = query;
            this.count = count;
            this.start = dates[0];
            this.finish = dates[1];

            user = false;
            date = true;
            this.window = window;
        }

        public LuceneQueryEventArgs(string query, bool window)
        {
            this.query = query;
            this.window = window;
            user = false;
            date = false;
        }
        public LuceneQueryEventArgs(string query, int count, bool window)
        {
            this.query = query;
            this.count = count;

            this.window = window;
            user = false;
            date = false;

        }

        public LuceneQueryEventArgs(string query, int count, string[] users, bool window)
        {

            this.query = query;
            this.count = count;

            this.users = users;
            user = true;
            date = false;
            this.window = window;
        }


        public string Query
        {
            get { return this.query; }
        }
        public int Count { get { return this.count; } }

        public string[] Users { get { return this.users; } }
        public DateTime Start { get { return this.start; } }
        public DateTime Finish { get { return this.finish; } }
        public bool Window { get { return this.window; } }

        public bool FilteredByDate { get { return date; } }
        public bool FilteredByUser { get { return user; } }
    }

    public delegate void LuceneQueryEventHandler(object sender, LuceneQueryEventArgs args);
}
