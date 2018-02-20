using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHC.Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaParser pizzaParser = new PizzaParser();
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "small.in"); ;
            pizzaParser.filename = filepath;
            pizzaParser.Parse();

            Console.WriteLine(pizzaParser.PrintPizza());
            Console.Read();
        }
    }
}
