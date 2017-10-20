using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Client
    {
        AbstractBottle bottle;
        AbstractCover cover;

        public Client(AbstractFactory factory)
        {
            bottle = factory.createBottle();
            cover = factory.createCover();
            Console.WriteLine(cover.lable);
            Console.WriteLine(bottle.name);

        }
    }
}
