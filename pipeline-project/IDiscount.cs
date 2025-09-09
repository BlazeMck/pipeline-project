using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pipeline_project
{

    internal interface IDiscount
    {
        // Used to calculate and display each possible total for that object
        void Calculate();
        // Used to determine what the discount/shipping rate will be for that object
        double DetermineRate();
    }
}
