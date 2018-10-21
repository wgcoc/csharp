using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace postback_getStream_dowhile_ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BufferSize = 8192; //缓存大小，8192字节
            Console.WriteLine("Server is running ... ");

            IPAddress ip = new IPAddress(new byte[] {192,168,1,103});
            TcpListener listener = new TcpListener(ip,8500);
            listener.Start();// 开始侦听
            Console.WriteLine("Start Listening ... ");

            // 获取一个连接， 中断方法
            TcpClient remoteClient = listener.AcceptTcpClient();
            // 打印连接到的客户端信息
            Console.WriteLine("Client Connected! Local:{0} <-Client:{1}",remoteClient.Client.LocalEndPoint,remoteClient.Client.RemoteEndPoint);

            //获得流
            NetworkStream streamToClient = remoteClient.GetStream();

            do{
                try {
                    byte[] buffer=new byte[BufferSize];
                    int bytesRead=streamToClient.Read(buffer,0,BufferSize);
                    if(bytesRead==0){
                        Console.WriteLine("Client offline");
                        break;
                    }

                    //获得请求的字符串
                    string msg=Encoding.Unicode.GetString(buffer,0,BufferSize);
                    Console.WriteLine("Recived: {0} [{1} bytes]",msg,bytesRead);

                    //转换成大写并发送
                    msg=msg.ToUpper();
                    buffer=Encoding.Unicode.GetBytes(msg);
                    streamToClient.Write(buffer,0,buffer.Length);
                    Console.WriteLine("Send: {0}",msg);
                }catch(Exception ex){
                    Console.WriteLine(ex.Message);
                    break;
                }
            }while(true);

            streamToClient.Dispose();
            remoteClient.Close();

            //按Q退出
            Console.WriteLine("\n\n输入\"Q\"键退出。 ");
            ConsoleKey key;
            do{
                key=Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
        }
    }
}
