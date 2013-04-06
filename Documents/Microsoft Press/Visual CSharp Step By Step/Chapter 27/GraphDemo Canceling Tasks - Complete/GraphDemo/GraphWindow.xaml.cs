using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;

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

        private Task first, second, third, fourth;
        private CancellationTokenSource tokenSource = null;
  
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

            Action doPlotButtonWorkAction = new Action(doPlotButtonWork);
            doPlotButtonWorkAction.BeginInvoke(null, null);
        }

        private void doPlotButtonWork()
        {
            int bytesPerPixel = 0;
            plotButton.Dispatcher.Invoke(new Action(() =>
                { bytesPerPixel = (graphBitmap.Format.BitsPerPixel + 7) / 8; }),
                DispatcherPriority.ApplicationIdle);

            int stride = bytesPerPixel * pixelWidth;
            int dataSize = stride * pixelHeight;

            Stopwatch watch = Stopwatch.StartNew();
            Task<byte[]> getDataTask = Task<byte[]>.Factory.StartNew(() => getDataForGraph(dataSize));
            byte[] data = getDataTask.Result;

            plotButton.Dispatcher.Invoke(new Action(() =>
            {
                duration.Content = string.Format("Duration (ms): {0}", watch.ElapsedMilliseconds);
                graphBitmap.WritePixels(new Int32Rect(0, 0, pixelWidth, pixelHeight), data, stride, 0);
                graphImage.Source = graphBitmap;
            }), DispatcherPriority.ApplicationIdle);
        }

        private byte[] getDataForGraph(int dataSize)
        {
            byte[] data = new byte[dataSize];
            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            try
            {
                first = Task.Factory.StartNew(() => generateGraphData(data, 0, pixelWidth / 8, token), token);
                second = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 8, pixelWidth / 4, token), token);
                third = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 4, pixelWidth * 3 / 8, token), token);
                fourth = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth * 3 / 8, pixelWidth / 2, token), token);
                Task.WaitAll(first, second, third, fourth);
                plotButton.Dispatcher.Invoke(new Action(() =>
                {
                    status.Content = "Tasks Completed";
                }), DispatcherPriority.ApplicationIdle);
            }
            catch (AggregateException ae)
            {
                ae.Handle(handleException);
            }

            string message = String.Format("Status of tasks is {0}, {1}, {2}, {3}", first.Status, second.Status, third.Status, fourth.Status);
            MessageBox.Show(message);
            return data;
        }

        private bool handleException(Exception e)
        {
            if (e is TaskCanceledException)
            {
                plotButton.Dispatcher.Invoke(new Action(() =>
                    {
                        status.Content = "Tasks Canceled";
                    }), DispatcherPriority.ApplicationIdle);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void generateGraphData(byte[] data, int partitionStart, int partitionEnd, CancellationToken token)
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
                    token.ThrowIfCancellationRequested();

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

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }
    }
}
