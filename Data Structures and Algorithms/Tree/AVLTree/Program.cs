using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            tree.Add(10);
            tree.Add(11);
            

            foreach(var a in tree)
            {
                Console.WriteLine(a);
            }
        }
    }
}
