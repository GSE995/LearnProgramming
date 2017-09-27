using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public readonly DateTime register;

        public User(string login, string firstname, string lastname, int age)
        {
            Login = login;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            register = DateTime.Now;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var userone = new User("stas38irk", "Stas", "Gorynov", 22);
            Console.WriteLine(userone.register);
        }
    }
}
