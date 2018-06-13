using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Monitor_Dysku
{
        public class Monitor_Dysku
        {
            string serwerAddress;
            bool dzialanie = true;
            bool zmieniono_liste_dyskow = false;
            int Liczba_Dysków = 0;
            DriveInfo[] Pierwotna_Lista_Dyskow;
            string Aktualna_Lista_Dyskow = "";
            string Pierwotna_Lista_Dyskow_S ="";
            public Monitor_Dysku(string Server_Adres)
            {
                serwerAddress = Server_Adres;
                Pierwotna_Lista_Dyskow = DriveInfo.GetDrives();
                Liczba_Dysków = Pierwotna_Lista_Dyskow.Count();
                DriveInfo Dysk;
                Aktualna_Lista_Dyskow = "";
                for ( int i = 0;i< Pierwotna_Lista_Dyskow.Count();i++)
                {
                    Dysk = Pierwotna_Lista_Dyskow[i];
                    if (Dysk.IsReady == true)
                    {
                        Aktualna_Lista_Dyskow += (i + 1).ToString() + '|' + Dysk.Name + '|' + Dysk.DriveType + '\n';
                    }
                }
                Pierwotna_Lista_Dyskow_S = Aktualna_Lista_Dyskow;
            }
            public void Sprawdzanie()
            {
                while(dzialanie)
                {
                    DriveInfo[] Dyski = DriveInfo.GetDrives();
                    if (Liczba_Dysków != Dyski.Count())
                        zmieniono_liste_dyskow = true;
                    else
                        for (int i = 0; i < Dyski.Count();i++)
                        {
                            if(Dyski[i].Name!= Dyski[i].Name)
                                zmieniono_liste_dyskow = true;
                        }
                    if (zmieniono_liste_dyskow)
                    {
                        DriveInfo Dysk;
                        Aktualna_Lista_Dyskow = "";
                        for (int i = 0; i < Pierwotna_Lista_Dyskow.Count();i++)
                        {
                            Dysk = Pierwotna_Lista_Dyskow[i];
                            if (Dysk.IsReady == true)
                            {
                                Aktualna_Lista_Dyskow += (i+1).ToString() + '|' + Dysk.Name + '|' + Dysk.DriveType + '\n';

                            }
                        }
                    //////////////////////////////////////// Do Zmiany 
                    //WyslijWiadomoscUDP("NAR:" + clientAddress + ":PS:PA:" + listOfProcesses[j].ToString() + ":");
                    MessageBox.Show("asdasd");//jeżeli chcecie by ta wiadomość byłą wyświetlana raz zamieśćcie następującą linie: Aktualizuj_Pierwotna_Liste_Dyskow()
                    Aktualizuj_Pierwotna_Liste_Dyskow();
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            public void Zatrzymaj_Sprawdzanie()
            {
                dzialanie = false;
            }
            public bool Czy_Wykryto_Zmiane_Lczby_Dyskow()
            {
                return zmieniono_liste_dyskow;
            }
            public void Aktualizuj_Pierwotna_Liste_Dyskow()
            {
                Pierwotna_Lista_Dyskow = DriveInfo.GetDrives();
                zmieniono_liste_dyskow = false;
                Liczba_Dysków = Pierwotna_Lista_Dyskow.Count();
            }
            public string Zwroc_Aktualna_Liste_Dyskow()
            {
                return Aktualna_Lista_Dyskow;
            }

            public string Zwroc_Pierwotna_Liste_Dyskow()
            {
                return Pierwotna_Lista_Dyskow_S;
            }
            private void WyslijWiadomoscUDP(string wiadomosc)
            {
                UdpClient klient = new UdpClient(serwerAddress, 43210);
                byte[] bufor = Encoding.ASCII.GetBytes(wiadomosc);
                klient.Send(bufor, bufor.Length);
                klient.Close();
            }

        }
        /*static void Main(string[] args)
        {
            Monitor_Dysku Sprawdzacz = new Monitor_Dysku();
            
            var Watek_Monitorowania_Dykow = new System.Threading.Thread(Sprawdzacz.Sprawdzanie);
            Watek_Monitorowania_Dykow.Start();
            Console.Write(Sprawdzacz.Zwroc_Aktualna_Liste_Dyskow());
            Console.ReadKey();
            Console.Write(Sprawdzacz.Zwroc_Aktualna_Liste_Dyskow());
            if(Sprawdzacz.Czy_Wykryto_Zmiane_Lczby_Dyskow())
            {
                Console.Write("Wykryto zmiane w liście dyskow.\nPierwotna Lista To:\n"+Sprawdzacz.Zwroc_Pierwotna_Liste_Dyskow());
            }
            Console.ReadKey();

            Sprawdzacz.Zatrzymaj_Sprawdzanie();
            Watek_Monitorowania_Dykow.Join();
        }*/
    }
