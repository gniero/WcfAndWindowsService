using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndWindowsService
{
    public class DullResult
    {
        public DullResult(int multiplier, int multiplicand, int product)
        {
            Multiplier = multiplier;
            Multiplicand = multiplicand;
            Product = product;
        }

        public int Multiplier { get; private set; }
        public int Multiplicand { get; private set; }
        public int Product { get; private set; }
    }
}
