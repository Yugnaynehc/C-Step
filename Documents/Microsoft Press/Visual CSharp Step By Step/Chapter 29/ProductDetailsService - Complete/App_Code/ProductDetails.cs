using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Linq;
using System.Data.SqlClient;
using ProductDetailsContracts;

public class ProductDetails : IProductDetails
{
    public Product GetProduct(string productID)
    {
        int ID = Int32.Parse(productID);

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = ".\\SQLExpress";
        builder.InitialCatalog = "Northwind";
        builder.IntegratedSecurity = true;
        DataContext productsContext = new DataContext(builder.ConnectionString);

        Product product = (from p in productsContext.GetTable<Product>()
                           where p.ProductID == ID
                           select p).First();

        return product;
    }
}
