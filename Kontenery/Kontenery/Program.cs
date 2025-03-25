using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontenery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Container> containers = new List<Container>();
            List<Container> containers2 = new List<Container>();
            Random random = new Random();
            for(int i = 0; i < 4; i++)
            {
                containers.Add(new LContainer( 200.0 + random.NextDouble() * 100, 100.0 + random.NextDouble() * 300, 200.0 + random.NextDouble() * 200, 1000.0 + random.NextDouble() * 4000));
                containers.Add(new GContainer( 200.0+random.NextDouble() * 100, 100.0+random.NextDouble() * 300,200.0+random.NextDouble()*200 ,1000.0 + random.NextDouble() * 4000));
                containers.Add(new CContainer( 200.0+random.NextDouble() * 100, 100.0+random.NextDouble() * 300,200.0+random.NextDouble()*200 ,2000.0 + random.NextDouble() * 4000,random.NextDouble()*15));
                containers2.Add(new LContainer(200.0 + random.NextDouble() * 100, 100.0 + random.NextDouble() * 300, 200.0 + random.NextDouble() * 200, 1000.0 + random.NextDouble() * 4000));
                containers2.Add(new GContainer(200.0 + random.NextDouble() * 100, 100.0 + random.NextDouble() * 300, 200.0 + random.NextDouble() * 200, 1000.0 + random.NextDouble() * 4000));
                containers2.Add(new CContainer(200.0 + random.NextDouble() * 100, 100.0 + random.NextDouble() * 300, 200.0 + random.NextDouble() * 200, 1000.0 + random.NextDouble() * 4000, random.NextDouble() * 15));

            }
            Ship ship = new Ship(containers, 12.5, 15, 60.0);           
            Ship ship2 = new Ship(containers2, 12.5, 15, 60.0);

            foreach( var container in ship.Containers)
            {
                if (container.SerialNumber.Contains("C"))
                {
                    ship.LoadInContainer(container, 1000.0, "bananas", 12.2);
                }
                else
                {
                    ship.LoadInContainer(container, random.NextDouble() * 2000);
                }
            }
            foreach (var container in ship2.Containers)
            {
                if (container.SerialNumber.Contains("C"))
                {
                    ship.LoadInContainer(container, 1000.0, "chocolate", 12.2);
                }
                else
                {
                    ship.LoadInContainer(container, random.NextDouble() * 2000);
                }
            }


            Console.WriteLine("ship1: "+ship.ToString());
            Console.WriteLine("----CARGO-----");
            for(int i = 0; i < ship.Containers.Count; i++)
            {
                Console.WriteLine(ship.Containers[i]);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("ship2: " + ship2.ToString());
            Console.WriteLine("----CARGO-----");
            for (int i = 0; i < ship2.Containers.Count; i++)
            {
                Console.WriteLine(ship2.Containers[i]);
                Console.WriteLine("---------------------");
            }

            Container nullableContainer = ship.GetContainer("0");
            Console.WriteLine("==========================");
            if(nullableContainer!= null)
            {
                nullableContainer.loadOut(1000.0);
                Console.WriteLine(nullableContainer);
            }
            Ship.MoveFromTo(ship, ship2, nullableContainer);
            if(ship2.Containers.Exists(c => c.Equals(nullableContainer)))
            {
                Console.WriteLine("teraz na drugim statku");
            }
            ;

        }
    }
    
}
