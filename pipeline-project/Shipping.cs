using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipeline_project
{
    // Class for holding Shipping Objects, Derivative of Item class and inherits IDiscount Interface
    internal class Shipping : Item, IDiscount
    {
        int distance;
        double length, width, height, weight;
        static double zone = 0;
        static double flat = 0;

        // Constructor
        public Shipping(int distance, double length, double width, double height, double weight, string id, string name, int qty)
            : base(id, name, qty)
        {
            this.distance = distance;
            this.length = length;
            this.width = width;
            this.height = height;
            this.weight = weight;
        }
        // ToString() Method for displaying information about Shipping objects
        override public string ToString() => $"{base.ToString()} {base.GetQuantity()} boxes, distance {distance} miles\nSize: {length} x {width} x {height}, weight: {weight}";

        // Calculate() uses a rate given to it by DetermineRate() to calculate all possible totals and applies them to appropriate static variables
        public void Calculate()
        {
            double rate;
            Console.WriteLine($"\n{ToString()}");
            rate = DetermineRate();

            double flatTotal = base.GetQuantity() * 35;
            double zoneTotal = base.GetQuantity() * rate;

            Console.WriteLine($"Zone rate: {rate:C}, ship cost: {zoneTotal:C}\nFlat rate cost: {flatTotal:C}");

            flat += flatTotal;
            zone += zoneTotal;
        }

        // DetermineRate() takes distance to determine what the proper charge rate the entire leg should be
        public double DetermineRate()
        {
            Console.Write("Zone rates:\n   ");
            Console.WriteLine("1000 mi at $50.00, 500 mi at $35.00, 100 mi at $20.00");
            // $50 per box above 1000 miles
            if (distance > 1000) { return 50; }
            // $35 per box above 500 miles
            else if (distance > 500) { return 35; }
            // $20 per box above 100 miles
            else if (distance > 100) { return 20; }
            // $10 per box under 100 miles
            else { return 10; }
        }

        // Static method DisplayTotal() displays all static variable totals
        static public void DisplayTotal()
        {
            Console.WriteLine($"\nSummary:\nZone shipping costs: {zone:C}\n     Flat rate cost: {flat:C}");
        }
    }
}
