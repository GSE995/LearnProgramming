using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IMyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        
        void Add(T value);

        int Count { get; }
        
        T this[int num] { get; set; }
        
        void Remove();
        
        void Shift(T value);
        
        void UnShift();
    }
}
