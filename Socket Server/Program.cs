using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Socket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            #region old server code
            //IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            //TcpListener server = new TcpListener(ip, 8080);
            //TcpClient client = default(TcpClient);
            //List<TcpClient> clients = new List<TcpClient>();

            //try
            //{
            //    server.Start();
            //    Console.WriteLine("Server started ...");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    Console.Read();
            //}

            //while(true)
            //{
            //    client = server.AcceptTcpClient();

            //    if(!clients.Contains(client))
            //        clients.Add(client);

            //    byte[] recivedBuffer = new byte[1000];
            //    NetworkStream stream = client.GetStream();

            //    stream.Read(recivedBuffer,0 , recivedBuffer.Length);

            //    //string msg = Encoding.ASCII.GetString(recivedBuffer, 0, recivedBuffer.Length);

            //    StringBuilder msg = new StringBuilder();
            //    foreach (byte b in recivedBuffer)
            //    {
            //        //59 is the ascii code for the Semicolon 00 is for null
            //        if (b.Equals(00)) 
            //            break;
            //        else
            //            msg.Append(Convert.ToChar(b).ToString());
            //    }

            //    Console.WriteLine(msg.ToString());

            //}
            #endregion

            Server.ExecuteServer();
        }
    }
}
