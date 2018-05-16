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
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
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
                if (cmd[1] == "HI")
                {
                    this.SetTextConsole("Nowy klient o adresie IP: " + cmd[0]);
                    foreach (string wpis in listBox1.Items)
                        if (wpis == cmd[0])
                        {
                            MessageBox.Show("Próba nawiązania połączenia z " + cmd[0] + " odrzucona, ponieważ na liście istnieje już taki wpis");
                            return;
                        }
                    this.SetText(cmd[0]);
                }
                if (cmd[1] == "ACT")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " wykonał komendę " + cmd[1]);
                }
                if (cmd[1] == "PAS")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " wykonał komendę " + cmd[1]);
                }
                if (cmd[1] == "CHA")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " wykonał komendę " + cmd[1]);
                }
                if (cmd[1] == "DEL")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " wykonał komendę " + cmd[1]);
                }
                if (cmd[1] == "ADD")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " wykonał komendę " + cmd[1]);
                }
                if (cmd[1] == "BYE")
                {
                    this.SetTextConsole("Klient o adresie IP: " + cmd[0] + " rozłączył się.");
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        if (listBox1.Items[i].ToString() == cmd[0])
                            this.RemoveText(i);
                }
            }
        }

        //Metoda do wysyłania komend
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string command = String.Empty;

            if (listBox1.SelectedIndex == -1)
                return;
            try
            {
                TcpClient klient = new TcpClient(listBox1.Items[listBox1.SelectedIndex].ToString(), 1978);
                NetworkStream ns = klient.GetStream();
                if (comboBoxMode.Text == "Aktywny")
                {
                    command = "ACT";
                    byte[] bufor = Encoding.ASCII.GetBytes(command + ":" + listBoxProcess.Items[listBoxProcess.SelectedIndex].ToString());
                    ns.Write(bufor, 0, bufor.Length);
                }
                else if (comboBoxMode.Text == "Pasywny")
                {
                    command = "PAS";
                    byte[] bufor = Encoding.ASCII.GetBytes(command);
                    ns.Write(bufor, 0, bufor.Length);
                }
                else if (comboBoxChange.Text == "Zmiana")
                {
                    command = "CHA";
                    byte[] bufor = Encoding.ASCII.GetBytes(command);
                    ns.Write(bufor, 0, bufor.Length);
                }
                else if (comboBoxChange.Text == "Usunięcie")
                {
                    command = "DEL";
                    byte[] bufor = Encoding.ASCII.GetBytes(command);
                    ns.Write(bufor, 0, bufor.Length);
                }
                else if (comboBoxChange.Text == "Dodanie")
                {
                    command = "ADD";
                    byte[] bufor = Encoding.ASCII.GetBytes(command);
                    ns.Write(bufor, 0, bufor.Length);
                }
                else
                {
                    MessageBox.Show("Błąd wyboru komendy");
                }

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
    }
}
