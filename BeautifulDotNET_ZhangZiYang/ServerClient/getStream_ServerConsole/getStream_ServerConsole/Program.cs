using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace getStream_ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //缓存大小，8192字节
            const int BufferSize = 8192;

            Console.WriteLine("(getStream) Server is running ... ");
            IPAddress ip =new IPAddress(new byte[] {192,168,1,103});
            TcpListener listener = new TcpListener(ip,8500);
            
            //开始侦听
            listener.Start();
            Console.WriteLine("Start Listening ... ");

            //获取一个连接， 中断方法
            TcpClient remoteClient = listener.AcceptTcpClient();

            //打印连接到的客户端信息
            Console.WriteLine("Client Connected! Local:{0} <--Client:{1}",remoteClient.Client.LocalEndPoint,remoteClient.Client.RemoteEndPoint);

            //获得流，并写入buffer中
            NetworkStream streamToClient = remoteClient.GetStream();
            byte[] buffer = new byte[BufferSize];
            int bytesRead = streamToClient.Read(buffer, 0, BufferSize);

            //获得请求的字符串
            string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);//从缓存中获取到实际的字符串
            Console.WriteLine("Recived: {0} [{1}bytes]",msg,bytesRead);

            //按Q退出
            Console.WriteLine("\n\n输入\"Q\"键退出。 ");
            ConsoleKey key;
            do{
                key=Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
        }
    }
}


/*“分次读取然后转存”的方式
// 获取字符串
byte[] buffer = new byte[BufferSize];
int bytesRead; // 读取的字节数
MemoryStream ms = new MemoryStream();
do {
bytesRead = streamToClient.Read(buffer, 0, BufferSize);
ms.Write(buffer, 0, bytesRead);
} while (bytesRead > 0);
buffer = msStream.GetBuffer();
string msg = Encoding.Unicode.GetString(buffer);
 */