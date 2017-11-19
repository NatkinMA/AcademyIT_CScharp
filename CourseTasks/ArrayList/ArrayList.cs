using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] items = new T[10];

        private int length;

        public ArrayList()
        {
            length = 0;
        }

        public ArrayList(params T[] items)
        {
            this.items = items;
            this.length = items.Length;
        }

        public ArrayList(int capacity)
        {
            items = new T[capacity];
            length = capacity;
        }

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
            items[length - 1] = item;
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
            return new ItemEnum<T>(items);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
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
            int i = 0;
            while (!item.Equals(items[i]) && i < length)
            {
                i++;
            }
            if (i < length)
            {
                RemoveAt(i);
                return true;
            }
            return false;
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
            return GetEnumerator();
        }

        public override string ToString()
        {
            string strResult = "";
            if (length > 0)
            {
                if (items[0] != null)
                {
                    strResult = items[0].ToString();
                }
                else
                {
                    strResult = "";
                }
                for (int i = 1; i < length; i++)
                {
                    if (items[i] != null)
                    {
                        strResult = strResult + ", " + items[i].ToString();
                    }
                    else
                    {
                        strResult = strResult + ", ";
                    }
                }
            }
            
            return "{" + strResult + "}";
        }

        public bool Equals(ArrayList<T> arrayList)
        {
            if (arrayList == null)
            {
                return false;
            }
            if (arrayList == this)
            {
                return true;
            }
            if (arrayList.length == this.length)
            {
                for (int i = 0; i < length; i++)
                {
                    if (!this[i].Equals(arrayList[i]))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList<T>)
            {
                return Equals((ArrayList<T>) obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }

    class ItemEnum<T> : IEnumerator<T>
    {
        private T[] items;

        private int position = -1;

        public ItemEnum(T[] arrayList)
        {
            items = arrayList;
        }

        public T Current
        {
            get
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < items.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
