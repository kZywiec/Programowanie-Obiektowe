using System;

namespace ConsoleApp.Logger
{
    public abstract class CommonLogger : ILogger, IDisposable
    {
        ILogger[] loggers { get; set; }

        CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public virtual void Log(params string[] messages)
        {
            // Uzupełnić to miejsce o logikę zapisu opartą o TextWriter ...
        }

        public abstract void Dispose();
    }
}
