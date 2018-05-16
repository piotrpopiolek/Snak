using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Snak
{
    public partial class Form1 : Form
    {
        private static byte[] buffer = new byte[2048];
        private static List<Socket> clientSockets = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            SetupServer();
            InitializeComponent();
        }

        private static void SetupServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            serverSocket.Listen(10);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            MessageBox.Show("Setting up server...");
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            clientSockets.Add(socket);    
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            MessageBox.Show("Client Connected");
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);
                byte[] dataBuf = new byte[received];
                Array.Copy(buffer, dataBuf, received);
                string text = Encoding.ASCII.GetString(dataBuf);
    
                string response = string.Empty;

                if (text.ToLower() != "get time")
                {
                    response = "Invalid Request";
                }
                else
                {
                    response = DateTime.Now.ToLongDateString();
                }

                byte[] data = Encoding.ASCII.GetBytes(response);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                MessageBox.Show("Text received: " + text);
            }
            catch
            {
                MessageBox.Show("Client disconnected");
                socket.Close();
                socket.Dispose();
            }
        }

        private static void SendText(string text)
        {

        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
