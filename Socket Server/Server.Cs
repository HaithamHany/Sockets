using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Server
{
    class Server
    {
        private const string EOF = "<EOF>";
        private const string CID = "\n";
        public static void ExecuteServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localPoint = new IPEndPoint(ipAddr, 11111);

            //creation of TCP/IP socket using socket class constructor

            Socket listner = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //using bind() method we associate a network address
                // to the server Socket. all clients that will connect to this server socket must know this network address
                listner.Bind(localPoint);

                //using Listen() method we creat client list that will want to connect to server
                listner.Listen(10);
                Console.WriteLine("Server Started.");
                Console.WriteLine("Waiting connection...");
                Socket clientSocket = listner.Accept();

                while (true)
                {

                    //suspend while waiting for incoming connection using accept
                    //the server will accept conection from a client


                    //data buffer
                    byte[] recived_bytes = new byte[1024];
                    string data = null;

                    while (true)
                    {
                        int numByte = clientSocket.Receive(recived_bytes);
                        data += Encoding.ASCII.GetString(recived_bytes, 0, numByte);

                        if (data.IndexOf(EOF) > -1)
                            break;

                    }
                    int indexEOF = data.IndexOf(EOF);
                    int IndexOfId = data.IndexOf(CID);
                   string dataFiltered = data.Substring(0, indexEOF);
                    string clientId = data.Substring(0, IndexOfId);
                    Console.WriteLine( dataFiltered);
                    byte[] server_message = Encoding.ASCII.GetBytes("Test Server is now connected");
                    clientSocket.Send(server_message);

                    //close client Socket using the close() methid. After closing,
                    // we can use the closed socket for a new client connection

                  //clientSocket.Shutdown(SocketShutdown.Both);
                   //clientSocket.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
