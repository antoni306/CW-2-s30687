using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    abstract class Container : IHazardNotifier
    {
        protected static int counterSNumber = 0;
        public double PropertyWeight { get; set; }
        public double Height { get; }
        public double ContainerWeight { get; }
        public double Depth { get; }
        public string SerialNumber { get; protected set; }
        public double MaxCapacity { get; }
        public Container(double height,double contWeight,double depth,double maxCapacity)
        {
            Height = height;
            ContainerWeight = contWeight;
            Depth = depth;
            MaxCapacity = maxCapacity;

        }

        
        public virtual void loadOut(double weight)
        {
            if(weight<=PropertyWeight)
                PropertyWeight -= weight;
        }
        protected virtual void loadIn(double weight)
        {
            if (weight + PropertyWeight > MaxCapacity)
                //Console.WriteLine("exception: " + (weight + PropertyWeight) + " max " + MaxCapacity);
                //throw new OverfillException();
            PropertyWeight += weight;
        }

        public void DangerousSituation(string m)
        {
            Console.WriteLine(m);
        }
        public override string ToString()
        {
            return "Serial number: " + this.SerialNumber + "\nPropertyWeight: "+PropertyWeight+"\nHeight: "+Height+"\nContainer Weight: "+ContainerWeight+"\nDepth: "+Depth+"\nMax Capacity: "+MaxCapacity;
        }
    }
    
}
