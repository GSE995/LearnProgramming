using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    struct Month
    {
        public readonly string name;
        public readonly int amountday;
        public readonly int serialnumber;
   
        public Month(string name, int amountday, int serialnumber)
        {
            this.name = name;
            this.serialnumber = serialnumber;
            this.amountday = amountday;
        }
    }
}
