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
                    klient.DodajProcesAktywny(nazwaKlienta);
                }
            }
        }

        public void dodajProcesPasywny(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajProcesPasywny(nazwaKlienta);
                }
            }
        }

        public void dodajDomeneAktywna(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajDomeneAktywna(nazwaKlienta);
                }
            }
        }

        public void dodajDomenePasywna(string nazwaKlienta, string nazwaProcesu)
        {
            foreach (Klient klient in listaKlientow)
            {
                if (klient.Nazwa() == nazwaKlienta)
                {
                    klient.DodajDomenePasywna(nazwaKlienta);
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

        public string[] zwrocListeDomenyPasywny(string nazwaKlienta)
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
