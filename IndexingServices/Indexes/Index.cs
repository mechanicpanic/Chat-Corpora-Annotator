using System.Collections.Generic;

namespace IndexEngine
{
    public interface INestedIndex<TKey, TValue, K, V> : IUnloadable where TValue : IDictionary<K, V>
    {

        IDictionary<TKey, TValue> IndexCollection { get; }
        int ItemCount { get; }
        bool CheckFiles();
        bool CheckDirectory();
        void ReadIndexFromDisk();
        void FlushIndexToDisk();
        void AddOuterIndexEntry(TKey key, TValue value);
        void AddInnerIndexEntry(TKey key, K inkey, V invalue);
        void DeleteOuterIndexEntry(TKey key);
        void DeleteInnerIndexEntry(TKey key, K inkey);
        void InitializeIndex(List<TKey> list);
        void UpdateOuterIndexEntry(TKey key, TValue value);
        int GetValueCount(TKey key);
        int GetInnerValueCount(TKey key, K inkey);
    }

    public interface IContainer<T> : IUnloadable
    {
        
        IEnumerable<T> TypeContainer { get; }
        void Add(T item);
        void AddRange(IEnumerable<T> items);
    }

    public interface IUnloadable
    {
        void UnloadData();
    }
}
