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

namespace Suppliers
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Window
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.productName.Text))
            {
                MessageBox.Show("The product must have a name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal result;
            if (!Decimal.TryParse(this.unitPrice.Text, out result))
            {
                MessageBox.Show("The price must be a valid number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (result < 0)
            {
                MessageBox.Show("The price must not be less than zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
        }
    }
}
