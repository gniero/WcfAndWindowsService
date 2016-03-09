using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndWindowsService
{
    [DataContract]
    public class DullResult
    {
        public DullResult(int multiplier, int multiplicand, int product)
        {
            Multiplier = multiplier;
            Multiplicand = multiplicand;
            Product = product;
        }

        [DataMember]
        public int Multiplier { get; private set; }

        [DataMember]
        public int Multiplicand { get; private set; }

        [DataMember]
        public int Product { get; private set; }
    }
}
