using System;
using System.Net;
using System.Net.Sockets;
namespace server1
{
    public class Network
    {
        private IPAddress _iPAddress;
        private IPEndPoint _iPEndPoint;
        private Socket _sender;
        public Network(User user)
        {
            _iPAddress = IPAddress.Parse(user.IpAddress);
            _iPEndPoint = new IPEndPoint(_iPAddress, user.Port);
            _sender = new Socket(_iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }


        public Socket EstablishConnection()
        {
            try
            {
                _sender.Connect(_iPEndPoint);
                Console.WriteLine("Start a conversation");
                return _sender;
            }
            catch (Exception)
            {
                _sender = new Socket(_iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _sender.Bind(_iPEndPoint);
                _sender.Listen(10);
                Console.WriteLine("Start a conversation");
                return _sender.Accept();
            }
        }


    }


}