using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Snak
{
    class Klient
    {
        private string nazwa;

        private string ip;

        public List<string> zablokowane_domeny_aktywny = new List<string>();

        public List<string> zablokowane_domeny_pasywny = new List<string>();

        public List<string> zablokowane_procesy_aktywny = new List<string>();

        public List<string> zablokowane_procesy_pasywny = new List<string>();

        public Klient(string nazwa, string ip)
        {
            this.nazwa = nazwa;
            this.ip = ip;
        }

        /// <summary>
        /// Zwraca nazwe kleinta
        /// </summary>
        public string Nazwa()
        {
            return nazwa;
        }

        /// <summary>
        /// Zwraca IP klienta
        /// </summary>
        public string Ip()
        {
            return ip;
        }

        // Proces Aktywny

        public void DodajProcesAktywny(string nazwaProcesu)
        {
            zablokowane_procesy_aktywny.Add(nazwaProcesu);
        }

        public void UsunProcesAktywny(string nazwaProcesu)
        {
            zablokowane_procesy_aktywny.Remove(nazwaProcesu);
        }

        // Proces Pasywny

        public void DodajProcesPasywny(string nazwaProcesu)
        {
            zablokowane_procesy_pasywny.Add(nazwaProcesu);
        }

        public void UsunProcesPasywny(string nazwaProcesu)
        {
            zablokowane_procesy_pasywny.Remove(nazwaProcesu);
        }

        // Domena Aktywna

        public void DodajDomeneAktywna(string nazwaDomeny)
        {
            zablokowane_domeny_aktywny.Add(nazwaDomeny);
        }

        public void UsunDomeneAktywna(string nazwaDomeny)
        {
            zablokowane_domeny_aktywny.Remove(nazwaDomeny);
        }

        // Domena Pasywna

        public void DodajDomenePasywna(string nazwaDomeny)
        {
            zablokowane_domeny_pasywny.Add(nazwaDomeny);
        }

        public void UsunDomenePasywna(string nazwaDomeny)
        {
            zablokowane_domeny_pasywny.Remove(nazwaDomeny);
        }

        public string[] ZwrocListeZablokowaneDomenyAktywny()
        {
            return zablokowane_domeny_aktywny.ToArray();
        }

        public string[] ZwrocListeZablokowaneDomenyPasywny()
        {
            return zablokowane_domeny_pasywny.ToArray();
        }

        public string[] ZwrocListeZablokowaneProcesyAktywny()
        {
            return zablokowane_procesy_aktywny.ToArray();
        }

        public string[] ZwrocListeZablokowaneProcesyPasywny()
        {
            return zablokowane_procesy_pasywny.ToArray();
        }
    }
}
