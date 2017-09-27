using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Convertor
    {
        public readonly double usd;
        public readonly double eur;
        public readonly double rus;

        public Convertor(double usd, double eur, double rus)
        {
            this.usd = usd;
            this.eur = eur;
            this.rus = rus;
        }

        
        public double Convert(double gri, string val)
        {
            switch (val.ToLower())
            {
                case "usd":
                    return gri * usd;
                    break;
                case "eur":
                    return gri * eur;
                    break;
                case "rus":
                    return gri * rus;
                    break;
                default:
                    Console.WriteLine("incorect");
                    return 0;
                    break;
            }
        }

        public double ReverseConvert(double num, string val)
        {
            switch (val.ToLower())
            {
                case "usd":
                    return num / usd;
                    break;
                case "eur":
                    return num / eur;
                    break;
                case "rus":
                    return num / rus;
                    break;
                default:
                    Console.WriteLine("incorect");
                    return 0;
                    break;
            }
        }

        //public void Convert(double gri, string val)
        //{
        //    switch (val.ToLower())
        //    {
        //        case "usd":
        //            Console.WriteLine("usd = {0}", gri * usd);
        //            break;
        //        case "eur":
        //            Console.WriteLine("eur = {0}", gri * eur);
        //            break;
        //        case "rus":
        //            Console.WriteLine("rus = {0}", gri * rus);
        //            break;
        //        default:
        //            Console.WriteLine("incorect");
        //            break;
        //    }
        //}
        //public void Invert(double num, string val)
        //{
        //    switch (val.ToLower())
        //    {
        //        case "usd":
        //            Console.WriteLine("usd = {0}", num / usd);
        //            break;
        //        case "eur":
        //            Console.WriteLine("eur = {0}", num / eur);
        //            break;
        //        case "rus":
        //            Console.WriteLine("rus = {0}", num / rus);
        //            break;
        //        default:
        //            Console.WriteLine("incorect");
        //            break;
        //    }
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            Convertor con = new Convertor(22, 26, 30);
            con.Convert(3, "Usd");
            con.Convert(3, "RUS");
            con.Convert(3, "EuR");

            Console.WriteLine(con.ReverseConvert( 10, "usd"));
        }
    }
}
