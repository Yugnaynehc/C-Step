using System;
using Extensions;

namespace ExtensionMethod
{
    class Program
    {
        static void DoWork()
        {
            int x = 591;
            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine("{0} in base {1} is {2}", x, i, x.ConvertToBase(i));
            }
        }

        static void Main()
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
