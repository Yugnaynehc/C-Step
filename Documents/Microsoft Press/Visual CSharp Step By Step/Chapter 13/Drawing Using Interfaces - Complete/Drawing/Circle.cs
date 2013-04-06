using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Drawing
{
    class Circle : IDraw, IColor
    {
        private int radius;
        private int locX = 0, locY = 0;
        private Ellipse circle = null;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        void IDraw.SetLocation(int xCoord, int yCoord)
        {
            this.locX = xCoord;
            this.locY = yCoord;
        }

        void IDraw.Draw(Canvas canvas)
        {
            if (this.circle != null)
            {
                canvas.Children.Remove(this.circle);
            }
            else
            {
                this.circle = new Ellipse();
            }

            this.circle.Height = this.radius;
            this.circle.Width = this.radius;
            Canvas.SetTop(this.circle, this.locY);
            Canvas.SetLeft(this.circle, this.locX);
            canvas.Children.Add(circle);
        }


        void IColor.SetColor(Color color)
        {
            if (circle != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                circle.Fill = brush;
            }
        }
    }
}
