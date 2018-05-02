using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;

using PcapDotNet.Packets.IpV4;
using System.Threading;

namespace ConsoleApplication11
{
    // Wymaga Winpacap
    /*
    Niuchacz niuchacz = new Niuchacz();
    var Watek_Niuchania = new System.Threading.Thread(niuchacz.Start);
    Watek_Niuchania.Start();
    ...
    niuchacz.Stop();
    Watek_Niuchania.Join();
    */
    class Niuchacz
    {
        private static object Zamek_Kolejki_Pakietow = new object();
        private static object Zamek_Listy_hostow = new object();
        private static List<Packet> Kolejka_Pakietów = new List<Packet>();
        private static bool Zatrzymaj_Przetwarzanie_W_Tle = false;
        private static bool Black_List = false;
        private static bool White_List = false;
        private static bool Naruszono_White_List = false;
        private static bool Naruszono_Black_List = false;

        private static List<PacketCommunicator> Komunikatory = new List<PacketCommunicator>();
        private static List<string> Lista_Adresow = new List<string>();
        private static List<string> Lista_Hostow = new List<string>();
        private static List<string> Lista_Hostow_Zabronionych = new List<string>();
        private static List<string> Lista_Hostow_Dozwolonych = new List<string>();
        private static List<string> Lista_Naruszen_Czarnej_Listy = new List<string>();
        private static List<string> Lista_Naruszen_Bialej_Listy = new List<string>();

        private static List<byte> bity = new List<byte>();

        public bool Tryb_Czarnej_Listy
        {
            get
            {
                return Black_List;
            }

            set
            {
                Black_List = value;
            }
        }

        public bool Tryb_Bialej_Listy
        {
            get
            {
                return White_List;
            }

            set
            {
                White_List = value;
            }
        }
        public bool Naruszono_Czarna_Liste()
        {
            return Naruszono_Black_List;
        }
        public bool Naruszono_Biala_Liste()
        {
            return Naruszono_White_List;
        }

        public List<string> Zwroc_Lista_Hostow()
        {
            lock (Zamek_Listy_hostow)
            { return Lista_Hostow; }
        }
        public List<string> Zwroc_Lista_Hostow_Zabronionych()
        {
            lock (Zamek_Listy_hostow)
            { return Lista_Hostow_Zabronionych; }
        }
        public List<string> Zwroc_Lista_Hostow_Dozwolonych()
        {
            lock (Zamek_Listy_hostow)
            { return Lista_Hostow_Dozwolonych; }
        }
        public List<string> Zwroc_Lista_Naruszen_Czarnej_Listy()
        {
            lock (Zamek_Listy_hostow)
            { return Lista_Naruszen_Czarnej_Listy; }
        }
        public List<string> Zwroc_Lista_Naruszen_Bialej_Listy()
        {
            lock (Zamek_Listy_hostow)
            { return Lista_Naruszen_Bialej_Listy; }
        }
        public void Wczytaj_Lista_Hostow_Zabronionych(List<string> zabronione)
        {
            lock (Zamek_Listy_hostow)
            { Lista_Hostow_Zabronionych = zabronione; }
        }
        public void Wczytaj_Lista_Hostow_Dozwolonych(List<string> dozwolone)
        {
            lock (Zamek_Listy_hostow)
            { Lista_Hostow_Dozwolonych = dozwolone; }
        }
        public void Dodaj_Lista_Hostow_Zabronionych(string zabronione)
        {
            lock (Zamek_Listy_hostow)
            { Lista_Hostow_Zabronionych.Add(zabronione); }
        }
        public void Dodaj_Lista_Hostow_Dozwolonych(string dozwolone)
        {
            lock (Zamek_Listy_hostow)
            { Lista_Hostow_Dozwolonych.Add(dozwolone); }
        }

        public void Start()
        {
            IList<LivePacketDevice> Lista_Kart_Sieciowych = LivePacketDevice.AllLocalMachine;
            List<Thread> Watki_Komunikatorow = new List<Thread>();
            var Watek_Przetwarzania_W_Tle = new System.Threading.Thread(Przetwarzanie_W_Tle);
            Watek_Przetwarzania_W_Tle.Start();
            foreach (LivePacketDevice karta_sieciowa in Lista_Kart_Sieciowych)
            {
                Komunikatory.Add(
                   karta_sieciowa.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000));
                Console.WriteLine("Nasluchiwanie na " + karta_sieciowa.Description + "...");
            }

            foreach (PacketCommunicator Komunikator in Komunikatory)
            {
                Komunikator.SetFilter("ip and (tcp port 80 or tcp port 443)");
                Watki_Komunikatorow.Add(new Thread(()=>Watek_Komunikatora(Komunikator)));
                Watki_Komunikatorow.Last().Start();
            }
            foreach (Thread Watek in Watki_Komunikatorow)
            {
                Watek.Join();
            }
            Zatrzymaj_Przetwarzanie_W_Tle = true;
            Watek_Przetwarzania_W_Tle.Join();
        }
        public void Stop()
        {
            foreach (PacketCommunicator Komunikator in Komunikatory)
            {
                Komunikator.Break();
            }
        }
        private static void Watek_Komunikatora(PacketCommunicator Komunikator)
        {
            Komunikator.ReceivePackets(0, Obsluga_Pakietow);
            Komunikator.Dispose();
        }
            private static void Obsluga_Pakietow(Packet pakiet)
        {
            lock (Zamek_Kolejki_Pakietow)
            {
                Kolejka_Pakietów.Add(pakiet);
            }
        }

        private static void Przetwarzanie_W_Tle()
        {
            while (!Zatrzymaj_Przetwarzanie_W_Tle)
            {
                bool Czekaj_Na_Pakiety = true;

                lock (Zamek_Kolejki_Pakietow)
                {
                    if (Kolejka_Pakietów.Count != 0)
                    {
                        Czekaj_Na_Pakiety = false;
                    }
                }

                if (Czekaj_Na_Pakiety)
                {
                    System.Threading.Thread.Sleep(250);
                }
                else
                {
                    List<Packet> Przetwarzana_Fragment_Kolejki;
                    lock (Zamek_Kolejki_Pakietow)
                    {
                        Przetwarzana_Fragment_Kolejki = Kolejka_Pakietów;
                        Kolejka_Pakietów = new List<Packet>();
                    }

                    foreach (var pakiet in Przetwarzana_Fragment_Kolejki)
                    {
                        if (pakiet.Ethernet.IpV4.Protocol.ToString() == "Tcp")
                        {
                            if (pakiet.Ethernet.IpV4.Tcp.DestinationPort == 80 && pakiet.Ethernet.IpV4.Tcp.Http.Header != null)
                            {
                                PcapDotNet.Packets.Http.HttpHeader Naglowek_HTTP = pakiet.Ethernet.IpV4.Tcp.Http.Header;
                                List<PcapDotNet.Packets.Http.HttpField> Lista_Pol_Http = Naglowek_HTTP.ToList();
                                if (Lista_Pol_Http.Count() > 0)
                                {
                                    for (int i = 0; i < Lista_Pol_Http.Count(); i++)
                                        if (Lista_Pol_Http[i].Name == "Host")
                                        {
                                            lock (Zamek_Listy_hostow)
                                            {
                                                if (Lista_Hostow_Zabronionych.Contains(Lista_Pol_Http[i].ValueString) && Black_List)
                                                {
                                                    Naruszono_Black_List = true;
                                                    Lista_Naruszen_Czarnej_Listy.Add(Lista_Pol_Http[i].ValueString + "|" + pakiet.Timestamp.ToString());
                                                    Console.WriteLine("Wykryto Naruszenie Czarnej Listy - Host: " + Lista_Pol_Http[i].ValueString+" "+ pakiet.Timestamp.ToString());
                                                }
                                                if (!Lista_Hostow_Dozwolonych.Contains(Lista_Pol_Http[i].ValueString) && White_List)
                                                {
                                                    Naruszono_White_List = true;
                                                    Lista_Naruszen_Bialej_Listy.Add(Lista_Pol_Http[i].ValueString + "|" + pakiet.Timestamp.ToString());
                                                    Console.WriteLine("Wykryto Naruszenie Bialej Listy - Host: " + Lista_Pol_Http[i].ValueString + " " + pakiet.Timestamp.ToString());
                                                }
                                                if (!Lista_Hostow.Contains(Lista_Pol_Http[i].ValueString))
                                                {
                                                    Lista_Hostow.Add(Lista_Pol_Http[i].ValueString);
                                                    Console.WriteLine("Host: " + Lista_Pol_Http[i].ValueString);
                                                }
                                            }
                                        }
                                }
                            }
                            else
                                if (pakiet.Ethernet.IpV4.Tcp.DestinationPort == 443 && pakiet.Ethernet.IpV4.Tcp.PayloadLength != 0)
                            {
                                Datagram data = pakiet.Ethernet.IpV4.Tcp.Payload;
                                string data_string = data.ToHexadecimalString();
                                bity = data.ToList();
                                if (bity[0] == 0x16 && bity[5] == 1)
                                {
                                    int x = 43;
                                    int d = 0;
                                    string host = "";
                                    x += bity[x] + 1;
                                    x += bity[x] * 256 + bity[x + 1] + 2;
                                    x += bity[x] + 1;
                                    x += 2;
                                    while(bity[x]!=0 || bity[x+1]!=0)
                                    {
                                        x += 2;
                                        x += bity[x] * 256 + bity[x + 1] + 2;
                                    }
                                    x += 2;
                                    x += 5;
                                    d += bity[x] * 256 + bity[x + 1];
                                    x += 2;
                                    for (int i = 0; i < d; i++)
                                        host += (char)bity[x + i];
                                    lock (Zamek_Listy_hostow)
                                    {
                                        if (Lista_Hostow_Zabronionych.Contains(host) && Black_List)
                                        {
                                            Naruszono_Black_List = true;
                                            Lista_Naruszen_Czarnej_Listy.Add(host + "|" + pakiet.Timestamp.ToString());
                                            Console.WriteLine("Wykryto Naruszenie Czarnej Listy - Host: " + host + " " + pakiet.Timestamp.ToString());
                                        }
                                        if (!Lista_Hostow_Dozwolonych.Contains(host) && White_List)
                                        {
                                            Naruszono_White_List = true;
                                            Lista_Naruszen_Bialej_Listy.Add(host + "|" + pakiet.Timestamp.ToString());
                                            Console.WriteLine("Wykryto Naruszenie Bialej Listy - Host: " + host + " " + pakiet.Timestamp.ToString());
                                        }
                                        if (!Lista_Hostow.Contains(host))
                                        {
                                            Lista_Hostow.Add(host);
                                            Console.WriteLine("Host: " + host);
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Niuchacz niuchacz = new Niuchacz();
            niuchacz.Tryb_Bialej_Listy = true;
            var Watek_Niuchania = new System.Threading.Thread(niuchacz.Start);
            Watek_Niuchania.Start();
            Console.ReadKey();
            niuchacz.Wczytaj_Lista_Hostow_Dozwolonych(niuchacz.Zwroc_Lista_Hostow());
            Console.ReadKey();
            niuchacz.Tryb_Bialej_Listy = false;
            niuchacz.Tryb_Czarnej_Listy = true;
            niuchacz.Wczytaj_Lista_Hostow_Zabronionych(niuchacz.Zwroc_Lista_Hostow());
            Console.ReadKey();
            niuchacz.Stop();
            Watek_Niuchania.Join();
        }
        
    }
}
