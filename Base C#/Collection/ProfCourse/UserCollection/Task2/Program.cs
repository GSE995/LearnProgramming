using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static IEnumerable GetEnumerator(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if ((array[i] % 2) != 0) yield return array[i] * array[i];
            }
            yield break;
        }
        
        static void Main(string[] args)
        {
            int[] mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach(int a in GetEnumerator(mas))
            {
                Console.WriteLine(a);
            }
        }
    }
}
