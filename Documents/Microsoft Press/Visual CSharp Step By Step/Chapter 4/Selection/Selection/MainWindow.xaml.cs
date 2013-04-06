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

namespace Selection
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            first.Text = DateTime.Today.ToString();
            second.Text = DateTime.Today.ToString();
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void compareClick(object sender, RoutedEventArgs e)
        {
            int diff = dateCompare(first.SelectedDate.Value, second.SelectedDate.Value);
            info.Text = "";
            show("first == second", diff == 0);
            show("first != second", diff != 0);
            show("first <  second", diff < 0);
            show("first <= second", diff <= 0);
            show("first >  second", diff > 0);
            show("first >= second", diff >= 0);
        }

        private void show(string exp, bool result)
        {
            info.Text += exp;
            info.Text += " : " + result.ToString();
            info.Text += "\r\n";
        }

        private int dateCompare(DateTime leftHandSide, DateTime rightHandSide)
        {
            // TO DO
            return 42;
        }
    }
}
