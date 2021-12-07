using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace client
{
    public class ConnectionManager : IDisposable
    {
        
        private const int Port = 8089;
        private const string Server = "127.0.0.1";
        private readonly TcpClient _client;
        
        public event Action ConnectionStateChanged;
        public string ConnectionDetails { get; private set; }
        public bool Connected { get; private set; }
        public bool TryConnect { get; set; }

        public ConnectionManager()
        {
            TryConnect = true;
            _client = new TcpClient();
        }

        public void HandleConnection()
        {
            while (TryConnect)
            {
                
                if (_client.Client.Connected)
                {
                    
                    Thread.Sleep(500);
                }
                else
                {
                    try
                    {
                        _client.Connect(Server, Port);
                        ConnectionDetails = $"Connected ...  Server {Server}; Port {Port}";
                        Connected = true;
                    }
                    catch (SocketException e)
                    {
                        Debug.WriteLine($"SocketException: {e}");
                        Connected = false;
                        ConnectionDetails = "Failed; Last try: " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        ConnectionStateChanged?.Invoke();
                    }
                }
            }
        }

        public void SendMessage(byte[] colour)
        {
            try
            {
                _client.GetStream().Write(colour, 0, colour.Length);
            }
            catch (IOException)
            {
                Connected = false;
                ConnectionDetails = "Failed; Last try: " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                ConnectionStateChanged?.Invoke();
            }
           
        }


        public void Dispose()
        {
            TryConnect = false;
            _client.Close();
        }
    }
}