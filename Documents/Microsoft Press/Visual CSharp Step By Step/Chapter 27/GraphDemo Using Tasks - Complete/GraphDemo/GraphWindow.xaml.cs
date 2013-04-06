using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GraphDemo
{
    public partial class GraphWindow : Window
    {
        private static ulong availableMemorySize = 0;
        private int pixelWidth = 0;
        private int pixelHeight = 0;
        private double dpiX = 96.0;
        private double dpiY = 96.0;
        private WriteableBitmap graphBitmap = null;
  
        public GraphWindow()
        {
            InitializeComponent();

            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available Bytes");
            availableMemorySize = Convert.ToUInt64(memCounter.NextValue());

            this.pixelWidth = (int)availableMemorySize / 20000;
            if (this.pixelWidth < 0 || this.pixelWidth > 15000)
                this.pixelWidth = 15000;

            this.pixelHeight = (int)availableMemorySize / 40000;
            if (this.pixelHeight < 0 || this.pixelHeight > 7500)
                this.pixelHeight = 7500;
        }

        private void plotButton_Click(object sender, RoutedEventArgs e)
        {
            if (graphBitmap == null)
            {
                graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Gray8, null);
            }
            int bytesPerPixel = (graphBitmap.Format.BitsPerPixel + 7) / 8;
            int stride = bytesPerPixel * pixelWidth;
            int dataSize = stride * pixelHeight;
            byte[] data = new byte[dataSize];
            
            Stopwatch watch = Stopwatch.StartNew();
            //generateGraphData(data);
            Task first = Task.Factory.StartNew(() => generateGraphData(data, 0, pixelWidth / 8));
            Task second = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 8, pixelWidth / 4));
            Task third = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 4, pixelWidth * 3 / 8));
            Task fourth = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth * 3 / 8, pixelWidth / 2));
            Task.WaitAll(first, second, third, fourth);
            
            duration.Content = string.Format("Duration (ms): {0}", watch.ElapsedMilliseconds);
            graphBitmap.WritePixels(new Int32Rect(0, 0, pixelWidth, pixelHeight), data, stride, 0);
            graphImage.Source = graphBitmap;
        }

        private void generateGraphData(byte[] data, int partitionStart, int partitionEnd)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;

            for (int x = partitionStart; x < partitionEnd; x++)
            {
                int s = x * x;
                double p = Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 3)
                {
                    double r = Math.Sqrt(s + i * i) / a;
                    double q = (r - 1) * Math.Sin(24 * r);
                    double y = i / 3 + (q * c);
                    plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                }
            }
        }

        private void plotXY(byte[] data, int x, int y)
        {
            data[x + y * pixelWidth] = 0xFF;
        }
    }
}
