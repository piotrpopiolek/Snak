using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antycheat
{
    class ProhibitedProcesses
    {
        private List<string> processes;

        public ProhibitedProcesses()
        {
            processes = new List<string>();
        }

        public ProhibitedProcesses(List<string> processesList)
        {
            processes = new List<string>();
        }

        /// <summary>
        /// Returns a list of prohibited processes
        /// </summary>
        /// <returns>List of prohibited processes</returns>
        public List<string> getProhibitedProcesses()
        {
            return processes;
        }

        /// <summary>
        /// Checks whether process is prohibited
        /// </summary>
        /// <param name="name">Name of process</param>
        /// <returns>True if process is prohibited, false otherwise</returns>
        public Boolean isProhibited(string name)
        {
            foreach (string processName in processes)
            {
                if (name.Equals(processName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a new process to a list of prohibited processes
        /// </summary>
        /// <param name="name">Process name</param>
        public void add(string name)
        {
            processes.Add(name);
        }

        /// <summary>
        /// Removes process from a list of prohibited processes
        /// </summary>
        /// <param name="name">Process name</param>
        public void remove(string name)
        {
            processes.Remove(name);
        }
    }
}