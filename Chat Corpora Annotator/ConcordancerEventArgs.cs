using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
	public class ConcordanceEventArgs : EventArgs
	{
		public string Term;
		public int Chars;
	}
	public delegate void ConcordanceEventHandler(object sender, ConcordanceEventArgs args);
}
