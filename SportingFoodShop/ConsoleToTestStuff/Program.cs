using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportingFoodShop.Models.CustomClasses;

namespace ConsoleToTestStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IdGenerator.GenerateId(8));
            Console.ReadLine();
        }
    }
}
