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


namespace Indexers
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

        private void findPhoneClick(object sender, RoutedEventArgs e)
        {
            string text = name.Text;
            if (!String.IsNullOrEmpty(text))
            {
                Name personsName = new Name(text);
                PhoneNumber personsPhoneNumber = this.phoneBook[personsName];
                phoneNumber.Text = personsPhoneNumber.Text;
            }
        }

        private void findNameClick(object sender, RoutedEventArgs e)
        {
            string text = phoneNumber.Text;
            if (!String.IsNullOrEmpty(text))
            {
                PhoneNumber personsPhoneNumber = new PhoneNumber(text);
                Name personsName = this.phoneBook[personsPhoneNumber];
                name.Text = personsName.Text;
            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(phoneNumber.Text))
            {
                phoneBook.Add(new Name(name.Text),
                              new PhoneNumber(phoneNumber.Text));
                name.Text = "";
                phoneNumber.Text = "";
            }
        }

        private PhoneBook phoneBook = new PhoneBook();
    }
}