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
        ZabronioneDlaWszystkich zabronioneDlaWszystkich = new ZabronioneDlaWszystkich();
        string plik = "Work " + DateTime.Today.ToString("dd_MM_yyyy") + " " + DateTime.Now.ToString("HH-mm") + ".txt";
        string listProcessFile = "List Processes.txt";
        string listDomensFile = "List Domens.txt";

        public delegate void SetTextCallBack(string tekst);
        public delegate void UpdateLisboxes();

        public Form1()
        {
            InitializeComponent();

            listBoxDomena.SelectionMode = SelectionMode.One;
            listBoxProces.SelectionMode = SelectionMode.One;

            //Nowe listBoxy
            listBoxProcesses.SelectionMode = SelectionMode.MultiSimple;
            listBoxProcesses.DataSource = File.ReadAllLines(listProcessFile);
            listBoxDomens.SelectionMode = SelectionMode.MultiSimple;
            listBoxDomens.DataSource = File.ReadAllLines(listDomensFile);

            comboBoxChange.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRodzaj.DropDownStyle = ComboBoxStyle.DropDownList;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();

            // Get local IP address
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            // Convert to string
            string adresLokalnyIP = ip.ToString();

            labelTextIP.Text = "Adres IP serwera - " + adresLokalnyIP;
        }

        //Bezpieczne odwoływanie się z innego wątku do własności kontrolek
        private void SetText(string tekst)
        {
            if (listBoxClient1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBoxClient1.Items.Add(tekst);
                this.listBoxClient2.Items.Add(tekst);
                this.listBoxClient3.Items.Add(tekst);
                this.listBoxClient4.Items.Add(tekst);
                this.listBoxClient5.Items.Add(tekst);
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
                this.listBoxConsole.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " " + tekst);
                File.AppendAllText(plik, DateTime.Now.ToString("HH:mm:ss") + " " + tekst + "\n");
            }
        }

        delegate void RemoveTextCallBack(int pozycja);

        //Metoda pozwalająca bezpiecznie usunąć wpis z listy listBox1
        private void RemoveText(int pozycja)
        {
            if (listBoxClient1.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveText);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBoxClient1.Items.RemoveAt(pozycja);
                listBoxClient2.Items.RemoveAt(pozycja);
                listBoxClient3.Items.RemoveAt(pozycja);
                listBoxClient4.Items.RemoveAt(pozycja);
                listBoxClient5.Items.RemoveAt(pozycja);
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
                    foreach (string wpis in listBoxClient1.Items)
                        if (wpis == cmd[1])
                        {
                            MessageBox.Show("Próba nawiązania połączenia z " + cmd[1] + " odrzucona, ponieważ na liście istnieje już taki klient");
                            // WYSLIJ ERROR
                            return;
                        }
                    listaKlientow.DodajKlienta(cmd[2], cmd[1]);
                    this.SetText(cmd[2]);
                }
                else
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
                            }
                            else
                            {
                                this.SetTextConsole("Otrzymano nieznany komunikat");
                            }
                        }
                        // komunikat o procesie
                        else if (cmd[3] == "PS")
                        {
                            string nazwaKlienta = listaKlientow.IPDoNazwy(cmd[1]);
                            string nazwaProcesu = cmd[5];

                            if (cmd[4] == "PA")
                            {
                                // DODANIE PROCESU W TRYBIE PASYWNYM
                                string text = nazwaKlienta + ":PA:" + nazwaProcesu;
                                //this.SetTextProces(text);
                                listaKlientow.dodajProcesPasywny(nazwaKlienta, nazwaProcesu);
                            }
                            else if (cmd[4] == "AK")
                            {
                                // DODANIE PROCESU W TRYBIE AKTYWNYM
                                string text = listaKlientow.IPDoNazwy(nazwaKlienta + ":AK:" + nazwaProcesu);
                                //this.SetTextProces(text);
                                listaKlientow.dodajProcesAktywny(nazwaKlienta, nazwaProcesu);
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
                        updateBannedListboxes();

                    }
                    else if (cmd[2] == "DEL")
                    {
                        // usuwanie
                        if (cmd[3] == "FW")
                        {
                            // USUNIECIE DOMENY Z FIREWALLA
                            //int pozycja = listBoxDomena.Items.IndexOf(cmd[4]);
                            //RemoveTextDomena(pozycja);
                        }
                        else if (cmd[3] == "PS")
                        {
                            string nazwaKlienta = listaKlientow.IPDoNazwy(cmd[1]);
                            string nazwaProcesu = cmd[5];
                            if (cmd[4] == "AK")
                            {
                                // USUNIECIE PROCESU W TRYBIE AKTYWNYM

                                listaKlientow.usunProcesAktywny(nazwaKlienta, nazwaProcesu);

                                updateBannedListboxes();
                            } else if (cmd[4] == "PA")
                            {
                                // USUNIECIE PROCESU W TRYBIE PASYWNYM

                                listaKlientow.usunProcesPasywny(nazwaKlienta, nazwaProcesu);

                                updateBannedListboxes();
                            } else
                            {
                                this.SetTextConsole("Otrzymano nieznany komunikat");
                            }
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

                }
                else
                if (cmd[0] == "NAR")
                {
                    this.SetTextConsole("Naruszenie - " + listaKlientow.IPDoNazwy(cmd[1]) + " - procesu o nazwie " + cmd[4]);
                }
                else
                if (cmd[0] == "BYE")
                {
                    string nazwa = listaKlientow.IPDoNazwy(cmd[1]);
                    this.SetTextConsole("Klient o adresie IP: " + cmd[1] + " i nazwie" + nazwa + " rozłączył się.");
                    for (int i = 0; i < listBoxClient1.Items.Count; i++)
                        if (listBoxClient1.Items[i].ToString() == nazwa)
                            this.RemoveText(i);
                    listaKlientow.UsunKlienta(cmd[1]);
                }
            }
        }

        //Metoda do wysyłania komend
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string commandArgument = textBoxNazwa.Text;
            string command = "";

            if ((checkBox1.Checked == false) && listBoxClient1.SelectedIndex == -1) return;

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
                    foreach (string item in listBoxClient1.Items)
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
                    foreach (string item in listBoxClient1.SelectedItems)
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

        private void buttonAddProcesToList_Click(object sender, EventArgs e)
        {
            File.AppendAllText(listProcessFile, textBoxAddProcesToList.Text + "\n");
            //Podczas dodawania ma się też od razu wysłać jako rozkaz do klientów
            //na liscie przykładowych procesów pojawi się po restarcie serwera.
        }

        private void buttonAddDomenToList_Click(object sender, EventArgs e)
        {
            File.AppendAllText(listDomensFile, textBoxAddDomenToList.Text + "\n");
            //Podczas dodawania ma się też od razu wysłać jako rozkaz do klientów
            //na liscie przykładowych domen pojawi się po restarcie serwera.
        }

        private void buttonSendCommandProces_Click(object sender, EventArgs e)
        {
            //Do dopisania usuwanie blokad
            string commandArgument = textBoxNazwa.Text;
            string command = "";

            bool aktywny = false;

            if ((checkBox2.Checked == false) && listBoxClient2.SelectedIndex == -1) return;

            try
            {
                // DODAWANIE BLOKAD
                if (comboBoxChange1.Text == "zabronione")
                {
                    // aktywny
                    if (comboBoxMode1.Text == "Aktywny")
                    {
                        // DODAJ PROCES W TRYBIE AKTYWNYM                            
                        command = "ADD:PS:AK";
                        aktywny = true;

                    } else
                    {
                        command = "ADD:PS:PA";
                        aktywny = false;
                    }
                    // Argumenty
                    foreach (string item in listBoxProcesses.SelectedItems)
                    {

                        //WYSYLANIEWIELU
                        //commandArgument = commandArgument + item + ";";

                        commandArgument = item;

                        if (checkBox2.Checked == true)
                        {
                            if (aktywny)
                            {
                                zabronioneDlaWszystkich.zablokowane_procesy_aktywny.Add(item);
                            }
                            else
                            {
                                zabronioneDlaWszystkich.zablokowane_procesy_pasywny.Add(item);
                            }
                            updateBannedListboxes();
                        }
                        else
                        {
                            // zaimplementowane po otrzymaniu komendy 
                        }
                    }
                }
                // USUWANIE BLOKAD
                else
                {
                    if (listBoxBannedAK.SelectedIndex != -1)
                    {
                        // PROCES AKTYWNY
                        command = "DEL:PS:AK";
                        string cmd = listBoxBannedAK.SelectedItem.ToString();
                        //string[] cmd = listBoxBannedAK.SelectedItem.ToString().Split(new char[] { ':' });
                        commandArgument = cmd;
                    }
                    else
                    {
                        // ERROR
                        //this.SetText("ERROR");
                    }
                }

                //##########

                // WYSYLANIE KOMUNIKATU

                // DO KAZDEGO
                if (checkBox2.Checked == true)
                {
                    foreach (string item in listBoxClient2.Items)
                    {
                        string address = listaKlientow.NazwaDoIP(item);

                        TcpClient klient = new TcpClient(address, 1978);
                        NetworkStream ns = klient.GetStream();

                        byte[] bufor = Encoding.ASCII.GetBytes(command + ":" + commandArgument + ":");
                        ns.Write(bufor, 0, bufor.Length);
                    }
                }
                else
                // TYLKO DO ZAZNACZONEGO
                {
                    foreach (string item in listBoxClient2.SelectedItems)
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
        }

        private void listBoxClient2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                listBoxClient2.Invoke(new Action(delegate ()
                {
                    listBoxClient2.SelectedIndex = -1;
                }));

                updateBannedListboxes();

                return;
            } else
            {
                if (listBoxClient2.SelectedIndex == -1) { return; }
                updateBannedListboxes();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                updateBannedListboxes();

                listBoxClient2.Invoke(new Action(delegate ()
                {
                    listBoxClient2.SelectedIndex = -1;
                }));
            }
        }

        void InvokeUpdateListboxes()
        {
            UpdateLisboxes updateListboxes = new UpdateLisboxes(updateBannedListboxes);
            IAsyncResult ifAr = updateListboxes.BeginInvoke(new AsyncCallback(doNothing), null);
            updateListboxes.EndInvoke(ifAr);
        }

        public void doNothing(IAsyncResult iftAr)
        {
            //
        }

        void updateBannedListboxes()
        {
            listBoxBannedAK.Invoke(new Action(delegate ()
            {
                listBoxBannedAK.Items.Clear();
            }));

            listBoxBannedAK.Invoke(new Action(delegate ()
            {
                listBoxBannedPA.Items.Clear();
            }));

            if (checkBox2.Checked == true)
            {
                updateBannedListoxesALL();
            } else
            {
                updateBannedListboxesOne();
            }
        }

        void updateBannedListboxesOne()
        {
            string clientName = "";

            listBoxClient2.Invoke(new Action(delegate ()
            {
                clientName = listBoxClient2.SelectedItem.ToString();
            }));

            foreach (string item in listaKlientow.zwrocListeProcesyAktywne(clientName))
            {
                listBoxBannedAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedAK.Items.Add(item);
                }));
            }
            foreach (string item in listaKlientow.zwrocListeProcesyPasywne(clientName))
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedPA.Items.Add(item);
                }));
            }
        }

        void updateBannedListoxesALL()
        {
            foreach (string item in zabronioneDlaWszystkich.zablokowane_procesy_aktywny)
            {
                listBoxBannedAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedAK.Items.Add(item);
                }));
            }
            foreach (string item in zabronioneDlaWszystkich.zablokowane_procesy_pasywny)
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedPA.Items.Add(item);
                }));
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

