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



namespace PrimitiveDataTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void typeSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedType = (type.SelectedItem as ListBoxItem);
            switch (selectedType.Content.ToString())
            {
                case "int":
                    showIntValue();
                    break;
                case "long":
                    showLongValue();
                    break;
                case "float":
                    showFloatValue();
                    break;
                case "double":
                    showDoubleValue();
                    break;
                case "decimal":
                    showDecimalValue();
                    break;
                case "string":
                    showStringValue();
                    break;
                case "char":
                    showCharValue();
                    break;
                case "bool":
                    showBoolValue();
                    break;
            }
        }

        private void showIntValue()
        {
            value.Text = "to do";
        }

        private void showLongValue()
        {
            long variable;
            variable = 42L;
            value.Text = "42L";
        }

        private void showFloatValue()
        {
            float variable;
            variable = 0.42F;
            value.Text = "0.42F";
        }

        private void showDoubleValue()
        {
            value.Text = "to do";
        }

        private void showDecimalValue()
        {
            decimal variable;
            variable = 0.42M;
            value.Text = "0.42M";
        }

        private void showStringValue()
        {
            string variable;
            variable = "42";
            value.Text = "\"forty two\"";
        }

        private void showCharValue()
        {
            char variable;
            variable = '4';
            value.Text = "'x'";
        }

        private void showBoolValue()
        {
            value.Text = "to do";
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}