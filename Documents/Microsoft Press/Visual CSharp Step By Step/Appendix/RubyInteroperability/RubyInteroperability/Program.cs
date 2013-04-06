using System;
using IronRuby;

namespace RubyInteroperability
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating IronRuby objects
            Console.WriteLine("Testing Ruby");
            dynamic ruby = Ruby.CreateRuntime().UseFile(@"..\..\..\..\CustomerDB.rb");
            dynamic rubyCustomer = ruby.GetNewCustomer(100, "Fred", "888");
            dynamic rubyCustomerDB = ruby.GetCustomerDB();
            rubyCustomerDB.storeCustomer(rubyCustomer);
            rubyCustomer = ruby.GetNewCustomer(101, "Sid", "999");
            rubyCustomerDB.storeCustomer(rubyCustomer);
            Console.WriteLine("{0}", rubyCustomerDB);
            Console.WriteLine();
        }
    }
}
