using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    class GContainer : Container
    {
        public GContainer( double height, double contWeight, double depth, double maxCapacity) : base( height, contWeight, depth, maxCapacity)
        {
            int serialNumber = counterSNumber;
            counterSNumber += 1;
            SerialNumber = "KON-G-" + serialNumber;
        }

        public double Pressure { get; set; }
        public override void loadOut(double weight)
        {
            base.loadOut(weight);
            if (PropertyWeight < PropertyWeight * 0.05)
                DangerousSituation("must leave at least 5% : " + PropertyWeight);
        }
        public void loadIn(double weight)
        {
            base.loadIn(weight);
        }
        public override string ToString()
        {
            return base.ToString()+"\nPressure: "+Pressure;
        }
        
    }
}
