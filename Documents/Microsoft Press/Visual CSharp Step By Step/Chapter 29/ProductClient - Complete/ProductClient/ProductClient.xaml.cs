using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductClient.ProductInformationService;
using System.ServiceModel;
using ProductDetailsContracts;

namespace ProductClient
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        private void calcCost_Click(object sender, RoutedEventArgs e)
        {
            ProductInformationClient proxy = new ProductInformationClient();
            try
            {
                int prodID = Int32.Parse(productID.Text);
                int numberRequired = Int32.Parse(howMany.Text);
                decimal cost = proxy.HowMuchWillItCost(prodID, numberRequired);
                totalCost.Content = String.Format("{0:C}", cost);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obtaining cost: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    proxy.Abort();
                }
                else
                {
                    proxy.Close();
                }
            }
        }

        private void getProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductClientProxy proxy = new ProductClientProxy();
            try
            {
                Product product = proxy.GetProduct(productID.Text);
                productName.Content = product.ProductName;
                supplierID.Content = product.SupplierID.Value;
                categoryID.Content = product.CategoryID.Value;
                quantityPerUnit.Content = product.QuantityPerUnit;
                unitPrice.Content = String.Format("{0:C}", product.UnitPrice.Value);
                unitsInStock.Content = product.UnitsInStock.Value;
                unitsOnOrder.Content = product.UnitsOnOrder.Value;
                reorderLevel.Content = product.ReorderLevel.Value;
                discontinued.IsChecked = product.Discontinued;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching product details: " + ex.Message,
                   "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (proxy.State == CommunicationState.Faulted)
                {
                    proxy.Abort();
                }
                else
                {
                    proxy.Close();
                }
            }
        }
    }
}
