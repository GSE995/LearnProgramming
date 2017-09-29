using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> number = new MyList<int>();

            number.Add(6);
            number.Add(5);

            foreach(int a in number)
            {
                Console.WriteLine(a);
            }

            number.Remove();

            foreach (int a in number)
            {
                Console.WriteLine(a);
            }

        }
    }
}
