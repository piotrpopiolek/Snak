using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Snak_Klient
{
    public partial class Form1 : Form
    {
        private int serwerKomendPort = 1978;
        private IPAddress serwerDanychIP = IPAddress.Parse("127.0.0.1");
        private int serwerDanychPort = 25000;
        private string adresLokalnyIP;

        public Form1()
        {
            InitializeComponent();
            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());
            //adresLokalnyIP = adresyIP.AddressList[0].ToString();
            adresLokalnyIP = "127.0.0.1";
            backgroundWorker1.RunWorkerAsync();
        }

        //Bezpieczne odwoływanie się z innego wątku do własności kontrolek
        delegate void SetTextCallBack(string tekst);
        private void SetText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBox1.Items.Add(tekst);
            }
        }

        //Metoda obsługująca połączenie z serwerem
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer = new TcpListener(IPAddress.Parse(adresLokalnyIP), serwerKomendPort);
            serwer.Start();
            this.SetText("Oczekuję na komendy ...");
            while (true)
            {
                TcpClient klientKomend = serwer.AcceptTcpClient();
                this.SetText("Otrzymano komendę.");
                NetworkStream ns = klientKomend.GetStream();
                Byte[] bufor = new Byte[256];
                int odczyt = ns.Read(bufor, 0, bufor.Length);
                String s = Encoding.ASCII.GetString(bufor);
                string wiadomosc = Encoding.ASCII.GetString(bufor);
                string dane = Encoding.ASCII.GetString(bufor);
                string[] cmd = dane.Split(new char[] { ':' });
                this.SetText(wiadomosc);
                if (cmd[0] == "ACT")
                {
                    this.SetText("Komenda: " + cmd[0]);
                    this.SetText("Parametry: " + cmd[1]);
                    WyslijWiadomoscUDP(adresLokalnyIP + ":ACT");
                    try
                    {
                        TcpClient klient2 = new TcpClient(serwerDanychIP.ToString(), serwerDanychPort);
                        NetworkStream ns2 = klient2.GetStream();
                    }
                    catch (Exception ex)
                    {
                        this.SetText("Nie można połączyć się z serwerem");
                    }
                }
                if(cmd[0] == "PAS")
                {
                    this.SetText("Komenda: " + cmd[0]);
                    //this.SetText("Parametry: " + cmd[1]);
                    WyslijWiadomoscUDP(adresLokalnyIP + ":PAS");
                }
                if (cmd[0] == "CHA")
                {
                    this.SetText("Komenda: " + cmd[0]);
                    //this.SetText("Parametry: " + cmd[1]);
                    WyslijWiadomoscUDP(adresLokalnyIP + ":" + cmd[0]);
                }
                if (cmd[0] == "DEL")
                {
                    this.SetText("Komenda: " + cmd[0]);
                    //this.SetText("Parametry: " + cmd[1]);
                    WyslijWiadomoscUDP(adresLokalnyIP + ":" + cmd[0]);
                }
                if (cmd[0] == "ADD")
                {
                    this.SetText("Komenda: " + cmd[0]);
                    //this.SetText("Parametry: " + cmd[1]);
                    WyslijWiadomoscUDP(adresLokalnyIP + ":" + cmd[0]);
                }
            }
        }

        //Metoda przesyłająca wiadomość przy użyciu protokołu UDP
        private void WyslijWiadomoscUDP(string wiadomosc)
        {
            UdpClient klient = new UdpClient(serwerDanychIP.ToString(), 43210);
            byte[] bufor = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(bufor, bufor.Length);
            klient.Close();
        }

        //Wysłanie wiadomości o gotowości klienta
        private void Form1_Load_1(object sender, EventArgs e)
        {
            WyslijWiadomoscUDP(adresLokalnyIP + ":HI");
        }

        //Wysłanie wiadomości o zakończeniu pracy przez klienta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WyslijWiadomoscUDP(adresLokalnyIP + ":BYE");
        }
    }
}
