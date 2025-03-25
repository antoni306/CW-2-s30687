using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    class Ship
    {
        public Ship(List<Container> containers, double speed, int capacity, double weightCapacity)
        {
            if (containers.Count <= capacity)
            {
                double weight = 0.0;
                foreach (var container in containers)
                {
                    weight += container.ContainerWeight + container.PropertyWeight;
                }
                if (weight/1000 <= weightCapacity)
                {
                    Containers = containers;
                    Weight = weight / 1000;
                }
                else
                {
                    Console.WriteLine("Too heavy");
                    Containers = new List<Container>();
                }
            }
            else
                Console.WriteLine("Too many containers");
            Speed = speed;
            Capacity = capacity;
            WeightCapacity = weightCapacity;
        }

        public List<Container> Containers { get; private set; } 
        public double Speed { get; }
        public int Capacity { get; }
        public double WeightCapacity { get; }
        public double Weight { get; set; }
        public void ChangeContainer(Container container,String serialNumber)
        {
            bool removed = Containers.Remove(Containers.Find((con) => con.SerialNumber.Equals(serialNumber)));
            if (!removed)
                Console.WriteLine("No such container on the ship: " + serialNumber);
            else
                Containers.Add(container);
        }
        public void addContainer(Container container)
        {
            if (!Containers.Exists(c => c.SerialNumber == container.SerialNumber))
            {
                if (TooHeavy(container))
                    Console.WriteLine("Too Heavy");
                else
                {
                    Containers.Add(container);
                    Weight += container.ContainerWeight + container.PropertyWeight;
                }
            }
            else
                Console.WriteLine("Already on the ship");
        }
        private bool TooHeavy(Container container)
        {
            if ((Weight + container.ContainerWeight + container.PropertyWeight)/1000 > WeightCapacity)
            {
                return true;

            }
            else
                return false;
        }
        public Container GetContainer(String containerNumber)
        {
            if(Containers.Exists(c => c.SerialNumber.Contains(containerNumber)))
            {
                return Containers.Find(c => c.SerialNumber.Contains(containerNumber));
            }
            return null;
        }
        public void LoadInContainer(Container container,double weight,string category="no category",double temp=0.0)
        {
            if (category != "no category")
            {
                ((CContainer)container).loadIn(category, temp, weight);
            }
            else if (container is LContainer l)
            {
                ((LContainer)container).loadIn(weight);
            }
            else
                ((GContainer)container).loadIn(weight);
            Weight += (container.ContainerWeight + container.PropertyWeight)/1000;
        }
        public void RemoveContainer(Container container)
        {
            if (Containers.Remove(container))
                Console.WriteLine("succesfully removed container: " + container.SerialNumber);
            else
                Console.WriteLine("No such container on the ship");
        }
        public static void MoveFromTo(Ship ship1,Ship ship2,Container container)
        {
            ship1.RemoveContainer(container);
            ship2.addContainer(container);
        }
        public override string ToString()
        {
            return "Speed: " + Speed + "\nCapacity: "+Capacity+"\nWeight capacity: "+WeightCapacity+"\nCargo weight: "+Weight+"\nContainers: "+Containers.Count;
        }
    }
}
