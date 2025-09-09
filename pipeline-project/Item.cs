using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipeline_project
{
    // Base class Item for classes Shipping and Marketing
    internal class Item
    {
        string id;
        // product name for marketing, destination name for shipping
        string name;
        int quantity;

        // Constructor
        public Item(string id, string name, int quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
        }

        // ToString() method to display basic info about any Marketing or Shipping object
        override public string ToString() => $"{id} {name}:";
        // Simple "Getter" that gets quantity for use in various areas
        public int GetQuantity() => quantity;
    }
}
