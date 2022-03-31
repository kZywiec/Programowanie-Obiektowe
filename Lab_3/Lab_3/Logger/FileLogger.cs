using System;
using System.IO;

namespace ConsoleApp.Logger
{
    public class FileLogger
    {
        bool disposed { get; set; }
        FileStream stream { get; set; }

        public FileLogger() { }
        public FileLogger(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.Create(path);
        }
            

        public void Dispose() 
        {
            this.disposed = true;
        }
    }
}

