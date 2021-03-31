using System.Collections.Generic;

namespace IndexEngine
{
    public abstract class Index<TKey,TValue, K, V> where TValue: IDictionary<K, V>
    {

        public abstract Dictionary<TKey,TValue> IndexCollection { get; set; } //should not be public but i haven't figured it out yet
        public abstract void UnloadData();
        internal abstract bool CheckFiles();
        internal abstract bool CheckDirectory();
        public abstract void ReadIndexFromDisk();
        public abstract void FlushIndexToDisk();
        public abstract void AddOuterIndexEntry(TKey key, TValue value);
        public abstract void AddInnerIndexEntry(TKey key, K inkey, V invalue);
        public abstract void DeleteOuterIndexEntry(TKey key);

        public abstract void DeleteInnerIndexEntry(TKey key, K inkey);
        public abstract void InitializeIndex(List<TKey> list);
        public abstract void UpdateOuterIndexEntry(TKey key, TValue value);

    }

    public abstract class Container<T>
    {
        public abstract void UnloadData();
        public abstract IEnumerable<T> TypeContainer { get; set; }
    }
}
