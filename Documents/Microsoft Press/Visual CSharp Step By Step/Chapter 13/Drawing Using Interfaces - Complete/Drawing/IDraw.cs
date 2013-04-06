using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Drawing
{
    interface IDraw
    {
        void SetLocation(int xCoord, int yCoord);
        void Draw(Canvas canvas);
    }
}
