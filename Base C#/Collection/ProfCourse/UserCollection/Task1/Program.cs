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
           MonthCollection first = new MonthCollection();

            foreach (string month in first.GetMothForCountDay(31))
            {
                Console.WriteLine(month);
            }
        }
    }
}
