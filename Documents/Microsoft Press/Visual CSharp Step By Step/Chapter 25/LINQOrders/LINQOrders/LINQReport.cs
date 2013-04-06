using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;

namespace LINQOrders
{
    class LINQReport
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".\\SQLExpress";
            builder.InitialCatalog = "Northwind";
            builder.IntegratedSecurity = true;

            Northwind northwindDB = new Northwind(builder.ConnectionString);

            try
            {
                Console.Write("Please enter a customer ID (5 characters): ");
                string customerId = Console.ReadLine();

                var ordersQuery = from o in northwindDB.Orders
                                  where String.Equals(o.CustomerID, customerId)
                                  select o;

                foreach (var order in ordersQuery)
                {
                    if (order.ShippedDate == null)
                    {
                        Console.WriteLine("Order {0} not yet shipped\n\n", order.OrderID);
                    }
                    else
                    {
                        Console.WriteLine("Order: {0}\nPlaced: {1}\nShipped: {2}\n" +
                                          "To Address: {3}\n{4}\n{5}\n{6}\n\n", order.OrderID,
                                          order.OrderDate, order.ShippedDate, order.ShipName,
                                          order.ShipAddress, order.ShipCity,
                                          order.ShipCountry);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error accessing the database: {0}", e.Message);
            }
        }
    }

    [Table(Name = "Orders")]
    public class Order
    {
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int OrderID { get; set; }

        [Column]
        public string CustomerID { get; set; }

        [Column]
        public DateTime? OrderDate { get; set; }

        [Column]
        public DateTime? ShippedDate { get; set; }

        [Column]
        public string ShipName { get; set; }

        [Column]
        public string ShipAddress { get; set; }

        [Column]
        public string ShipCity { get; set; }

        [Column]
        public string ShipCountry { get; set; }
    }

    public class Northwind : DataContext
    {
        public Table<Order> Orders;

        public Northwind(string connectionInfo)
            : base(connectionInfo)
        {
        }
    }
}
