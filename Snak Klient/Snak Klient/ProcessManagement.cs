using System;
using Snak_Klient;

using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace Antycheat
{
    class ProcessManagement
    {
        string serwerAddress;

        string clientAddress;
        /* private Socket clientSocket;

         public ProcessManagement(Socket clientSocket)
         {
             this.clientSocket = clientSocket;
         }*/

        /// <summary>
        /// Guards client and inform server about illegal actions (works in infinite loop)
        /// </summary>

        ~ProcessManagement()
        {
            Thread.CurrentThread.Abort();
        }

        public ProcessManagement(string address, string address2)
        {
            serwerAddress = address;
            clientAddress = address2;
        }



        public void guardAggressive()
        {
            while (true)
            {
                List<String> prohibited = ProhibitedProcesses.getProhibitedProcesses();
                for (int i = 0; i < prohibited.Count; i++)
                {
                    Process[] listOfProcesses = Process.GetProcessesByName(prohibited[i]);
                    for (int j = 0; j < listOfProcesses.Length; j++)
                    {
                        try
                        {
                            listOfProcesses[j].Kill();
                            // tutaj poinformuj serwer o zlamaniu zakazu
                            //ThreadStart childref = new ThreadStart(showError);
                            //Thread childThread = new Thread(childref);
                            showError();
                            //childThread.Start();
                            WyslijWiadomoscUDP("NAR:" + clientAddress + ":PS:AK:" + listOfProcesses[j].ToString() + ":");
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                    }
                }
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        ///  Informs server about illegal actions (works in infinite loop)
        /// </summary>
        public void guardPassive()
        {
            while (true)
            {
                List<String> prohibited = ProhibitedProcesses.getProhibitedProcesses();
                for (int i = 0; i < prohibited.Count; i++)
                {
                    Process[] listOfProcesses = Process.GetProcessesByName(prohibited[i]);
                    for (int j = 0; j < listOfProcesses.Length; j++)
                    {
                        WyslijWiadomoscUDP("NAR:" + clientAddress + ":PS:PA:" + listOfProcesses[j].ToString() + ":");
                    }
                }
                Thread.Sleep(3000);
            }
        }
        private void WyslijWiadomoscUDP(string wiadomosc)
        {
            UdpClient klient = new UdpClient(serwerAddress, 43210);
            byte[] bufor = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(bufor, bufor.Length);
            klient.Close();
        }

        /// <summary>
        /// Returns array containing all of running processes
        /// </summary>
        /// <returns>Array of running processes</returns>
        public Process[] getProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            return localAll;
        }

        private void showError()
        {
            //MessageBox.Show("Program należy do programów zabronionych", "Antycheat",
                            //MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}