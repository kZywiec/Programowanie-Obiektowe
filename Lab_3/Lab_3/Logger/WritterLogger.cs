using System;
using System.IO;

namespace ConsoleApp.Logger
{
    abstract class WritterLogger : ILogger
    {
        protected TextWriter writer;

        public virtual void Log(params string[] messages)
        {
            writer.Write($"\n{DateTime.Now}: ");
        }

        public abstract void Dispose();
    }
}
