using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace UStorage
{
    public class LocalStorage<TKey, TItem>
    {
        // ConcurrentDictionary to store items with keys, ensuring thread safety
        private ConcurrentDictionary<TKey, TItem> keyValuePairs;

        public LocalStorage()
        {
            keyValuePairs = new ConcurrentDictionary<TKey, TItem>();
        }

        // Method to add an item with a key
        public void AddItem(TKey key, TItem item)
        {
            keyValuePairs[key] = item;
        }

        // Method to remove an item with a key
        public bool RemoveItem(TKey key)
        {
            return keyValuePairs.TryRemove(key, out _);
        }

        // Method to retrieve an item by key
        public TItem GetItem(TKey key)
        {
            if (keyValuePairs.TryGetValue(key, out var item))
            {
                return item;
            }
            throw new KeyNotFoundException("The specified key was not found.");
        }

        public bool TryGetItem(TKey key, out TItem item)
        {
            if (keyValuePairs.TryGetValue(key, out item))
            {
                return true;
            }
            item = default(TItem);
            return false;
        }

        // Method to retrieve all keyed items
        public Dictionary<TKey, TItem> GetAllKeyedItems()
        {
            return new Dictionary<TKey, TItem>(keyValuePairs);
        }

        public TItem[] GetAllItems()
        {
            return keyValuePairs.Values.ToArray();
        }

        // Method to clear all items
        public void ClearAllItems()
        {
            keyValuePairs.Clear();
        }
    }
}
