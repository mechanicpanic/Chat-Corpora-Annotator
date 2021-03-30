using System.Collections.Generic;

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
