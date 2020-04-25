using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTest.Net.Collections;
using BrightIdeasSoftware;
using System.Collections;
using System.Windows.Forms;
using Wintellect.PowerCollections;

namespace Viewer
{
	public class VirtualBLockTreeDataSource : AbstractVirtualListDataSource
	{
		public BTreeDictionary<DateTime,ArrayMessageBlock> blockTree = new BTreeDictionary<DateTime, ArrayMessageBlock>();
		
		public Dictionary<ArrayMessage,int> messageIndexMap = new Dictionary<ArrayMessage,int>();
		public Dictionary<int, ArrayMessage> indexMessageMap = new Dictionary<int,ArrayMessage>();
		public Dictionary<int,List<int>> messageCounts = new Dictionary<int,List<int>>();
		public VirtualBLockTreeDataSource(VirtualObjectListView listView)
			: base(listView)
		{
			this.listView = listView;
		}

		
		public override void AddObjects(ICollection modelObjects)
		{
			
			foreach (object modelObject in modelObjects)
			{
				ArrayMessageBlock block = modelObject as ArrayMessageBlock;
				if (block != null)
					blockTree.Add(block.Day, block);
  
			}
			this.RebuildIndexMap();
		}

		public override void ApplyFilters(IModelFilter iModelFilter, IListFilter iListFilter)
		{
			
			this.SetObjects(this.blockTree);
		}

		

			public object GetNthObject(int n)
		{
			

			if (n >= 0 && n <= this.GetObjectCount())
			{
				return indexMessageMap[n];
			}
			return null;

		}

			
		

		public int GetObjectCount()
		{
			int count = 0;
			foreach(var block in blockTree.Values)
			{
				count += block.Block.Count;
			}
			return count;
		}

		public int GetObjectIndex(object model)
		{
			ArrayMessage message = model as ArrayMessage;
			return messageIndexMap[message];
		}

		public void InsertObjects(int index, ICollection modelObjects)
		{
			throw new NotImplementedException();
		}

		public void PrepareCache(int first, int last)
		{
			throw new NotImplementedException();
		}

		public void RemoveObjects(ICollection modelObjects)
		{
			throw new NotImplementedException();
		}

		public int SearchText(string value, int first, int last, OLVColumn column)
		{
			throw new NotImplementedException();
		}

		public override void SetObjects(IEnumerable collection)
		{
			if (collection is BTreeDictionary<DateTime, ArrayMessageBlock>)
			{

				this.blockTree = collection as BTreeDictionary<DateTime, ArrayMessageBlock>;

				this.RebuildIndexMap();
			}
		}

		public void Sort(OLVColumn column, SortOrder order)
		{
			throw new NotImplementedException();
		}

		public void UpdateObject(int index, object modelObject)
		{
			throw new NotImplementedException();
		}

		protected void RebuildIndexMap()
		{
			//int count = 0;
			//for (int i = 0; i < blockTree.Count; i++)
			//{
			//	List<int> temp = new List<int>();
			//	for (int j = 0; j < blockTree.ElementAt(i).Value.Block.Count; j++)
			//	{
			//		temp.Add(count);
			//		count++;
			//	}
			//	messageCounts.Add(i, temp);

			//}
			this.messageIndexMap.Clear();
			this.indexMessageMap.Clear();
			int index = 0;
			if (blockTree != null)
			{
				foreach (var block in blockTree.Values)
				{
					foreach (var message in block.Block)
					{
						messageIndexMap.Add(message, index);
						indexMessageMap.Add(index, message);
						index++;
					}
				}
			}
		}
	}
}
