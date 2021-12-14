using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_9G
{
    struct Baggage
    {
        public Baggage(int numberofthing, double weight)
        {
            numberOfThing = numberofthing;
            Weight = weight;
        }

        public int numberOfThing { get; set; }

        public double Weight { get; set; }
    }
}
