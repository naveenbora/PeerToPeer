using System;
using System.Threading.Tasks;
namespace server1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ChatApp chatApp = new ChatApp();
            chatApp.Start();
        }
    }


}