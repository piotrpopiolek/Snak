using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Server_Snak
{
    public partial class Form1 : Form
    {
        ListaKlientow listaKlientow = new ListaKlientow();

        public Form1()
        {
            InitializeComponent();

            listBoxDomena.SelectionMode = SelectionMode.One;
            listBoxProces.SelectionMode = SelectionMode.One;
            comboBoxChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRodzaj.DropDownStyle = ComboBoxStyle.DropDownList;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();

            // Get local IP address
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            // Convert to string
            string adresLokalnyIP = ip.ToString();

            label10.Text = "Adres IP serwera - " + adresLokalnyIP;
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

        private void SetTextProces(string tekst)
        {
            if (listBoxProces.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextProces);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBoxProces.Items.Add(tekst);
            }
        }

        private void SetTextDomena(string tekst)
        {
            if (listBoxDomena.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextDomena);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBoxDomena.Items.Add(tekst);
            }
        }

        //Metoda do komunikatów w konsoli serwera
        private void SetTextConsole(string tekst)
        {
            if (listBoxConsole.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextConsole);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBoxConsole.Items.Add(tekst);
            }
        }

        delegate void RemoveTextCallBack(int pozycja);

        //Metoda pozwalająca bezpiecznie usunąć wpis z listy listBox1
        private void RemoveText(int pozycja)
        {
            if (listBox1.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveText);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBox1.Items.RemoveAt(pozycja);
            }
        }

        private void RemoveTextProces(int pozycja)
        {
            if (listBoxProces.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveTextProces);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBoxProces.Items.RemoveAt(pozycja);
            }
        }

        private void RemoveTextDomena(int pozycja)
        {
            if (listBoxDomena.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveTextDomena);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBoxDomena.Items.RemoveAt(pozycja);
            }
        }

        //Oczekiwanie na pakiety UDP
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient klient = new UdpClient(43210);
            while (true)
            {
     
                Byte[] bufor = klient.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(bufor);
                string[] cmd = dane.Split(new char[] { ':' });
                if (cmd[0] == "HI")
                {
                    this.SetTextConsole("Nowy klient o adresie IP: " + cmd[1] + " oraz nazwie - " + cmd[2]);
                    foreach (string wpis in listBox1.Items)
                        if (wpis == cmd[1])
                        {
                            MessageBox.Show("Próba nawiązania połączenia z " + cmd[1] + " odrzucona, ponieważ na liście istnieje już taki klient");
                            // WYSLIJ ERROR
                            return;
                        }
                    listaKlientow.DodajKlienta(cmd[2], cmd[1]);
                    this.SetText(cmd[2]);
                } else
                if (cmd[0] == "PAS")
                {
                    this.SetTextConsole("Klient: " + listaKlientow.IPDoNazwy(cmd[1]) + " wykonał komendę " + dane);
                    // TUTAJ PO OTRZYMANIU POTWIERDZENIA O WYKONANJE AKCJI USTAWIAMY LISTBOXY
                    if (cmd[2] == "ADD")
                    {
                        // komunikat o firewallu
                        if (cmd[3] == "FW")
                        {
                            if (cmd[4] == "PA")
                            {
                                // DODANIE DO FIREWALLA W TRYBIE PASYWNYM
                                string text = listaKlientow.IPDoNazwy(cmd[1]) + ":PA:" + cmd[5];
                                this.SetTextDomena(text);
                            }
                            else if (cmd[4] == "AK")
                            {
                                // DODANIE DO FIREWALLA W TRYBIE AKTYWNYM
                                string text = listaKlientow.IPDoNazwy(cmd[1]) + ":AK:" + cmd[5];
                                this.SetTextDomena(text);
                            } else
                            {
                                this.SetTextConsole("Otrzymano nieznany komunikat");
                            }
                        }
                        // komunikat o procesie
                        else if (cmd[3] == "PS")
                        {
                            if (cmd[4] == "PA")
                            {
                                // DODANIE PROCESU W TRYBIE PASYWNYM
                                string text = listaKlientow.IPDoNazwy(cmd[1]) + ":PA:" + cmd[5];
                                this.SetTextProces(text);
                            }
                            else if (cmd[4] == "AK")
                            {
                                // DODANIE PROCESU W TRYBIE AKTYWNYM
                                string text = listaKlientow.IPDoNazwy(cmd[1]) + ":AK:" + cmd[5];
                                this.SetTextProces(text);
                            }
                            else
                            {
                                this.SetTextConsole("Otrzymano nieznany komunikat");
                            }
                        }
                        else
                        {
                            this.SetTextConsole("Otrzymano nieznany komunikat");
                        }
                    }
                    else if(cmd[2] == "DEL")
                    {
                        // usuwanie
                        if (cmd[3] == "FW")
                        {
                            // USUNIECIE DOMENY Z FIREWALLA
                            //int pozycja = listBoxDomena.Items.IndexOf(cmd[4]);
                            //RemoveTextDomena(pozycja);
                        }
                        else if(cmd[3] == "PS")
                        {
                            // USUNIECIE PROCESU
                            //int pozycja = listBoxProces.Items.IndexOf(cmd[4]);
                            //RemoveTextProces(pozycja);
                        }
                        else
                        {
                            this.SetTextConsole("Otrzymano nieznany komunikat");
                        }
                    }
                    else
                    {
                        this.SetTextConsole("Otrzymano nieznany komunikat");
                    }
                    //###########################

                } else
                if (cmd[0] == "NAR")
                {
                    this.SetTextConsole("Naruszenie - " + listaKlientow.IPDoNazwy(cmd[1]) + " - procesu o nazwie " + cmd[4]);
                } else
                if (cmd[0] == "BYE")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[1] + " i nazwie"+ listaKlientow.IPDoNazwy(cmd[1]) +"rozłączył się.");
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        if (listBox1.Items[i].ToString() == cmd[1])
                            this.RemoveText(i);
                    listaKlientow.UsunKlienta(cmd[1]);
                } else
                {
                    this.SetTextConsole("Otrzymano nieznany komunikat");
                }
            }
        }

        //Metoda do wysyłania komend
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string commandArgument = textBoxNazwa.Text;
            string command = "";

            if ((checkBox1.Checked == false) && listBox1.SelectedIndex == -1) return;

            try
            {
                // DODAWANIE
                if (comboBoxChange.Text == "Dodanie")
                {
                    if (textBoxNazwa.Text == "")
                    {
                        SetTextConsole("Brak nazwy");
                    } else
                    {
                        // aktywny
                        if (comboBoxMode.Text == "Aktywny")
                        {
                            if (comboBoxRodzaj.Text == "Proces")
                            {
                                // DODAJ PROCES W TRYBIE AKTYWNYM                            
                                command = "ADD:PS:AK";
                            }
                            else if (comboBoxRodzaj.Text == "Domena")
                            {
                                // DODAJ DOMENE W TRYBIE AKTYWNYM
                                command = "ADD:FW:AK";
                            }
                            else
                            {
                                // BLAD
                                MessageBox.Show("Blad");
                            }
                        }
                        // pasywny
                        else
                        {
                            if (comboBoxRodzaj.Text == "Proces")
                            {
                                // DODAJ PROCES W TRYBIE PASYWNYM
                                command = "ADD:PS:PA";
                            }
                            else if (comboBoxRodzaj.Text == "Domena")
                            {
                                // DODAJ DOMENE W TRYBIE PASYWNYM
                                command = "ADD:FW:PA";
                            }
                            else
                            {
                                // BLAD
                                MessageBox.Show("Blad");
                            }
                        }
                    }
                }
                // USUWANIE
                else
                {
                    if (listBoxDomena.SelectedIndex != -1)
                    {
                        // DOMENA
                        command = "DEL:FW";
                        commandArgument = listBoxDomena.SelectedItem.ToString();

                        RemoveTextDomena(listBoxDomena.SelectedIndex);
                    } else if (listBoxProces.SelectedIndex != -1)
                    {
                        // PROCES
                        command = "DEL:PS";
                        string[] cmd = listBoxProces.SelectedItem.ToString().Split(new char[] { ':' });
                        commandArgument = cmd[1] + ":" + cmd[2];

                        RemoveTextProces(listBoxProces.SelectedIndex);
                    }
                    else
                    {
                        // ERROR
                        this.SetText("ERROR");
                    }
                }

                //##########

                // WYSYLANIE KOMUNIKATU

                // DO KAZDEGO
                if (checkBox1.Checked == true)
                {
                    foreach (string item in listBox1.Items)
                    {
                        string address = listaKlientow.NazwaDoIP(item);

                        TcpClient klient = new TcpClient(address, 1978);
                        NetworkStream ns = klient.GetStream();

                        byte[] bufor = Encoding.ASCII.GetBytes(command + ":" + commandArgument + ":");
                        ns.Write(bufor, 0, bufor.Length);
                    }
                } else
                // TYLKO DO ZAZNACZONEGO
                {
                    foreach (string item in listBox1.SelectedItems)
                    {
                        string address = listaKlientow.NazwaDoIP(item);

                        TcpClient klient = new TcpClient(address, 1978);
                        NetworkStream ns = klient.GetStream();

                        byte[] bufor = Encoding.ASCII.GetBytes(command + ":" + commandArgument + ":");
                        ns.Write(bufor, 0, bufor.Length);
                    }
                }

                //##########

                if (backgroundWorker1.IsBusy == false)
                    backgroundWorker1.RunWorkerAsync();
                else
                {
                    //MessageBox.Show("Błąd: backgroundWorker1.IsBusy == false");
                }
            }
            catch
            {
                MessageBox.Show("Błąd: Nie można nawiązać połączenia");
            }

            // czyszczenie textboxa
            textBoxNazwa.Text = "";
        }

        //Odbieranie transmisji danych od klienta
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer2 = new TcpListener(IPAddress.Parse(textBox1.Text), (int)numericUpDown1.Value);
            serwer2.Start();
            TcpClient klient2 = serwer2.AcceptTcpClient();
            NetworkStream ns = klient2.GetStream();
            
            serwer2.Stop();
        }

        // Jesli usuwamy wszystkie opcje do dodawania sie chowaja
        private void comboBoxChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChange.Text == "Dodanie")
            {
                label1.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                comboBoxMode.Visible = true;
                comboBoxRodzaj.Visible = true;
                textBoxNazwa.Visible = true;
            }
            else if(comboBoxChange.Text == "Usunięcie")
            {
                label1.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                comboBoxMode.Visible = false;
                comboBoxRodzaj.Visible = false;
                textBoxNazwa.Visible = false;
            }
        }

        // Nie mozna miec zaznaczonych dwoch listboxow na raz
        private void listBoxProces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxProces.SelectedIndex;
            listBoxDomena.ClearSelected();
            listBoxProces.SelectedIndex = i;
        }
        // Nie mozna miec zaznaczonych dwoch listboxow na raz
        private void listBoxDomena_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxDomena.SelectedIndex;
            listBoxProces.ClearSelected();
            listBoxDomena.SelectedIndex = i;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void textBoxNazwa_TextChanged(object sender, EventArgs e)
        {
            //
        }
    }
}

