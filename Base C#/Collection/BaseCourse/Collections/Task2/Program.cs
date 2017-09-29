using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, int> dic = new MyDictionary<string, int>();
            dic["stas"] = 22;
            dic["stas2"] = 22;
            dic["stas"] = 23;
            foreach (var a in dic)
            {
                Console.WriteLine(a);
            }
        }
    }
}
