using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antycheat
{
    class ProhibitedProcesses
    {
        private static List<string> processes = new List<string>();
        private static System.Object lockThis = new System.Object();

        private ProhibitedProcesses()
        {
        }

        public static bool Contains(string name)
        {
            if (processes.Contains(name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets a list of prohibited processes
        /// </summary>
        /// <param name="prohibitedProcesses">List of prohibited processes</param>
        public static void setProhibitedProcesses(List<string> prohibitedProcesses)
        {
            lock (lockThis)
            {
                processes = prohibitedProcesses;
            }
        }

        /// <summary>
        /// Returns a list of prohibited processes
        /// </summary>
        /// <returns>List of prohibited processes</returns>
        public static List<string> getProhibitedProcesses()
        {
            lock (lockThis) { 
                return processes;
            }
        }

        /// <summary>
        /// Checks whether process is prohibited
        /// </summary>
        /// <param name="name">Name of process</param>
        /// <returns>True if process is prohibited, false otherwise</returns>
        public static Boolean isProhibited(string name)
        {
            lock (lockThis)
            {
                foreach (string processName in processes)
                {
                    if (name.Equals(processName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a new process to a list of prohibited processes
        /// </summary>
        /// <param name="name">Process name</param>
        public static void add(string name)
        {
            lock (lockThis)
            {
                if (!processes.Contains(name))
                {
                    processes.Add(name);
                }
            }
        }

        /// <summary>
        /// Removes process from a list of prohibited processes
        /// </summary>
        /// <param name="name">Process name</param>
        public static void remove(string name)
        {
            lock (lockThis)
            {
                if (processes.Contains(name))
                {
                    processes.Remove(name);
                }
            }
        }
    }
}
