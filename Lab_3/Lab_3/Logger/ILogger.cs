using System;

namespace ConsoleApp.Logger
{
    interface ILogger : IDisposable
    {
        void Log(params string[] messages);
    }
}