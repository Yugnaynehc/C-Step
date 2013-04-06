#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ParamsArray
{
    class Program
    {
        static void DoWork()
        {
            // to do		
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
