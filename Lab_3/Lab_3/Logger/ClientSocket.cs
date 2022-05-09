using System;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp.Logger
{
    public class ClientSocket : IDisposable
    {
        private bool disposed;
        private Socket socket;

        public ClientSocket(string host, int port)
        {
            disposed = true;
            this.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(host,port);
        }

        ~ClientSocket()
            => this.Dispose();

        public void Send(byte[] buffer)
            => this.socket.Send(buffer, SocketFlags.None);

        public void Send(byte[] buffer, int offset, int size)
            => this.socket.Send(buffer, offset, size, SocketFlags.None);

        public void Receive(byte[] buffer)
            => this.socket.Receive(buffer, SocketFlags.None);

        public void Receive(byte[] buffer, int offset, int size)
            => this.socket.Receive(buffer, offset, size, SocketFlags.None);

        public void Close()
        {
            this.socket.Shutdown(SocketShutdown.Both);
            this.socket.Close();
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.socket.Dispose();
                this.disposed = true;
            }
        }
    }
}