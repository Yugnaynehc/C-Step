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

namespace MathsOperators
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

        private void calculateClick(object sender, RoutedEventArgs e)
        {
            int leftHandSide = int.Parse(lhsOperand.Text);
            int rightHandSide = int.Parse(rhsOperand.Text);
            int answer = doCalculation(leftHandSide, rightHandSide);
            result.Text = answer.ToString();
        }

        private int doCalculation(int leftHandSide, int rightHandSide)
        {
            int result = 0;

            if (addition.IsChecked.HasValue && addition.IsChecked.Value)
                result = addValues(leftHandSide, rightHandSide);
            else if (subtraction.IsChecked.HasValue && subtraction.IsChecked.Value)
                result = subtractValues(leftHandSide, rightHandSide);
            else if (multiplication.IsChecked.HasValue && multiplication.IsChecked.Value)
                result = multiplyValues(leftHandSide, rightHandSide);
            else if (division.IsChecked.HasValue && division.IsChecked.Value)
                result = divideValues(leftHandSide, rightHandSide);
            else if (remainder.IsChecked.HasValue && remainder.IsChecked.Value)
                result = remainderValues(leftHandSide, rightHandSide);

            return result;
        }

        private int addValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = leftHandSide.ToString() + " + " + rightHandSide.ToString();
            return leftHandSide + rightHandSide;
        }

        private int subtractValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = leftHandSide.ToString() + " - " + rightHandSide.ToString();
            return leftHandSide - rightHandSide;
        }

        private int multiplyValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = leftHandSide.ToString() + " * " + rightHandSide.ToString();
            return leftHandSide * rightHandSide;
        }

        private int divideValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = leftHandSide.ToString() + " / " + rightHandSide.ToString();
            return leftHandSide / rightHandSide;
        }

        private int remainderValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = leftHandSide.ToString() + " % " + rightHandSide.ToString();
            return leftHandSide % rightHandSide;
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}