using System;

namespace UStorage
{
    public class DataStorage<T>
    {
        private T dataItem;

        private Action<T> onChange;

        public DataStorage(Action<T> onChange)
        {
            this.onChange = onChange;
        }

        public DataStorage()
        {
        }

        // Method to store data
        public void StoreData(T data)
        {
            dataItem = data;
            onChange?.Invoke(data);
        }

        // Method to retrieve data
        public T RetrieveData()
        {
            return dataItem;
        }

        // Method to clear data
        public void ClearData()
        {
            dataItem = default;
        }
    }
}
