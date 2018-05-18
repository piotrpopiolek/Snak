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
    }
}
