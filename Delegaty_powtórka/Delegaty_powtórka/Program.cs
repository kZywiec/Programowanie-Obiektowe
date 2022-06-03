using System;
using System.IO;
using System.Threading;

namespace Delegaty_powtórka
{
    class Program
    {
        static void Main(string[] args)
        {
            var monitor = new FileMonitor(@"D:\Users\krystian.zywiec\Desktop\test.txt");
            monitor.SizeChanged += Monitor_SizeChanger;
            Thread.Sleep(10000);
            monitor.Dispose();
        }
        private static void Monitor_SizeChanger(object sender, EventArgs e)
        {
            Console.WriteLine("Plik uległ zmianie.");
        }
    }

    class FileMonitor : IDisposable
    {
        public event EventHandler SizeChanged;
        private volatile bool looped = true;
        private bool disposeed = false;
        private Thread t;
        public FileMonitor(string path) 
        {
            Thread t = new Thread(() =>
            {
                if (File.Exists(path)) 
                {
                    FileInfo file = new System.IO.FileInfo(path);
                    long previousFileSize = file.Length;
                    while (looped)
                    {
                        long FileSize = file.Length;
                        if (previousFileSize != FileSize)
                            this.SizeChanged?.Invoke(this, new EventArgs());
                    }
                    Thread.Sleep(1000);
                }
            });
            t.Start();
        }

        public void Dispose()
        {
            if (disposeed == false)
            {
                this.looped = false;
                this.t.Join();
                this.disposeed = true;
            }
        }
    }
}
