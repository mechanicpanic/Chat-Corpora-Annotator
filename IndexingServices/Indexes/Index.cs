using System.Collections.Generic;

namespace IndexEngine
{
    public abstract class Index<TKey,TValue>
    {

        public abstract Dictionary<TKey,TValue> IndexCollection { get; set; } 
        public abstract void UnloadData();
        internal abstract bool CheckFiles();
        internal abstract bool CheckDirectory();
        public abstract void ReadIndexFromDisk();
        public abstract void FlushIndexToDisk();
        public abstract void AddIndexEntry(TKey key, TValue value);
        public abstract void DeleteIndexEntry(TKey key);

        public abstract void UpdateIndexEntry(TKey key, TValue value);

    }

    public abstract class Container<T>
    {
        public abstract void UnloadData();
        public abstract IEnumerable<T> TypeContainer { get; set; }
    }
}
