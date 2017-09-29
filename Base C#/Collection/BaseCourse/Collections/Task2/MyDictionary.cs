using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyDictionary<Tkey, Tvalue> : IEnumerable<string>, IEnumerator<string>
    {
        KeyAndValue<Tkey, Tvalue>[] arr = new KeyAndValue<Tkey, Tvalue>[0];
        public int Count => arr.Length;

        int position = -1;

        public void Add(Tkey key, Tvalue value)
        {
                if (IndexOf(key) == -1)
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = new KeyAndValue<Tkey, Tvalue>(key, value);
                }
                else
                {
                    throw new Exception("Kay is exist");
                }
        }

        public Tvalue this[Tkey key]
        {
            get
            {
                int index = IndexOf(key);
                if (index != -1) return arr[index].Value;
                throw new KeyNotFoundException();
            }
            set
            {
                int index = IndexOf(key);
                if (index == -1)
                {
                    Add(key, value);
                } else
                {
                    arr[index].Value = value;
                }  
            }
        }

        public int IndexOf(Tkey key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Key.Equals(key)) return i;
            }
            return -1;
        }

        public string Current => arr[position].ToString();

        object IEnumerator.Current => arr[position].ToString();

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            Reset();
        }

        public bool MoveNext()
        {
            if(position < arr.Length - 1)
            {
                position++;
                return true;
            }else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
