using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    class ArrayList<T> : IList<T>
    {
        private T[] items = new T[10];

        private int length;

        public int Count { get { return length; } }

        public T this[int index]
        {
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new System.IndexOutOfRangeException();
                }
                items[index] = value;
            }
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new System.IndexOutOfRangeException();
                }
                return items[index];
            }
        }

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(T item)
        {
            ++length;
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }
            items[length] = item;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T item)
        {
            foreach (T element in items)
            {
                if (item.Equals(element)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < length; i++)
            {
                if (item.Equals(items[i])) { return i; }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ++length;
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }
            if (index < length - 1)
            {
                Array.Copy(items, index, items, index + 1, length - index - 1);
            }
            items[index] = item;
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new System.IndexOutOfRangeException();
            }
            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }
            --length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
