using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace muli_AcceptTcp_ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(muli-AcceptTcp) Server is running ... ");
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 104 });
            TcpListener listener = new TcpListener(ip,8500);
            listener.Start();

            while(true){
                //获取一个连接（中断方法）
                TcpClient remoteClient = listener.AcceptTcpClient();

                //打印连接到的客户端信息
                Console.WriteLine("Client Connected! Local:{0} <--Client:{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);
            }
        }
    }
}
