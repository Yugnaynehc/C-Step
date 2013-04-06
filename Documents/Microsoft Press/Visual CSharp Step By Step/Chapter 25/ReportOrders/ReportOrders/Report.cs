using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ReportOrders
{
    class Report
    {
        static void Main(string[] args)
        {
            SqlConnection dataConnection = new SqlConnection();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = ".\\SQLExpress";
                builder.InitialCatalog = "Northwind";
                builder.IntegratedSecurity = true;
                dataConnection.ConnectionString = builder.ConnectionString;
                dataConnection.Open();

                Console.Write("Please enter a customer ID (5 characters): ");
                string customerId = Console.ReadLine();

                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText =
                    "SELECT OrderID, OrderDate, ShippedDate, ShipName, ShipAddress, " +
                    "ShipCity, ShipCountry " +
                    "FROM Orders WHERE CustomerID = @CustomerIdParam";

                SqlParameter param = new SqlParameter("@CustomerIdParam", SqlDbType.Char, 5);
                param.Value = customerId;
                dataCommand.Parameters.Add(param);

                Console.WriteLine("About to find orders for customer {0}\n\n", customerId);
                SqlDataReader dataReader = dataCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    int orderId = dataReader.GetInt32(0);
                    if (dataReader.IsDBNull(2))
                    {
                        Console.WriteLine("Order {0} not yet shipped\n\n", orderId);
                    }
                    else
                    {
                        DateTime orderDate = dataReader.GetDateTime(1);
                        DateTime shipDate = dataReader.GetDateTime(2);
                        string shipName = dataReader.GetString(3);
                        string shipAddress = dataReader.GetString(4);
                        string shipCity = dataReader.GetString(5);
                        string shipCountry = dataReader.GetString(6);
                        Console.WriteLine(
                            "Order: {0}\nPlaced: {1}\nShipped: {2}\n" +
                            "To Address: {3}\n{4}\n{5}\n{6}\n\n", orderId, orderDate,
                            shipDate, shipName, shipAddress, shipCity, shipCountry);
                    }
                }

                dataReader.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error accessing the database: {0}", e.Message);
            }
            finally
            {
                dataConnection.Close();
            }
        }
    }
}
