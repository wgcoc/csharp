using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AcceptTcp_ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(AcceptTcp) Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] {192,168,1,104});
            TcpListener listener=new TcpListener(ip,8500);
            listener.Start();//开始侦听
            
            //获取一个连接（中断方法）
            TcpClient remoteClient = listener.AcceptTcpClient();

            //打印连接到的客户端信息
            Console.WriteLine("Client Connected! Local:{0} <--Client:{1}",remoteClient.Client.LocalEndPoint,remoteClient.Client.RemoteEndPoint);

            //按Q退出
            Console.WriteLine("\n\n输入\"Q\"键退出。 ");
            ConsoleKey key;
            do{
                key = Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
            
        }
    }
}


/*如何在服务端获得客户端发起的连接信息？ 
也就是说， 在服务端显示已连接的远
程客户端IP地址和端口号
 */