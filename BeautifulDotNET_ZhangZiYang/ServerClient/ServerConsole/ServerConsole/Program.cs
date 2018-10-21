using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] {192,168,1,104});
            TcpListener listener = new TcpListener(ip,8500);
            listener.Start();
            Console.WriteLine("Start Lisarting ... ");
            Console.WriteLine("\n\n输入\"Q\"键退出。 ");
            ConsoleKey key;
            do{
                key = Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
        }
    }
}

/*
获得IPAddress对象的另外几种常用方法：
IPAddress ip = IPAddress.Parse("192.168.1.104");
IPAddress ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
 * 
运行上面的程序， 然后打开“cmd命令提示符”， 输入"netstat-a"， 
可以看到计算机器中所有活动连接的状态。 从中找到8500
端口， 看到它的状态是LISTENING， 说明它已经
开始了侦听
 */