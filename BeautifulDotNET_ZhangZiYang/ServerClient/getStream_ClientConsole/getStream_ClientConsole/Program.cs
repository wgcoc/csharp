using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace getStream_ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client is running ... ");
            TcpClient client;

            try
            {
                client = new TcpClient();
                //与服务器建立连接
                client.Connect(IPAddress.Parse("192.168.1.104"),8500);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //打印连接到的服务端信息
            Console.Write("Server Connected! Local:{0} -->Server:{1}",client.Client.LocalEndPoint,client.Client.RemoteEndPoint);

            string msg = "hello, readers! I am wgco.";
            NetworkStream streamToServer = client.GetStream();
            byte[] buffer = Encoding.Unicode.GetBytes(msg);//获得缓存
            streamToServer.Write(buffer, 0, buffer.Length);//发往服务器
            Console.WriteLine("Send: {0}",msg);

            //按Q退出
            Console.WriteLine("\n\n输入\"Q\"键退出。 ");
            ConsoleKey key;
            do{
                key=Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
        }
    }
}
