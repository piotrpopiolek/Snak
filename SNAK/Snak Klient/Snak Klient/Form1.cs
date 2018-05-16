﻿using System;
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
<<<<<<< HEAD
        private IPAddress serwerDanychIP;
=======
        private IPAddress serwerDanychIP = IPAddress.Parse("127.0.0.1");
>>>>>>> origin/0.0.3
        private int serwerDanychPort = 25000;
        private string adresLokalnyIP;

        public Form1()
        {
            InitializeComponent();


            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());
<<<<<<< HEAD

            // Get local IP address
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            // Convert to string
            adresLokalnyIP = ip.ToString();
=======
            //adresLokalnyIP = adresyIP.AddressList[0].ToString();
            adresLokalnyIP = "127.0.0.1";
            backgroundWorker1.RunWorkerAsync();
>>>>>>> origin/0.0.3
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

        //####################

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

                // ROZKAZY OD SERWERA

                // DODAWANIE
                if (cmd[0] == "ADD")
                {
                    if (cmd[1] == "FW")
                    {
                        // firewall command
                        if (cmd[2] == "AK")
                        {
                            // ROZKAZ DO FIREWALLA W TRYBIE AKTYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                        }
                        else if(cmd[2] == "PA")
                        {
                            // ROZKAZ DO FIREWALL W TRYBIE PASYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                        }
                        else
                        {
                            // Unknown command
                            this.SetText("Unknown command recieved");
                        }
                    }
                    else if(cmd[1]== "PS")
                    {
                        // process command
                        if(cmd[2] == "AK")
                        {
                            // ROZKAD DO PROCESU W TRYBIE AKTYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                        }
                        else if(cmd[2] == "PA")
                        {
                            // ROZKAZ DO PROCESU W TRYBiE PASYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                        }
                        else
                        {
                            // Unknown command
                            this.SetText("Unknown command recieved");
                        }
                    }
                    else
                    {
                        // Unknown command
                        this.SetText("Unknown command recieved");
                    }
                }
                else if (cmd[0] == "DEL")
                {
                    // USUWANIE
                    if (cmd[1] == "FW")
                    {
                        // FIREWALL
                        this.SetText("Komenda: " + dane);
                        WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                    } else if (cmd[1] == "PS")
                    {
                        // PROCES
                        this.SetText("Komenda: " + dane);
                        WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane);
                    } else
                    {
                        // Unknown command
                        this.SetText("Unknown command recieved");
                    }
                }
                else
                {
                    this.SetText("Unknown command recieved");
                }
            }
        }

        //####################

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
<<<<<<< HEAD
            // chyba nic tu nie trzeba
=======
            WyslijWiadomoscUDP("HI:" + adresLokalnyIP);
>>>>>>> origin/0.0.3
        }

        //Wysłanie wiadomości o zakończeniu pracy przez klienta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WyslijWiadomoscUDP("BYE:" + adresLokalnyIP);
        }
<<<<<<< HEAD

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // adres ip serwera
                serwerDanychIP = IPAddress.Parse(textBox1.Text);

                WyslijWiadomoscUDP("HI:" + adresLokalnyIP);
                this.SetText("Wyslano komunikat HI:" + adresLokalnyIP);

                // wywalenie ekranu laczenia
                label2.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;

                // wlaczenie konsoli
                listBox1.Visible = true;
                label1.Visible = true;

                // start polaczenia
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Podano zly adres IP");
            }
        }
=======
>>>>>>> origin/0.0.3
    }
}
