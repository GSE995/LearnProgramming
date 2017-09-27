using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee
    {
        public string name;
        public string surename;

        public Employee(string name, string surename)
        {
            this.name = name;
            this.surename = surename;
        }

        public int Skil { get; set; }
        public string Position { get; set; }
    }
}
