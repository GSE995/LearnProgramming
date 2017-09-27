using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static double GetSalary(Employee emp)
        {
            double taxes = 0.13;
            double temp = 0;
            switch (emp.Position)
            {
                case "Junior":
                    temp = 30000;
                    break;
                case "Middle":
                    temp = 50000;
                    break;
                case "Senior":
                    temp = 80000;
                    break;
                default:
                    break;
            }

            if (emp.Skil >= 2) temp += 10000;
            if (emp.Skil >= 3) temp += 15000;
            if (emp.Skil >= 4) temp += 20000;
            if (emp.Skil > 5) temp += 30000;


            if (temp != 0) temp = temp - (temp * taxes);

            return temp;
        }


        static void Main(string[] args)
        {
            Employee stas = new Employee("Стас", "Горюнов");
            stas.Position = "Junior";
            stas.Skil = 3;

            Console.WriteLine(GetSalary(stas));
                 
        }
    }
}
