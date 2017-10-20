using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class AbstractFactory
    {
        public abstract AbstractBottle createBottle();
        public abstract AbstractCover createCover();
    }
}
