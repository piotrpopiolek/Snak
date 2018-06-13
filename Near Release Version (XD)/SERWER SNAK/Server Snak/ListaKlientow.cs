using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Snak
{
    class ListaKlientow
    {
        public List<Klient> listaKlientow = new List<Klient>();

        public void DodajKlienta(string nazwa, string ip)
        {
            listaKlientow.Add(new Klient(nazwa,ip));
        }

        public void UsunKlienta(string ip)
        {
            foreach(Klient klient in listaKlientow)
            {
                if (klient.Ip().Equals(ip))
                {
                    listaKlientow.Remove(klient);
                    return;
                }
            }
        }

        public void UsunWszystkichKlientow()
        {
            this.listaKlientow.Clear();
        }

        public string NazwaDoIP(string nazwa)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa().Equals(nazwa))
                {
                    return klient.Ip();
                }
            }
            return null;
        }

        public string IPDoNazwy(string ip)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Ip().Equals(ip))
                {
                    return klient.Nazwa();
                }
            }
            return null;
        }
        public void dodajProcesAktywny(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajProcesAktywny(nazwaProcesu);
                }
            }
        }

        public void usunProcesAktywny(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.UsunProcesAktywny(nazwaProcesu);
                }
            }
        }

        public void dodajProcesPasywny(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajProcesPasywny(nazwaProcesu);
                }
            }
        }

        public void usunProcesPasywny(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.UsunProcesPasywny(nazwaProcesu);
                }
            }
        }

        public void dodajDomeneAktywna(string nazwaKlienta, string nazwaDomeny)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajDomeneAktywna(nazwaDomeny);
                }
            }
        }

        public void usunDomeneAktywna(string nazwaKlienta, string nazwaDomeny)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.UsunDomeneAktywna(nazwaDomeny);
                }
            }
        }

        public void dodajDomenePasywna(string nazwaKlienta, string nazwaDomeny)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajDomenePasywna(nazwaDomeny);
                }
            }
        }

        public void usunDomenePasywna(string nazwaKlienta, string nazwaDomeny)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.UsunDomenePasywna(nazwaDomeny);
                }
            }
        }

        public string[] zwrocListeProcesyAktywne(string nazwaKlienta)
        {
            foreach(Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    return klient.ZwrocListeZablokowaneProcesyAktywny();
                }
            }
            return null;
        }

        public void ustawCzySprawdzaDyski(string nazwaKlienta, bool czySprawdza)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.sprawdzanieDyskow = czySprawdza;
                }
            }
        }

        public bool zwrocCzySprawdzaDyski(string nazwaKlienta)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    return klient.sprawdzanieDyskow;
                }
            }
            return false;
        }

        public string[] zwrocListeProcesyPasywne(string nazwaKlienta)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    return klient.ZwrocListeZablokowaneProcesyPasywny();
                }
            }
            return null;
        }

        public string[] zwrocListeDomenyAktywne(string nazwaKlienta)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    return klient.ZwrocListeZablokowaneDomenyAktywny();
                }
            }
            return null;
        }

        public string[] zwrocListeDomenyPasywne(string nazwaKlienta)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    return klient.ZwrocListeZablokowaneDomenyPasywny();
                }
            }
            return null;
        }
    }
}
