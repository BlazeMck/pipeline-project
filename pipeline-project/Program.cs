using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipeline_project 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SDEV 2410 Final Project by Riley McKinlay\n");

            // Create an array that holds Marketing objects, then fill it with 4 Marketing objects
            Marketing[] items = {new Marketing(12.29, Type.basic, "P123", "coffee mug", 25), new Marketing(3.29, Type.basic, "P987", "magnet, large", 30),
                            new Marketing(11.99, Type.expensive, "P547", "stuffed bear", 4), new Marketing(2.50, Type.cheap, "P879", "note cube", 75)};

            Console.WriteLine("Part A: Purchasing Products");

            // Foreach loops all in items, calls Calculate() method for each
            foreach (Marketing item in items)
            {
                item.Calculate();
            }
            // Displays all the totals in Marketing
            Marketing.DisplayTotal();

            Console.WriteLine("\nPart B: Shipping");

            // Create an array that holds Shipping objects, then fill it with 4 Shipping objects
            Shipping[] legs = {new Shipping(2000, 11.5, 8.5, 4, 5.2, "S678", "Miami FL", 150), new Shipping(800, 5, 5, 5, 12.3, "S449", "Chicago IL", 75),
                               new Shipping(150, 6.5, 6.5, 3, 2.5, "S721", "Denver CO", 15), new Shipping(30, 14, 8, 1, 1.5, "S678", "SLC UT", 5) };

            // Foreach loops all in legs, calls Calculate() method for each
            foreach (Shipping item in legs)
            {
                item.Calculate();
            }
            // Displays all the totals in Shipping
            Shipping.DisplayTotal();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

