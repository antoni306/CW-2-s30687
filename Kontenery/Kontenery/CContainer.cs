using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    class CContainer : Container
    {
        public CContainer( double height, double contWeight, double depth, double maxCapacity,double temp) : base( height, contWeight, depth, maxCapacity)
        {
            int serialNumber = counterSNumber;
            counterSNumber += 1;
            SerialNumber = "KON-C-" + serialNumber;
            Temperature = temp;
        }
        public String ProductCategory { get; set; }
        public double ProductMaxTemp { get; set; }
        public double Temperature { get; set; }
        public void  loadIn(string category,double temp,double weight)
        {
            if (string.IsNullOrEmpty(ProductCategory))
                ProductCategory = category;
            if (category != ProductCategory)
            {
                DangerousSituation("Cannot load that product: " + category + ", only " + ProductCategory + " can be loaded");
            }
            else
            {
                if (temp < Temperature)
                {
                    DangerousSituation("Temperature higher then allowed");
                }
                else
                {
                    base.loadIn(weight);
                }

            }
        }
        

        public override string ToString()
        {
            string val= base.ToString();
            return val + "\nProductCategory: " + ProductCategory +"\nMax temp: "+ProductMaxTemp+ "\nTemperature: " + Temperature;
        }
    }
}
