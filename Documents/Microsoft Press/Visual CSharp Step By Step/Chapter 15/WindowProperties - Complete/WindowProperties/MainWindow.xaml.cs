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


namespace WindowProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            sizeChanged();
        }

        private void sizeChanged()
        {
            width.Text = this.ActualWidth.ToString();
            height.Text = this.ActualHeight.ToString();
        }

        private void mainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            sizeChanged();
        }
    }
}