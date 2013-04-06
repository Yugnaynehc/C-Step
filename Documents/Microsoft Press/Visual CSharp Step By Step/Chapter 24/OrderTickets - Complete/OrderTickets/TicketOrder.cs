using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace OrderTickets
{
    enum PrivilegeLevel { Standard, Premium, Executive, PremiumExecutive }

    class TicketOrder
    {
        private string eventName;
        private string customerReference;
        private PrivilegeLevel privilegeLevel;
        private short numberOfTickets;

        private bool checkPrivilegeAndNumberOfTickets(
            PrivilegeLevel proposedPrivilegeLevel,
            short proposedNumberOfTickets)
        {
            bool retVal = false;

            switch (proposedPrivilegeLevel)
            {
                case PrivilegeLevel.Standard:
                    retVal = (proposedNumberOfTickets <= 2);
                    break;

                case PrivilegeLevel.Premium:
                    retVal = (proposedNumberOfTickets <= 4);
                    break;

                case PrivilegeLevel.Executive:
                    retVal = (proposedNumberOfTickets <= 8);
                    break;

                case PrivilegeLevel.PremiumExecutive:
                    retVal = (proposedNumberOfTickets <= 10);
                    break;
            }

            return retVal;
        }

        public override string ToString()
        {
            string formattedString = String.Format("Event: {0}\tCustomer: {1}\tPrivilege: {2}\tTickets: {3}",
                this.eventName, this.customerReference, 
                this.privilegeLevel.ToString(), this.numberOfTickets.ToString());
            return formattedString;
        }

        public PrivilegeLevel PrivilegeLevel
        {
            get { return this.privilegeLevel; }
            set
            {
                this.privilegeLevel = value;
                if (!this.checkPrivilegeAndNumberOfTickets(value, this.numberOfTickets))
                {
                    throw new ApplicationException(
                        "Privilege level too low for this number of tickets");
                }
            }
        }

        public short NumberOfTickets
        {
            get { return this.numberOfTickets; }
            set
            {
                this.numberOfTickets = value;
                if (!this.checkPrivilegeAndNumberOfTickets(this.privilegeLevel, value))
                {
                    throw new ApplicationException(
                        "Too many tickets for this privilege level");
                }

                if (this.numberOfTickets <= 0)
                {
                    throw new ApplicationException(
                        "You must buy at least one ticket");
                }
            }
        }

        public string EventName
        {
            get { return this.eventName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify an event");
                }
                else
                {
                    this.eventName = value;
                }
            }
        }
        
        public string CustomerReference
        {
            get { return this.customerReference; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify the customer reference number");
                }
                else
                {
                    this.customerReference = value;
                }
            }
        }
    }

    [ValueConversion(typeof(string), typeof(PrivilegeLevel))]
    public class PrivilegeLevelConverter : IValueConverter
    {
        public object  Convert(object value, Type targetType, object parameter, 
                               System.Globalization.CultureInfo culture)
        {
         	PrivilegeLevel privilegeLevel = (PrivilegeLevel)value;
            string convertedPrivilegeLevel = String.Empty;

            switch (privilegeLevel)
            {
                case PrivilegeLevel.Standard:
                    convertedPrivilegeLevel = "Standard";
                    break;

                case PrivilegeLevel.Premium:
                    convertedPrivilegeLevel = "Premium";
                    break;

                case PrivilegeLevel.Executive:
                    convertedPrivilegeLevel = "Executive";
                    break;

                case PrivilegeLevel.PremiumExecutive:
                    convertedPrivilegeLevel = "Premium Executive";
                    break;
            }

            return convertedPrivilegeLevel;
        }

        public object  ConvertBack(object value, Type targetType, object parameter, 
                                   System.Globalization.CultureInfo culture)
        {
         	PrivilegeLevel privilegeLevel = PrivilegeLevel.Standard;

            switch ((string)value)
            {
                case "Standard":
                    privilegeLevel = PrivilegeLevel.Standard;
                    break;

                case "Premium":
                    privilegeLevel = PrivilegeLevel.Premium;
                    break;

                case "Executive":
                    privilegeLevel = PrivilegeLevel.Executive;
                    break;

                case "Premium Executive":
                    privilegeLevel = PrivilegeLevel.PremiumExecutive;
                    break;
            }

            return privilegeLevel;
        }
    }
}
