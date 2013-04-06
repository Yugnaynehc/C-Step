using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class ProductInformation : IProductInformation
{
    public decimal HowMuchWillItCost(int productID, int howMany)
    {
        SqlConnection dataConnection = new SqlConnection();
        decimal totalCost = 0;

        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".\\SQLExpress";
            builder.InitialCatalog = "Northwind";
            builder.IntegratedSecurity = true;
            dataConnection.ConnectionString = builder.ConnectionString;
            dataConnection.Open();

            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = "SELECT UnitPrice FROM  Products WHERE ProductID = @ProductID";

            SqlParameter productIDParameter = new SqlParameter("@ProductID", SqlDbType.Int);
            productIDParameter.Value = productID;
            dataCommand.Parameters.Add(productIDParameter);

            decimal? price = dataCommand.ExecuteScalar() as decimal?;
            if (price.HasValue)
            {
                totalCost = price.Value * howMany;
            }
        }
        finally
        {
            dataConnection.Close();
        }

        return totalCost;
    }
}
