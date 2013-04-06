using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        public void Accelerate()
        {
            Console.WriteLine("Accelerating");
        }

        public void Brake()
        {
            Console.WriteLine("Braking");
        }

        public override void Drive()
        {
            Console.WriteLine("Motoring");
        }
    }
}
