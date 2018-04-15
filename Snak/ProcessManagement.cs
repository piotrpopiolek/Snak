using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antycheat
{
    class ProcessManagement
    {
        /// <summary>
        /// Returns array containing all of running processes
        /// </summary>
        /// <returns>Array of running processes</returns>
        public Process[] getProcesses()
        {
            Process[] localAll = Process.GetProcesses();
            return localAll;
        }

        /// <summary>
        /// Checks if prohibited process is running, but is not performing any action.
        /// </summary>
        /// <param name="name">Name of process</param>
        /// <returns>Information whether process is running</returns>
        public String informAboutUsage(String name)
        {
            return checkIfAppIsInUsageAndPerformAction(name,false);
        }

        /// <summary>
        /// Checks if prohibited process is running and kills it.
        /// </summary>
        /// <param name="name">Name of process</param>
        /// <returns>Information about performed action</returns>
        public String informAboutUsageAndKill(String name)
        {
            return checkIfAppIsInUsageAndPerformAction(name,true);
        }

        private String checkIfAppIsInUsageAndPerformAction(String name, Boolean kill)
        {
            foreach (Process process in getProcesses())
            {
                if (process.ProcessName.Equals(name))
                {
                    try
                    {
                        showError(process.ProcessName);
                        if (kill)
                        {
                            process.Kill();
                            return "Zamknieto niedozwolona aplikacje: " + process.ProcessName;
                        }
                        return "Wlaczono niedozwolona aplikacje: " + process.ProcessName;
                    }
                    catch (Exception e)
                    {
                        return "Wystapil blad podczas zamykania aplikacji";
                    }
                }
            }
            return "Dana aplikacja nie jest otwarta";
        }

        private void showError(String name)
        {

            MessageBox.Show(name + " należy do programów zabronionych", "Antycheat",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}