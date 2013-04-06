#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace StructsAndEnums
{
    class Program
    {
        static void DoWork()
        {
            //Month first = Month.December;
            //Console.WriteLine(first);
            //first++;
            //Console.WriteLine(first);

            //Date defaultDate = new Date();
            //Console.WriteLine(defaultDate);
            Date weddingAnniversary = new Date(2010, Month.July, 4);
            Console.WriteLine(weddingAnniversary);
            Date weddingAnniversaryCopy = weddingAnniversary;
            Console.WriteLine("Value of copy is {0}", weddingAnniversaryCopy);
            weddingAnniversaryCopy.AdvanceMonth();
            Console.WriteLine("New value of weddingAnniversary is {0}", weddingAnniversary);
            Console.WriteLine("Value of copy is {0}", weddingAnniversaryCopy);
        }

        static void Main()
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
