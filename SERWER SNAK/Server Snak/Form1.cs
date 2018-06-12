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
using System.Threading;

using Antycheat;

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

        public string address = "127.0.0.1";

        public Form1()
        {
            InitializeComponent();

            List<string> listProcesses = File.ReadAllLines(listProcessFile).ToList();
            List<string> listDomens = File.ReadAllLines(listDomensFile).ToList();

            listProcesses.Sort();
            listDomens.Sort();

            File.WriteAllLines(listProcessFile, listProcesses);
            File.WriteAllLines(listDomensFile, listDomens);

            //Nowe listBoxy
            listBoxProcesses.SelectionMode = SelectionMode.MultiSimple;  
            listBoxProcesses.DataSource = File.ReadAllLines(listProcessFile);

            listBoxDomens.SelectionMode = SelectionMode.MultiSimple;
            listBoxDomens.DataSource = File.ReadAllLines(listDomensFile);

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();

            // Get local IP address
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            // Convert to string
            string adresLokalnyIP = ip.ToString();
            labelIPSerwera.Text = adresLokalnyIP;
        }

        //Bezpieczne odwoływanie się z innego wątku do własności kontrolek
        private void SetText(string tekst)
        {
            if (listBoxClient2.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBoxClient2.Items.Add(tekst);
                this.listBoxClient3.Items.Add(tekst);
                this.listBoxClient4.Items.Add(tekst);
                this.listBoxClient5.Items.Add(tekst);
            }
        }

        delegate void RemoveTextCallBack(int pozycja);

        //Metoda pozwalająca bezpiecznie usunąć wpis z listy listBox1
        private void RemoveText(int pozycja)
        {
            if (listBoxClient2.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveText);
                this.Invoke(f, new object[] { pozycja });
            }
            else
            {
                listBoxClient2.Items.RemoveAt(pozycja);
                listBoxClient3.Items.RemoveAt(pozycja);
                listBoxClient4.Items.RemoveAt(pozycja);
                listBoxClient5.Items.RemoveAt(pozycja);
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
                File.AppendAllText(plik, DateTime.Now.ToString("HH:mm:ss") + " " + dane + "\n");
                if (cmd[0] == "HI")
                {
                    foreach (string wpis in listBoxClient2.Items)
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
                    // TUTAJ PO OTRZYMANIU POTWIERDZENIA O WYKONANJE AKCJI USTAWIAMY LISTBOXY
                    if (cmd[2] == "ADD")
                    {
                        string nazwaKlienta = listaKlientow.IPDoNazwy(cmd[1]);
                        string nazwaBlokady = cmd[5];
                        // komunikat o firewallu
                        if (cmd[3] == "FW")
                        {
                            if (cmd[4] == "PA")
                            {
                                // DODANIE DO FIREWALLA W TRYBIE PASYWNYM
                                string text = nazwaKlienta + ":PA:" + nazwaBlokady;
                                listaKlientow.dodajDomenePasywna(nazwaKlienta, nazwaBlokady);
                            }
                            else if (cmd[4] == "AK")
                            {
                                // DODANIE DO FIREWALLA W TRYBIE AKTYWNYM
                                string text = nazwaKlienta + ":AK:" + nazwaBlokady;
                                listaKlientow.dodajDomeneAktywna(nazwaKlienta, nazwaBlokady);
                            }
                            else
                            {
                                // nieznany komunikat
                            }
                        }
                        // komunikat o procesie
                        else if (cmd[3] == "PS")
                        {
                            if (cmd[4] == "PA")
                            {
                                // DODANIE PROCESU W TRYBIE PASYWNYM
                                string text = nazwaKlienta + ":PA:" + nazwaBlokady;
                                //this.SetTextProces(text);
                                listaKlientow.dodajProcesPasywny(nazwaKlienta, nazwaBlokady);
                            }
                            else if (cmd[4] == "AK")
                            {
                                // DODANIE PROCESU W TRYBIE AKTYWNYM
                                string text = nazwaKlienta + ":AK:" + nazwaBlokady;
                                //this.SetTextProces(text);
                                listaKlientow.dodajProcesAktywny(nazwaKlienta, nazwaBlokady);
                            }
                            else
                            {
                                //
                            }
                        }
                        else
                        {
                            //
                        }
                        updateBannedListboxes();

                    }
                    else if (cmd[2] == "DEL")
                    {
                        string nazwaKlienta = listaKlientow.IPDoNazwy(cmd[1]);
                        string nazwaBlokady = cmd[5];
                        // usuwanie
                        if (cmd[3] == "FW")
                        {                            
                            if (cmd[4] == "AK")
                            {
                                // USUNIECIE DOMENY Z FIREWALLA W TRYBIE AKTYWNYM
                                listaKlientow.usunDomeneAktywna(nazwaKlienta, nazwaBlokady);

                                updateBannedListboxes();
                            } else if (cmd[4] == "PA")
                            {
                                // USUNIECIE DOMENY Z FIREWALLA W TRYBIE PASYWNYM
                                listaKlientow.usunDomenePasywna(nazwaKlienta, nazwaBlokady);

                                updateBannedListboxes();
                            } else
                            {
                                //
                            }
                        }
                        else if (cmd[3] == "PS")
                        {
                            if (cmd[4] == "AK")
                            {
                                // USUNIECIE PROCESU W TRYBIE AKTYWNYM

                                listaKlientow.usunProcesAktywny(nazwaKlienta, nazwaBlokady);

                                updateBannedListboxes();
                            } else if (cmd[4] == "PA")
                            {
                                // USUNIECIE PROCESU W TRYBIE PASYWNYM

                                listaKlientow.usunProcesPasywny(nazwaKlienta, nazwaBlokady);

                                updateBannedListboxes();
                            } else
                            {
                                //
                            }
                        }
                        else
                        {
                            //
                        }
                    }
                    else
                    {
                        //
                    }
                    //###########################

                }
                else
                if (cmd[0] == "NAR")
                {
                    // NARUSZENIE
                }
                else if (cmd[0] == "SCR")
                {
                    //// wyswietlanie 
                    //byte[] screen = Encoding.ASCII.GetBytes(cmd[1]);


                    ////pictureBox1.Image = 
                    //Screenshot.byteArrayToImage(screen);

                } else
                if (cmd[0] == "BYE")
                {
                    string nazwa = listaKlientow.IPDoNazwy(cmd[1]);
                    for (int i = 0; i < listBoxClient2.Items.Count; i++)
                        if (listBoxClient2.Items[i].ToString() == nazwa)
                            this.RemoveText(i);
                    listaKlientow.UsunKlienta(cmd[1]);


                    checkBox2.Invoke(new Action(delegate ()
                    {
                        checkBox2.Checked = true;
                    }));
                    updateBannedListboxes();
                } else
                {
                    MessageBox.Show("cos sie cos sie zepsulo");
                }
            }
        }

        //Odbieranie transmisji danych od klienta
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //TcpListener serwer2 = new TcpListener(IPAddress.Parse(textBox1.Text), (int)numericUpDown1.Value);
           // serwer2.Start();
           // TcpClient klient2 = serwer2.AcceptTcpClient();
            //NetworkStream ns = klient2.GetStream();
            
           // serwer2.Stop();
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
            listBoxProcesses.DataSource = File.ReadAllLines(listProcessFile);
            textBoxAddProcesToList.Text = "";
        }

        private void buttonAddDomenToList_Click(object sender, EventArgs e)
        {
            File.AppendAllText(listDomensFile, textBoxAddDomenToList.Text + "\n");
            listBoxDomens.DataSource = File.ReadAllLines(listDomensFile);
            textBoxAddDomenToList.Text = "";
        }

        private void buttonSendCommandProces_Click(object sender, EventArgs e)
        {
            //Do dopisania usuwanie blokad
            string commandArgument = "";
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

                // Zmiana listboxa3 na to samo co ma 2
                if (listBoxClient2.SelectedIndex != listBoxClient3.SelectedIndex)
                {
                    listBoxClient3.Invoke(new Action(delegate ()
                    {
                        listBoxClient3.SelectedIndex = listBoxClient2.SelectedIndex;
                    }));
                }

                if (listBoxClient2.SelectedIndex != listBoxClient4.SelectedIndex)
                {
                    listBoxClient4.Invoke(new Action(delegate ()
                    {
                        listBoxClient4.SelectedIndex = listBoxClient2.SelectedIndex;
                    }));
                }
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

                if (checkBox3.Checked == false)
                {
                    checkBox3.Invoke(new Action(delegate ()
                    {
                        checkBox3.Checked = true;
                    }));
                }
                if (checkBox4.Checked == false)
                {
                    checkBox4.Invoke(new Action(delegate ()
                    {
                        checkBox4.Checked = true;
                    }));
                }
            } else
            {
                if (checkBox3.Checked)
                {
                    checkBox3.Invoke(new Action(delegate ()
                    {
                        checkBox3.Checked = false;
                    }));
                }
                if (checkBox4.Checked)
                {
                    checkBox4.Invoke(new Action(delegate ()
                    {
                        checkBox4.Checked = false;
                    }));
                }
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

            listBoxBannedPA.Invoke(new Action(delegate ()
            {
                listBoxBannedPA.Items.Clear();
            }));

            listBoxBannedDomenaAK.Invoke(new Action(delegate ()
            {
                listBoxBannedDomenaAK.Items.Clear();
            }));

            listBoxBannedDomenaPA.Invoke(new Action(delegate ()
            {
                listBoxBannedDomenaPA.Items.Clear();
            }));

            listBoxBanProcessesAK.Invoke(new Action(delegate ()
            {
                listBoxBanProcessesAK.Items.Clear();
            }));

            listBoxBanProcessesPA.Invoke(new Action(delegate ()
            {
                listBoxBanProcessesPA.Items.Clear();
            }));

            listBoxBanDomensAK.Invoke(new Action(delegate ()
            {
                listBoxBanDomensAK.Items.Clear();
            }));

            listBoxBanDomensPA.Invoke(new Action(delegate ()
            {
                listBoxBanDomensPA.Items.Clear();
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
            listBoxClient2.Invoke(new Action(delegate ()
            {
                if (listBoxClient2.SelectedIndex == -1) return;
            }));

            string clientName = "";

            listBoxClient2.Invoke(new Action(delegate ()
            {
                clientName = listBoxClient2.SelectedItem.ToString();
            }));

            // Procesy
            foreach (string item in listaKlientow.zwrocListeProcesyAktywne(clientName))
            {
                listBoxBannedAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedAK.Items.Add(item);
                }));

                listBoxBanProcessesAK.Invoke(new Action(delegate ()
                {
                    listBoxBanProcessesAK.Items.Add(item);
                }));
            }
            foreach (string item in listaKlientow.zwrocListeProcesyPasywne(clientName))
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedPA.Items.Add(item);
                }));

                listBoxBanProcessesPA.Invoke(new Action(delegate ()
                {
                    listBoxBanProcessesPA.Items.Add(item);
                }));
            }

            //Domeny
            foreach (string item in listaKlientow.zwrocListeDomenyAktywne(clientName))
            {
                listBoxBannedDomenaAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedDomenaAK.Items.Add(item);
                }));

                listBoxBanDomensAK.Invoke(new Action(delegate ()
                {
                    listBoxBanDomensAK.Items.Add(item);
                }));
            }
            foreach (string item in listaKlientow.zwrocListeDomenyPasywne(clientName))
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedDomenaPA.Items.Add(item);
                }));
                listBoxBanDomensPA.Invoke(new Action(delegate ()
                {
                    listBoxBanDomensPA.Items.Add(item);
                }));
            }

            listBoxClient2.Invoke(new Action(delegate ()
            {
                string addresstemp = listaKlientow.NazwaDoIP(listBoxClient2.SelectedItem.ToString());
                if (addresstemp != address)
                {
                    wyslijWiadomosc("SCRSTOP:");
                }
                address = addresstemp;
                wyslijWiadomosc("SCRSTART:");
            }));

        }

        void updateBannedListoxesALL()
        {
            checkBox2.Invoke(new Action(delegate ()
            {
                if (checkBox2.Checked == false) return;
            }));

            // Procesy
            foreach (string item in zabronioneDlaWszystkich.zablokowane_procesy_aktywny)
            {
                listBoxBannedAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedAK.Items.Add(item);
                }));
                listBoxBanProcessesAK.Invoke(new Action(delegate ()
                {
                    listBoxBanProcessesAK.Items.Add(item);
                }));
            }
            foreach (string item in zabronioneDlaWszystkich.zablokowane_procesy_pasywny)
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedPA.Items.Add(item);
                }));
                listBoxBanProcessesPA.Invoke(new Action(delegate ()
                {
                    listBoxBanProcessesPA.Items.Add(item);
                }));
            }

            //Domeny
            foreach (string item in zabronioneDlaWszystkich.zablokowane_domeny_aktywny)
            {
                listBoxBannedAK.Invoke(new Action(delegate ()
                {
                    listBoxBannedDomenaAK.Items.Add(item);
                }));
                listBoxBanDomensAK.Invoke(new Action(delegate ()
                {
                    listBoxBanDomensAK.Items.Add(item);
                }));
            }
            foreach (string item in zabronioneDlaWszystkich.zablokowane_domeny_pasywny)
            {
                listBoxBannedPA.Invoke(new Action(delegate ()
                {
                    listBoxBannedDomenaPA.Items.Add(item);
                }));
                listBoxBanDomensPA.Invoke(new Action(delegate ()
                {
                    listBoxBanDomensPA.Items.Add(item);
                }));
            }

            wyslijWiadomosc("SCRSTOP:");
            address = "1.1.1.1";
            //pictureBox1.Image.Dispose();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                if (checkBox2.Checked == false)
                {
                    checkBox2.Invoke(new Action(delegate ()
                    {
                        checkBox2.Checked = true;
                    }));
                }
                listBoxClient3.Invoke(new Action(delegate ()
                {
                    listBoxClient3.SelectedIndex = -1;
                }));

            } else
            {
                if (checkBox2.Checked == true)
                {
                    checkBox2.Invoke(new Action(delegate ()
                    {
                        checkBox2.Checked = false;
                    }));
                }
            }
        }

        private void listBoxClient3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                listBoxClient3.Invoke(new Action(delegate ()
                {
                    listBoxClient3.SelectedIndex = -1;
                }));

                updateBannedListboxes();

                return;
            }
            else
            {
                if (listBoxClient3.SelectedIndex == -1) { return; }

                if (listBoxClient2.SelectedIndex != listBoxClient3.SelectedIndex)
                {
                    listBoxClient2.Invoke(new Action(delegate ()
                    {
                        listBoxClient2.SelectedIndex = listBoxClient3.SelectedIndex;
                    }));
                }

                if (listBoxClient2.SelectedIndex != listBoxClient4.SelectedIndex)
                {
                    listBoxClient4.Invoke(new Action(delegate ()
                    {
                        listBoxClient4.SelectedIndex = listBoxClient3.SelectedIndex;
                    }));
                }
                updateBannedListboxes();
            }
        }

        private void buttonSendCommandDomena_Click(object sender, EventArgs e)
        {
            //Do dopisania usuwanie blokad
            string commandArgument = "";
            string command = "";

            bool aktywny = false;

            if ((checkBox3.Checked == false) && listBoxClient3.SelectedIndex == -1) return;

            try
            {
                // DODAWANIE BLOKAD
                if (comboBoxChange2.Text == "zabronione")
                {
                    // aktywny
                    if (comboBox1.Text == "Aktywny")
                    {
                        // DODAJ PROCES W TRYBIE AKTYWNYM                            
                        command = "ADD:FW:AK";
                        aktywny = true;

                    }
                    else
                    {
                        command = "ADD:FW:PA";
                        aktywny = false;
                    }
                    // Argumenty
                    foreach (string item in listBoxDomens.SelectedItems)
                    {

                        //WYSYLANIEWIELU
                        //commandArgument = commandArgument + item + ";";

                        commandArgument = item;

                        if (checkBox3.Checked == true)
                        {
                            if (aktywny)
                            {
                                zabronioneDlaWszystkich.zablokowane_domeny_aktywny.Add(item);
                            }
                            else
                            {
                                zabronioneDlaWszystkich.zablokowane_domeny_pasywny.Add(item);
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
                    if (listBoxBannedDomenaAK.SelectedIndex != -1)
                    {
                        // PROCES AKTYWNY
                        command = "DEL:FW:AK";
                        string cmd = listBoxBannedDomenaAK.SelectedItem.ToString();
                        //string[] cmd = listBoxBannedAK.SelectedItem.ToString().Split(new char[] { ':' });
                        commandArgument = cmd;
                    }
                    else if (listBoxBannedDomenaPA.SelectedIndex != -1)
                    {
                        // PROCES AKTYWNY
                        command = "DEL:FW:PA";
                        string cmd = listBoxBannedDomenaPA.SelectedItem.ToString();
                        //string[] cmd = listBoxBannedAK.SelectedItem.ToString().Split(new char[] { ':' });
                        commandArgument = cmd;
                    } else
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                if (checkBox2.Checked == false)
                {
                    checkBox2.Invoke(new Action(delegate ()
                    {
                        checkBox2.Checked = true;
                    }));
                }
                listBoxClient4.Invoke(new Action(delegate ()
                {
                    listBoxClient4.SelectedIndex = -1;
                }));

            }
            else
            {
                if (checkBox2.Checked == true)
                {
                    checkBox2.Invoke(new Action(delegate ()
                    {
                        checkBox2.Checked = false;
                    }));
                }
            }
        }

        private void listBoxClient4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                listBoxClient4.Invoke(new Action(delegate ()
                {
                    listBoxClient4.SelectedIndex = -1;
                }));

                updateBannedListboxes();

                return;
            }
            else
            {
                if (listBoxClient4.SelectedIndex == -1) { return; }

                if (listBoxClient2.SelectedIndex != listBoxClient3.SelectedIndex)
                {
                    listBoxClient2.Invoke(new Action(delegate ()
                    {
                        listBoxClient2.SelectedIndex = listBoxClient4.SelectedIndex;
                    }));
                }

                if (listBoxClient3.SelectedIndex != listBoxClient4.SelectedIndex)
                {
                    listBoxClient3.Invoke(new Action(delegate ()
                    {
                        listBoxClient3.SelectedIndex = listBoxClient4.SelectedIndex;
                    }));
                }
                updateBannedListboxes();
            }
        }

        void wyslijWiadomosc(string command)
        {
            try
            {
                TcpClient klient = new TcpClient(address, 1978);
                NetworkStream ns = klient.GetStream();

                byte[] bufor = Encoding.ASCII.GetBytes(command);
                ns.Write(bufor, 0, bufor.Length);
            }
            catch (Exception)
            {
                // nie wiem po co to
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient klient = new UdpClient(43220);
            while (true)
            {
                try
                {
                    Byte[] bufor = klient.Receive(ref zdalnyIP);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Screenshot.byteArrayToImage(bufor);
                }
                catch(Exception ex)
                {

                }
                Thread.Sleep(50);
            }
        }
    }
}

