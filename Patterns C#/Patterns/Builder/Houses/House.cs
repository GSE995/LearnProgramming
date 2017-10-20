using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class House
    {
        ArrayList housepart = new ArrayList();

        public void Add(object obj)
        {
            housepart.Add(obj);
        }
    }
}
