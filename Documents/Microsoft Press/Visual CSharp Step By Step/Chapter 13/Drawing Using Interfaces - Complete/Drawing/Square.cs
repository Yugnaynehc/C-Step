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
    class Square : IDraw, IColor
    {
        private int sideLength;
        private int locX, locY = 0;
        private Rectangle rect = null;

        public Square(int sideLength)
        {
            this.sideLength = sideLength;
        }

        void IDraw.SetLocation(int xCoord, int yCoord)
        {
            this.locX = xCoord;
            this.locY = yCoord;
        }

        void IDraw.Draw(Canvas canvas)
        {
            if (this.rect != null)
            {
                canvas.Children.Remove(this.rect);
            }
            else
            {
                this.rect = new Rectangle();
            }

            this.rect.Height = this.sideLength;
            this.rect.Width = this.sideLength;
            Canvas.SetTop(this.rect, this.locY);
            Canvas.SetLeft(this.rect, this.locX);
            canvas.Children.Add(rect);
        }

        void IColor.SetColor(Color color)
        {
            if (rect != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                rect.Fill = brush;
            }
        }
    }
}
