using System;
using System.Text;

namespace ConsoleApp.Logger
{
    class SocketLogger : ILogger
    {
        ClientSocket clientSocket;
        public SocketLogger(string host, int port) 
            => clientSocket = new ClientSocket(host, port);
        ~SocketLogger() 
            => Dispose();

        public void Dispose() 
            => clientSocket.Dispose();

        public void Log(params string[] messages)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(($"\n{DateTime.Now} : ")));
            for (int i = 0; i < messages.Length; i++)
                clientSocket.Send(Encoding.UTF8.GetBytes($"{messages[i]} "));
        }
    }
}
