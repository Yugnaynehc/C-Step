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

namespace OrderTickets
{
    public partial class TicketForm : Window
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        private void purchaseTickets_Click(object sender, RoutedEventArgs e)
        {
            String message = String.Format("Purchasing {0} tickets for {1} customer: {2} for event: {3}", numberOfTickets.Value, privilegeLevel.Text , customerReference.Text, eventList.Text);
            MessageBox.Show(message, "Order Placed");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
