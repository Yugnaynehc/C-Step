#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Program
    {
        static void DoWork()
        {
            Point origin = new Point();
            Point bottomRight = new Point(1024, 1280);
            double distance = origin.DistanceTo(bottomRight);
            Console.WriteLine("Distance is: {0}", distance);
            Console.WriteLine("No of Point objects: {0}", Point.ObjectCount());
        }

        static void Main(string[] args)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
