using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace server1
{
    public class Conversation
    {
        string myName = null;
        //string otherName = null;
        Socket socket;
        public Conversation(User user, Socket _socket)
        {

            myName = user.Name;
            socket = _socket;
        }
        public void ReadMessages()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = socket.Receive(bytes);
                string message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine(message);
                
            }

        }

        public void WriteMessages()
        {
            while (true)
            {
                string message = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(myName + ">>" + message);
                int bytesSent = socket.Send(msg);
                if (message == "bye")
                {
                    ShutDown();
                    break;
                }
            }

        }
        public void StartChatting()
        {
            Thread threadWrite = new Thread(() => WriteMessages());
            Thread threadRead = new Thread(() => ReadMessages());
            threadWrite.Start();
            threadRead.Start();
        }
        public void ShutDown()
        {
            socket.Shutdown(SocketShutdown.Both);
        }
    }


}