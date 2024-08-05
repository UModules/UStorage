using System.Collections.Generic;

namespace UStorage
{
    public class LocalStorage<T>
    {
        // HashSet to store items without keys, ensuring no duplicates
        private HashSet<T> items;
        private readonly object lockObject = new object();

        public LocalStorage()
        {
            items = new HashSet<T>();
        }

        // Method to add an item
        public void AddItem(T item)
        {
            lock (lockObject)
            {
                items.Add(item);
            }
        }

        public void AddItems(T[] items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        // Method to remove an item
        public bool RemoveItem(T item)
        {
            lock (lockObject)
            {
                return items.Remove(item);
            }
        }

        // Method to retrieve all items
        public List<T> GetAllItems()
        {
            lock (lockObject)
            {
                return new List<T>(items);
            }
        }

        // Method to clear all items
        public void ClearAllItems()
        {
            lock (lockObject)
            {
                items.Clear();
            }
        }
    }
}
