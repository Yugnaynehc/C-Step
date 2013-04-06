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
            BindingExpression eventBe =
                eventList.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression customerReferenceBe =
                customerReference.GetBindingExpression(TextBox.TextProperty);
            BindingExpression privilegeLevelBe =
                privilegeLevel.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression numberOfTicketsBe =
                numberOfTickets.GetBindingExpression(Slider.ValueProperty);

            eventBe.UpdateSource();
            customerReferenceBe.UpdateSource();
            privilegeLevelBe.UpdateSource();
            numberOfTicketsBe.UpdateSource();

            if (eventBe.HasError || customerReferenceBe.HasError ||
                privilegeLevelBe.HasError || numberOfTicketsBe.HasError)
            {
                MessageBox.Show("Please correct errors", "Purchase aborted");
            }
            else
            {
                Binding ticketOrderBinding =
                    BindingOperations.GetBinding(privilegeLevel, ComboBox.TextProperty);
                TicketOrder ticketOrder = ticketOrderBinding.Source as TicketOrder;
                MessageBox.Show(ticketOrder.ToString(), "Purchased");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
