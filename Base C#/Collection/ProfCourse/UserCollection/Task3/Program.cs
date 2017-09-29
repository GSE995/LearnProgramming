using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            People stas = new People("Stas", "Gorynov", new DateTime(1995, 8, 22));

            stas.AddFolk(new People("Nastya", "Pavlenko", new DateTime(2006, 4, 26)));

            

            People nastya = stas["Nastya"];

            nastya.AddFolk(new People("Artur", "Pavlenko", new DateTime(1985, 4, 5)));

            People artur = stas["Nastya"]["Artur"];

            

            People anya = new People("Anna", "Ryabcova", new DateTime(1991, 4, 23));

            stas.AddFolk(anya);

            foreach(People a in stas["Nastya"].GetEnumerator())
            {
                Console.WriteLine(a.name);
            }
             
        }
    }
}
