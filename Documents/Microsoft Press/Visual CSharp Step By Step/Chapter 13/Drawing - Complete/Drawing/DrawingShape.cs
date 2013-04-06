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
    abstract class DrawingShape
    {
        protected int size;
        protected int locX = 0, locY = 0;
        protected Shape shape = null;

        public DrawingShape(int size)
        {
            this.size = size;
        }

        public void SetLocation(int xCoord, int yCoord)
        {
            this.locX = xCoord;
            this.locY = yCoord;
        }

        public void SetColor(Color color)
        {
            if (shape != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                shape.Fill = brush;
            }
        }

        public virtual void Draw(Canvas canvas)
        {
            if (this.shape == null)
            {
                throw new ApplicationException("Shape is null");
            }

            this.shape.Height = this.size;
            this.shape.Width = this.size;
            Canvas.SetTop(this.shape, this.locY);
            Canvas.SetLeft(this.shape, this.locX);
            canvas.Children.Add(shape);
        }
    }
}
