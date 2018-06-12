using System;
using FWCtrl;
using Antycheat;

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
using Antycheat;
using System.Threading;
using Monitor_Dysku;

namespace Snak_Klient
{
    public partial class Form1 : Form
    {
        private int serwerKomendPort = 1978;
        private IPAddress serwerDanychIP;
        private int serwerDanychPort = 25000;
        private string adresLokalnyIP;

        FirewallController firewallController;
        ProcessManagement processController;

        bool screen = false;

        Thread screenThread = new Thread(new ThreadStart(Screenshot.startPreview));

        Monitor_Dysku.Monitor_Dysku Sprawdzacz;

        Thread Watek_Monitorowania_Dykow;

        public Form1()
        {
            InitializeComponent();


            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());

            // Get local IP address
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            // Convert to string
            adresLokalnyIP = ip.ToString();
        }

        //Bezpieczne odwoływanie się z innego wątku do własności kontrolek
        delegate void SetTextCallBack(string tekst);
        private void SetText(string tekst)
        {
            try
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
            catch(Exception ex)
            {

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

                            try
                            {
                                firewallController.AddRule(cmd[3]);
                                WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");
                            } catch (Exception)
                            {
                                WyslijWiadomoscUDP("ERR:Brak uprawnien administratora");
                            }
                        }
                        else if(cmd[2] == "PA")
                        {
                            // ROZKAZ DO FIREWALL W TRYBIE PASYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");
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
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");

                            ProhibitedProcesses.add(cmd[3]);
                        }
                        else if(cmd[2] == "PA")
                        {
                            // ROZKAZ DO PROCESU W TRYBiE PASYWNYM
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");

                            ProhibitedProcessesPas.add(cmd[3]);
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
                        if(cmd[2] == "AK")
                        {
                            // FIREWALL AKTYWNY
                            firewallController.DeleteRule(cmd[3]);
                            this.SetText("Komenda PAS: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");
                        } else if(cmd[2] == "PA")
                        {
                            // FIREWALL PASYWNY
                        } else
                        {
                            // nienzany komunikat
                        }
                    }
                    // PROCES
                    else if (cmd[1] == "PS")
                    {
                        if(cmd[2] == "AK")
                        {
                            // usun poces w trybie aktywnym
                            this.SetText("Komenda PAS: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");

                            ProhibitedProcesses.remove(cmd[3]);
                        } else
                        if(cmd[2] == "PA")
                        {
                            // usun proces w trybie pasywnym
                            this.SetText("Komenda: " + dane);
                            WyslijWiadomoscUDP("PAS:" + adresLokalnyIP + ":" + dane + ":");

                            ProhibitedProcessesPas.remove(cmd[3]);
                        }
                        else
                        {
                            this.SetText("Unknown command recieved");
                        }
                    } else
                    {
                        // Unknown command
                        this.SetText("Unknown command recieved");
                    }
                }
                else if (cmd[0] == "SCRSTART")
                {
                    // screeny start
                    if (Screenshot.screen == false)
                    {
                        Screenshot.screen = true;
                    } 

                } else if (cmd[0] == "SCRSTOP")
                {
                    // screeny stop
                    if (Screenshot.screen == true)
                    {
                        Screenshot.screen = false;
                    }
                } else
                {
                    this.SetText("Unknown command recieved");
                    MessageBox.Show(cmd[0]);
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
            // chyba nic tu nie trzeba
        }

        //Wysłanie wiadomości o zakończeniu pracy przez klienta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                WyslijWiadomoscUDP("BYE:" + adresLokalnyIP + ":");
            }
            catch (Exception)
            {
                //
            }
        }

        //Łączenie z serwerem
        private void connectToServer_Click(object sender, EventArgs e)
        {
            try
            {
                // adres ip serwera
                string ip = textBox1.Text;

                serwerDanychIP = IPAddress.Parse(textBox1.Text);

                if (textBox2.Text == "")
                {
                    throw new Exception();
                }

                Screenshot.ipSerwera = ip;

                WyslijWiadomoscUDP("HI:" + adresLokalnyIP + ":" + textBox2.Text + ":");
                this.SetText("Wyslano komunikat HI:" + adresLokalnyIP + ":");

                // wywalenie ekranu laczenia
                label2.Visible = false;
                textBox1.Visible = false;
                connectToServer.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;

                // wlaczenie konsoli
                listBox1.Visible = true;
                label1.Visible = true;

                // start polaczenia
                backgroundWorker1.RunWorkerAsync();

                // Firewall
                //firewallController = new FirewallController();

                // Procesy
                processController = new ProcessManagement(serwerDanychIP.ToString(), adresLokalnyIP);

                backgroundWorker2.RunWorkerAsync();
                backgroundWorker3.RunWorkerAsync();
                screenThread.Start();

                Sprawdzacz = new Monitor_Dysku.Monitor_Dysku(serwerDanychIP.ToString());

                Watek_Monitorowania_Dykow = new System.Threading.Thread(new ThreadStart(Sprawdzacz.Sprawdzanie));

                Watek_Monitorowania_Dykow.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Podano zly adres IP lub nie podano nazwy");
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            processController.guardAggressive();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            processController.guardPassive();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    // adres ip serwera
                    string ip = textBox1.Text;

                    serwerDanychIP = IPAddress.Parse(textBox1.Text);

                    if (textBox2.Text == "")
                    {
                        throw new Exception();
                    }

                    Screenshot.ipSerwera = ip;

                    WyslijWiadomoscUDP("HI:" + adresLokalnyIP + ":" + textBox2.Text + ":");
                    this.SetText("Wyslano komunikat HI:" + adresLokalnyIP + ":");

                    // wywalenie ekranu laczenia
                    label2.Visible = false;
                    textBox1.Visible = false;
                    connectToServer.Visible = false;
                    label3.Visible = false;
                    textBox2.Visible = false;

                    // wlaczenie konsoli
                    listBox1.Visible = true;
                    label1.Visible = true;

                    // start polaczenia
                    backgroundWorker1.RunWorkerAsync();

                    // Firewall
                    //firewallController = new FirewallController();

                    // Procesy
                    processController = new ProcessManagement(serwerDanychIP.ToString(), adresLokalnyIP);

                    backgroundWorker2.RunWorkerAsync();
                    backgroundWorker3.RunWorkerAsync();
                    screenThread.Start();

                    Sprawdzacz = new Monitor_Dysku.Monitor_Dysku(serwerDanychIP.ToString());

                    Watek_Monitorowania_Dykow = new System.Threading.Thread(new ThreadStart(Sprawdzacz.Sprawdzanie));

                    Watek_Monitorowania_Dykow.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano zly adres IP lub nie podano nazwy");
                }
            }
            else
            {

            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }
    }
}
