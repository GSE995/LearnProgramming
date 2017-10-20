using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class ConcreteBuilder : Builder
    {
        House house = new House();

        public override void BuildPartOne()
        { 
            house.Add(new Basement());
        }

        public override void BuildPartTwo()
        {
            house.Add(new Storey());
        }

        public override void BuildPartTree()
        {
            house.Add(new Roof());
        }

        public override House GetResult()
        {
            return house;
        }
    }
}
