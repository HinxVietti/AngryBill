using BillDataStruct.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillShell
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User()
            {
                uName = "hinx"
            };
            Console.WriteLine(u.uName);
            Console.ReadKey();
        }
    }
}
