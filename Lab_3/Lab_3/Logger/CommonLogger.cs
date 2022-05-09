using System;

namespace ConsoleApp.Logger
{
    class CommonLogger : ILogger, IDisposable
    {
        ILogger[] loggers;

        public CommonLogger(ILogger[] loggers)
            => this.loggers = loggers;

        public void Log(params string[] messages)
        {
            for (int i = 0; i < loggers.Length; i++)
                loggers[i].Log(messages);
        }

        public void Dispose() { }
    }
}
