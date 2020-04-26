using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
	public class LuceneQueryEventArgs : EventArgs
	{
		private readonly string query;
		private readonly int count;
		private readonly string[] users;
		private readonly string[] dates;
		private readonly bool window;
		public LuceneQueryEventArgs(string query, int count, string[] users,string[] dates,bool window)
		{
			this.query = query;
			this.count = count;
			this.dates = dates;
			this.users = users;
			this.window = window;
		}

		public LuceneQueryEventArgs(string query, bool window) {
			this.query = query;
			this.window = window;
		}
		public LuceneQueryEventArgs(string query, int count, bool window) {
			this.query = query;
			this.count = count;
			
			this.window = window;

		}

		public LuceneQueryEventArgs(string query,int count, string[] users, bool window) {

			this.query = query;
			this.count = count;
			
			this.users = users;
			this.window = window;
		}

	
		public string Query
		{
			get { return this.query; }
		}
		public int Count { get { return this.count; } }

		public string[] Users { get { return this.users; } }
		public string[] Dates { get { return this.dates; } }
		public bool Window { get { return this.window; } }
	}
}
