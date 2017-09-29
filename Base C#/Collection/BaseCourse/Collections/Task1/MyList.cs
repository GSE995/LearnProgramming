using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class MyList<T> : IMyList<T>
    {
        T[] array = new T[0];
        int position = -1;

        public T this[int num]
        {
            get { return this.array[num]; }
            set { array[num] = value; }
        }

        public void Add(T value)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = value;
        }

        public void Remove()
        {
            Array.Resize(ref array, array.Length - 1);
        }

        public void Shift(T value)
        {
            T[] temp = new T[array.Length + 1];
            temp[0] = value;
            for (int i = 0; i < array.Length; i++)
            {
                temp[i + 1] = array[i];
            }
            this.array = temp;
        }

        public void UnShift()
        {
            T[] temp = new T[array.Length - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = array[i + 1];
            }
            this.array = temp;
        }

        public int Count
        {
            get { return array.Length; }
        }

        public void Dispose()
        {
            Reset();
        }

        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public T Current => array[position];

        object IEnumerator.Current => array[position];

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
