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


namespace Delegates
{
    public partial class ClockWindow : Window
    {
        private LocalClock localClock = null;
        private EuropeanClock londonClock = null;
        private AmericanClock newYorkClock = null;
        private JapaneseClock tokyoClock = null;

        private Controller controller = new Controller();

        public ClockWindow()
        {
            InitializeComponent();
            localClock = new LocalClock(localTimeDisplay);
            londonClock = new EuropeanClock(londonTimeDisplay);
            newYorkClock = new AmericanClock(newYorkTimeDisplay);
            tokyoClock = new JapaneseClock(tokyoTimeDisplay);

            controller.StartClocks += localClock.StartLocalClock;
            controller.StartClocks += londonClock.StartEuropeanClock;
            controller.StartClocks += newYorkClock.StartAmericanClock;
            controller.StartClocks += tokyoClock.StartJapaneseClock;

            controller.StopClocks += localClock.StopLocalClock;
            controller.StopClocks += londonClock.StopEuropeanClock;
            controller.StopClocks += newYorkClock.StopAmericanClock;
            controller.StopClocks += tokyoClock.StopJapaneseClock;
        }

        private void startClick(object sender, RoutedEventArgs e)
        {
            controller.StartClocks();
            start.IsEnabled = false;
            stop.IsEnabled = true;
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            controller.StopClocks();
            start.IsEnabled = true;
            stop.IsEnabled = false;
        }
    }
}