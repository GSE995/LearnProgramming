using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Invoice
    {
        public readonly int account;
        public readonly string customer;
        public readonly string provider;

        public string Article { get; set; }
        public int Quantity { get; set; }

        public Invoice(int account, string customer, string provider)
        {
            this.account = account;
            this.customer = customer;
            this.provider = provider;
        }

        public double CountCost(bool check)
        {
            double cost = 0;
            switch (Article.ToLower())
            {
                case "soup":
                    cost = 10;
                    break;
                case "shampoo":
                    cost = 20;
                    break;
                default:
                    Console.WriteLine("Нет такого товара");
                        break;
            }
            if (check) return (cost / 1.18 * 0.18) * Quantity;
            return cost * Quantity;
        }
    }
}
