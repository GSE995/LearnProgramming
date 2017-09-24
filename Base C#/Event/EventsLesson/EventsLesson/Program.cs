using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsLessonWords 
{
    public delegate void PressKeyEventHandler();  
    
    public class Keywords
    {
        public event PressKeyEventHandler presskeyA = null;
        public event PressKeyEventHandler presskeyB = null;

        public void PressKeyAEvent()
        {
            if(presskeyA != null)
            {
                presskeyA();
            }
        }

        public void PressKeyBEvent()
        {
            if(presskeyB != null)
            {
                presskeyB();
            }
        }

        public void Start()
        {
            while (true)
            {
                string res = Console.ReadLine();
                switch (res.ToLower())
                {
                    case "a":
                        PressKeyAEvent();
                        break;
                    case "b":
                        PressKeyBEvent();
                        break;
                    default:
                        Console.WriteLine("not");
                        break;
                }
            }
        }
    }
    class Program
    {
        static void PressKeyA_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("      x     ");
            Console.WriteLine("     x x    ");
            Console.WriteLine("   x     x  ");
            Console.WriteLine("  xxxxxxxxx ");
            Console.WriteLine(" x         x");
            Console.WriteLine("x           x");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

        }
        static void PressKeyB_Handler()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("  xxxxxxx    ");
            Console.WriteLine("  x          ");
            Console.WriteLine("  x          ");
            Console.WriteLine("  xxxxx      ");
            Console.WriteLine("  x     x    ");
            Console.WriteLine("  x     x    ");
            Console.WriteLine("  x     x    ");
            Console.WriteLine("  xxxxxx     ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void Main(string[] args)
        {
            Keywords key = new Keywords();
            key.presskeyA += PressKeyA_Handler;
            key.presskeyB += PressKeyB_Handler;

            key.Start();

        }
    }
}
