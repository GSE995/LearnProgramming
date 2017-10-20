using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    class PepsiFactory : AbstractFactory
    {
        public override AbstractBottle createBottle()
        {
            return new PepsiBottle();
        }

        public override AbstractCover createCover()
        {
            return new PepsiCover();
        }
    }
}
