using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    class LContainer : Container
    {
        public LContainer( double height, double contWeight, double depth, double maxCapacity) : base( height, contWeight, depth, maxCapacity)
        {
            int serialNumber= counterSNumber;
            counterSNumber += 1;
            SerialNumber = "KON-L-" + serialNumber;
        }

        public bool DangerousCargo { get; set; }
        
        public void loadIn(double weight)
        {
            base.loadIn(weight);
            if (DangerousCargo&&PropertyWeight>MaxCapacity/2)
            {
                DangerousSituation("Dangerous Cargo, capacity over half: "+PropertyWeight+", max available: "+MaxCapacity/2);
            }
            else if(PropertyWeight>MaxCapacity*0.9)
            {
                DangerousSituation("Capacity over 90%: "+PropertyWeight);
            }
        }
        public override string ToString()
        {
            return base.ToString()+"\nDangerous Cargo: "+DangerousCargo;
        }
    }
}
