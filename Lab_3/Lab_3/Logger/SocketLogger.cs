using System;
using System.IO;

namespace ConsoleApp.Logger
{
    public class SocketLogger : ClientSocket
    {
        ClientSocket clientSocket { get; set; }

        public SocketLogger() {}
        public SocketLogger(string host, int port) 
        { 
            this.clientSocket =new ClientSocket( host, port);
        }

        public virtual void Log(params string[] messages)
        {
            // Uzupełnić to miejsce o logikę zapisu opartą o TextWriter ...
        }
    }
}
