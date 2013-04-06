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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Data.Objects;

namespace Suppliers
{
    /// <summary>
    /// Interaction logic for SupplierInfo.xaml
    /// </summary>
    public partial class SupplierInfo : Window
    {
        private NorthwindEntities northwindContext = null;
        private Supplier supplier = null;
        private IList productsInfo = null;

        public SupplierInfo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.northwindContext = new NorthwindEntities();            
            suppliersList.DataContext = this.northwindContext.Suppliers;
        }

        private void suppliersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.supplier = suppliersList.SelectedItem as Supplier;
            this.northwindContext.LoadProperty<Supplier>(this.supplier, s => s.Products);
            this.productsInfo = ((IListSource)supplier.Products).GetList();
            productsList.DataContext = this.productsInfo;
        }

        private void productsList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: editProduct(this.productsList.SelectedItem as Product);
                    break;

                case Key.Insert: addnewProduct();
                    break;

                case Key.Delete: deleteProduct(this.productsList.SelectedItem as Product);
                    break;
            }
        }

        private void productsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            editProduct(this.productsList.SelectedItem as Product);
        }

        private void deleteProduct(Product product)
        {
            MessageBoxResult response = MessageBox.Show(
                String.Format("Delete {0}", product.ProductName),
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No);
            if (response == MessageBoxResult.Yes)
            {
                this.northwindContext.Products.DeleteObject(product);
                saveChanges.IsEnabled = true;
            }
        }

        private void addnewProduct()
        {
                ProductForm pf = new ProductForm();
                pf.Title = "New Product for " + supplier.CompanyName;
                if (pf.ShowDialog().Value)
                {
                    Product newProd = new Product();
                    newProd.ProductName = pf.productName.Text;
                    newProd.QuantityPerUnit = pf.quantityPerUnit.Text;
                    newProd.UnitPrice = Decimal.Parse(pf.unitPrice.Text);
                    this.supplier.Products.Add(newProd);
                    this.productsInfo.Add(newProd);
                    saveChanges.IsEnabled = true;
                }
        }

        private void editProduct(Product product)
        {
            ProductForm pf = new ProductForm();
            pf.Title = "Edit Product Details";
            pf.productName.Text = product.ProductName;
            pf.quantityPerUnit.Text = product.QuantityPerUnit;
            pf.unitPrice.Text = product.UnitPrice.ToString();

            if (pf.ShowDialog().Value)
            {
                product.ProductName = pf.productName.Text;
                product.QuantityPerUnit = pf.quantityPerUnit.Text;
                product.UnitPrice = Decimal.Parse(pf.unitPrice.Text);
                saveChanges.IsEnabled = true;
            }
        }

        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.northwindContext.SaveChanges();
                saveChanges.IsEnabled = false;
            }
            catch (OptimisticConcurrencyException)
            {
                this.northwindContext.Refresh(RefreshMode.ClientWins, northwindContext.Products);
                this.northwindContext.SaveChanges();
            }
            catch (UpdateException uEx)
            {
                MessageBox.Show(uEx.InnerException.Message, "Error saving changes");
                this.northwindContext.Refresh(RefreshMode.StoreWins, northwindContext.Products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving changes");
                this.northwindContext.Refresh(RefreshMode.ClientWins, northwindContext.Products);
            }
        }
     }

    [ValueConversion(typeof(string), typeof(Decimal))]
    class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return String.Format("{0:C}", value);
            else
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
