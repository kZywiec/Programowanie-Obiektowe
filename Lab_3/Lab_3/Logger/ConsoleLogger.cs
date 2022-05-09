using System;

namespace ConsoleApp.Logger
{
    class ConsoleLogger : WritterLogger
    {
        public ConsoleLogger() => writer = Console.Out;
        public override void Dispose() => writer.Dispose();
        public override void Log(params string[] messages)
        {
            base.Log(messages);
            for (int i = 0; i < messages.Length; i++)
                writer.Write($"{messages[i]} ");
            writer.Flush();
        }
    }
}