using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace english_showCode
{
    class Program
    {
        private static void ShowCode() {
            string[] strArray = {"b","abcd","甲","甲乙丙丁" };
            byte[] buffer;
            string mode, back;

            foreach(string str in strArray){
                for (int i = 0; i <= 2;i++ )
                {
                    if(i==0){
                        buffer = Encoding.ASCII.GetBytes(str);
                        back = Encoding.ASCII.GetString(buffer,0,buffer.Length);
                        mode = "ASCII";
                    }else if(i==1){
                        buffer = Encoding.UTF8.GetBytes(str);
                        back = Encoding.UTF8.GetString(buffer,0,buffer.Length);
                        mode = "UTF8";
                    }else{
                        buffer = Encoding.Unicode.GetBytes(str);
                        back = Encoding.Unicode.GetString(buffer,0,buffer.Length);
                        mode = "Unicode";
                    }
                    Console.WriteLine("Mode: {0}, String: {1},Buffer.Length: {2}",mode,str,buffer.Length);
                    Console.WriteLine("Buffer:");

                    for (int j = 0; j <= buffer.Length - 1;j++ )
                    {
                        Console.Write(buffer[j]+" ");
                    }
                    Console.WriteLine("\nRetrived: {0}\n",back);
                }
            }
        }
        static void Main(string[] args)
        {
            ShowCode();

            //按Q退出
            Console.WriteLine("\n\n键入字符\"Q\"退出。 ");
            ConsoleKey key;
            do{
                key=Console.ReadKey(true).Key;
            }while(key!=ConsoleKey.Q);
        }
    }
}
