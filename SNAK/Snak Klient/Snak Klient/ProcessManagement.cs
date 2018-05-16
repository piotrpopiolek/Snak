using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Antycheat
{
    class ProcessManagement
    {

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
                        // tutaj poinformuj serwer o zlamaniu zakazu
                    }
                }
                Thread.Sleep(3000);
            }
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
            MessageBox.Show("Program należy do programów zabronionych", "Antycheat",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}