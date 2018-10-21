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
                client.Connect(IPAddress.Parse("192.168.1.103"), 8500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //打印连接到的服务端信息
            Console.Write("Server Connected! Local:{0} -->Server:{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            NetworkStream streamToServer = client.GetStream();
            string msg;

            do{
                //try{
                    Console.Write("Send:");
                    msg = Console.ReadLine();
                    if (!String.IsNullOrEmpty(msg) && msg != "Q")
                    {
                        byte[] buffer = Encoding.Unicode.GetBytes(msg);
                        try
                        {
                            //发往服务器
                            streamToServer.Write(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    }
                //}catch(Exception ex){
                //    Console.WriteLine(ex.Message);
                //}
            }while(msg!="Q");
        }
    }
}
