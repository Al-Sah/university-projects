using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace server
{
    public class ConnectionManager
    {
        private const int Port = 8089;
        private const string Localhost = "127.0.0.1";

        public byte[] Data { get; private set; }
        public bool Run { get; set; }

        public event Action ConnectionStateChanged;
        public event Action DataReceived;

        private readonly TcpListener _server;
        private TcpClient _client;

        public string ConnectionState { get; private set; }

        public ConnectionManager()
        {
            _server = new TcpListener(IPAddress.Parse(Localhost), Port);
        }
        public void Start()
        {
            try
            {
                _server.Start();
                while(Run)
                {
                    ConnectionState = "Waiting for a connection... ";
                    ConnectionStateChanged?.Invoke();
                    _client = _server.AcceptTcpClient();
                    ConnectionState = "Connected";
                    ConnectionStateChanged?.Invoke();
                    
                    var bytes = new byte[256];
                    try
                    {
                        // Loop to receive all the data sent by the client.
                        while(Run && _client.GetStream().Read(bytes, 0, bytes.Length)!=0)
                        {
                            Data = bytes;
                            DataReceived?.Invoke();
                            _client.GetStream().Flush();
                        }
                    }
                    catch (Exception)
                    {
                        ConnectionState = "Error; Client shutdown ? ";
                        ConnectionStateChanged?.Invoke();
                    }
                    
                }
            }
            catch(SocketException e)
            {
                Debug.WriteLine($"SocketException: {e}");
            }
            finally
            {
                _server.Stop();
            }
        }

        public void Stop()
        {
            Run = false;
            if (_client != null)
            {
                try
                {
                    _client.GetStream().Flush();
                    _client.GetStream().Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            _server.Stop();
        }
    }
}