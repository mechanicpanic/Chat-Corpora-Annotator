using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexEngine
{
    public abstract class Index
    {
        public abstract void UnloadData();
        public abstract void ReadIndexFromDisk(string path);
        public abstract void FlushIndexToDisk(string path);
    }

    public abstract class Container<T>
    {
        public abstract void UnloadData();
        public abstract IEnumerable<T> TypeContainer { get; set; }
    }
}
