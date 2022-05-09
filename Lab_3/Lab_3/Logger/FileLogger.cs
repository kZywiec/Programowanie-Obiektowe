using System;
using System.IO;
using System.Text;


namespace ConsoleApp.Logger
{
    class FileLogger : WritterLogger
    {
        private bool disposed;

        protected FileStream stream;

        public FileLogger(string path)
        {
            stream = new FileStream(path,FileMode.Append);
            writer = new StreamWriter(stream, Encoding.UTF8);
            disposed = true;
        }

        ~FileLogger() => Dispose();
        public override void Dispose() 
        {
            if (disposed) 
            {
                writer.Flush();
                stream.Dispose();
                writer.Dispose();
            } 
        }

        public override void Log(params string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
                writer.Write($"{messages[i]} ");
            writer.Flush();
        }
    }
}

