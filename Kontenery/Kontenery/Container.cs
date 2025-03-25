using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    abstract class Container
    {
        private static List<int> _containersNumbers = new List<int>();

        public double PropertyWeight { get; set; }
        public double Height { get; }
        public double ContainerWeight { get; }
        public double Depth { get; }
        public string SerialNumber { get; protected set; }
        public double MaxCapacity { get; }
        public Container(double propWeight,double height,double contWeight,double depth,double maxCapacity)
        {
            PropertyWeight = propWeight;
            Height = height;
            ContainerWeight = contWeight;
            Depth = depth;
            MaxCapacity = maxCapacity;
        }
        protected abstract void generateSerialNumber();

        protected int generateNumber()
        {
            Random rand = new Random();
            int number= rand.Next(0,1000);
            for (int i = 0; i < _containersNumbers.Count(); i++)
            {
                if (number == _containersNumbers[i])
                    generateNumber();
            }
            _containersNumbers.Add(number);
            return number;
        }
        public void loadOut()
        {
            PropertyWeight = 0;
        }
        public void loadIn(double weight)
        {
            if (weight + PropertyWeight > MaxCapacity)
                throw new OverfillException();
        }
        



    }
    
}
