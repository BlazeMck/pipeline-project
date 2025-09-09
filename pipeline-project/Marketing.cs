using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipeline_project
{

    // enum for more easily determining which volume rates to use
    enum Type { basic = 1, expensive, cheap }

    // Class for holding Marketing Objects, Derivative of Item class and inherits IDiscount Interface
    internal class Marketing : Item, IDiscount
    {
        double cost, total;
        Type type;

        // static variables used for displaying total of entire cart
        static double straight, volume, cart;

        // Constructor
        public Marketing(double cost, Type type, string id, string name, int qty)
            : base(id, name, qty)
        {
            this.cost = cost;
            total = cost * qty;
            this.type = type;
        }

        // ToString() Method for displaying information about Marketing objects
        override public string ToString() => $"{base.ToString()} cost {cost:C}, quantity {base.GetQuantity()}";

        // Calculate() uses a rate given to it by DetermineRate() to calculate all possible discounts and add the appropriate totals to static variables
        public void Calculate()
        {
            Console.WriteLine($"\n{ToString()}");
            double volDiscRate = DetermineRate();

            double volDisc = total * (volDiscRate / 100);
            double cartDisc = total * 0.1;

            Console.WriteLine($"Cost with no discount: {total:C}");
            Console.WriteLine($"Volume rate: {volDiscRate:N2}%, discount: {volDisc:C}");
            Console.WriteLine($"Cost after volume discount: {total - volDisc:C}");
            Console.WriteLine($"Whole cart discount: {cartDisc:C}");
            Console.WriteLine($"Cost after cart discount: {total - cartDisc:C}");

            straight += total;
            volume += total - volDisc;
            cart += total - cartDisc;
        }

        // DetermineRate() takes quantity and type to determine what the proper discount rate for the item should be
        public double DetermineRate()
        {
            Console.Write("Discount options:\n   ");
            switch (type)
            {
                // Basic: 20%, 10%, and 5% at 50, 30, and 15 respectively, return 0 if none apply
                case (Type)1:
                    Console.WriteLine("50 at 20.00%, 30 at 10.00%, 15 at 5.00%");
                    if (base.GetQuantity() > 50) { return 20.00; }
                    else if (base.GetQuantity() > 30) { return 10.00; }
                    else if (base.GetQuantity() > 15) { return 5.00; }
                    else { return 0; }
                // Expensive: 12%, 8%, and 3% at 20, 10, and 5 respectively, return 0 if none apply
                case (Type)2:
                    Console.WriteLine("20 at 12.00%, 10 at 8.00%, 5 at 3.00%");
                    if (base.GetQuantity() > 20) { return 12.00; }
                    else if (base.GetQuantity() > 10) { return 8.00; }
                    else if (base.GetQuantity() > 5) { return 3.00; }
                    else { return 0; }
                // Cheap: 20%, 10%, and 5% at 150, 100, and 50 respectively, return 0 if none apply
                case (Type)3:
                    Console.WriteLine("150 at 20.00%, 100 at 10.00%, 50 at 5.00%");
                    if (base.GetQuantity() > 150) { return 20.00; }
                    else if (base.GetQuantity() > 100) { return 10.00; }
                    else if (base.GetQuantity() > 50) { return 5.00; }
                    else { return 0; }
                default:
                    // Return 0 if all else fails, realistically this won't be reached and it is just here to make the compiler happy
                    return 0;
            }
        }

        // Static method DisplayTotal() displays all static variable totals
        static public void DisplayTotal()
        {
            Console.WriteLine($"\nSummary:\n   Straight Cost: {straight:C}\nVolume Discounts: {volume:C}\n   Cart Discount: {cart:C}");
        }
    }
}