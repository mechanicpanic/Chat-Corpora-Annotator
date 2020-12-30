using IndexEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
	public class WriteEventArgs : EventArgs
	{
		public List<DynamicMessage> ids = new List<DynamicMessage>();
	}
	public delegate void WriteEventHandler(object sender, WriteEventArgs args);
}
