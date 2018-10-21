using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace recvfromserver_getStream_dowhile_ClientConsle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client is running ... ");
            TcpClient client;
            const int BufferSize = 8192;

            try {
                client=new TcpClient();
                // 与服务器建立连接
                client.Connect(IPAddress.Parse("192.168.1.103"),8500);
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return;
            }

            //打印连接到的服务端信息
            Console.WriteLine("Server Connected! Local:{0} -->Server:{1}",client.Client.LocalEndPoint,client.Client.RemoteEndPoint);
            NetworkStream streamToServer = client.GetStream();

            string msg;
            do{
                Console.Write("Send:");
                msg=Console.ReadLine();
                if(!String.IsNullOrEmpty(msg) && msg!="Q"){
                    byte[] buffer=Encoding.Unicode.GetBytes(msg);
                    try{
                        //发往服务器
                        streamToServer.Write(buffer,0,buffer.Length);

                        int bytesRead;
                        buffer=new byte[BufferSize];
                        //接收并显示服务器回传的字符串
                        bytesRead=streamToServer.Read(buffer,0,BufferSize);
                        if(bytesRead==0){
                            Console.WriteLine("Server offline");
                            break;
                        }
                        msg=Encoding.Unicode.GetString(buffer,0,bytesRead);
                        Console.WriteLine("Recived: {0} [{1} bytes]",msg,bytesRead);
                    }catch(Exception ex){
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }
            }while(msg!="Q");
            streamToServer.Dispose();
            client.Close();
        }
    }
}
