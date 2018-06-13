using System;
using System.Windows;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using NETCONLib;
using NetFwTypeLib;
using System.Windows.Forms;

namespace FWCtrl
{
    class FirewallController
    {
        // idk what it is but without this code does not compile XD
        const string guidFWPolicy2 = "{E2B3C97F-6AE1-41AC-817A-F6F92166D7DD}";
        const string guidRWRule = "{2C5BC43E-3369-4C33-AB0C-BE9469677AF4}";
        private const string CLSID_FIREWALL_MANAGER = "{304CE942-6E39-40D8-943A-B913C40C9CD4}";

        // list of blocked domains
        List<string> rulesDomains = new List<string>();


        public FirewallController()
        {
            INetFwMgr manager = GetFirewallManager();


            // checking if windows firewall is enabled
            bool isFirewallEnabled = manager.LocalPolicy.CurrentProfile.FirewallEnabled;

            // if it is disabled >> we enable it
            if (isFirewallEnabled) manager.LocalPolicy.CurrentProfile.FirewallEnabled = true;
        }

        // Delete all rules added during the program runtime
        ~FirewallController()
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            foreach (string domain in rulesDomains)
            {
                string address = Dns.GetHostAddresses(domain)[0].ToString();
                //RULE IN
                firewallPolicy.Rules.Remove("SNAK_" + address);
                //RULE OUT
                firewallPolicy.Rules.Remove("SNAK_" + address);
            }
            rulesDomains.Clear();
        }

        public void displayrulesDomains()
        {
            foreach (string domain in rulesDomains)
            {
                MessageBox.Show(domain);
            }
        }

        public void CleanUpRules()
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            foreach (string domain in rulesDomains)
            {
                string address = Dns.GetHostAddresses(domain)[0].ToString();
                //RULE IN
                firewallPolicy.Rules.Remove("SNAK_" + address);
                //RULE OUT
                firewallPolicy.Rules.Remove("SNAK_" + address);
            }
            rulesDomains.Clear();
        }


        // I dont even know what does it do, but again - it is essential for checking if firewall is enabled
        private static NetFwTypeLib.INetFwMgr GetFirewallManager()
        {
            Type objectType = Type.GetTypeFromCLSID(new Guid(CLSID_FIREWALL_MANAGER));
            return Activator.CreateInstance(objectType) as NetFwTypeLib.INetFwMgr;
        }
        /// <summary>
        /// Add firewall rule
        /// </summary>
 
        public bool Contains(string name)
        {
            if (rulesDomains.Contains(name))
            {
                return true;
            }
            return false;
        }

        public void AddRule(string domain)
        {
            if (rulesDomains.Contains(domain))
            {
                return;
            }
            else
            {
                // variables
                Type typeFWPolicy2 = Type.GetTypeFromCLSID(new Guid(guidFWPolicy2));
                Type typeFWRule = Type.GetTypeFromCLSID(new Guid(guidRWRule));
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
                INetFwRule newRule = (INetFwRule)Activator.CreateInstance(typeFWRule);
                INetFwRule newRule2 = (INetFwRule)Activator.CreateInstance(typeFWRule);
                
                // change domain name to ip
                string address = Dns.GetHostAddresses(domain)[0].ToString();

                //RULE IN
                newRule.Name = "SNAK_" + address;
                newRule.Description = "Website blocker by SNAK";
                newRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                newRule.RemoteAddresses = address;
                newRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                newRule.Enabled = true;
                newRule.Grouping = "@firewallapi.dll,-23255";
                newRule.Profiles = fwPolicy2.CurrentProfileTypes;
                newRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                fwPolicy2.Rules.Add(newRule);

                //RULE OUT
                newRule2.Name = "SNAK_" + address;
                newRule2.Description = "Website blocked by SNAK";
                newRule2.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                newRule2.RemoteAddresses = address;
                newRule2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                newRule2.Enabled = true;
                newRule2.Grouping = "@firewallapi.dll,-23255";
                newRule2.Profiles = fwPolicy2.CurrentProfileTypes;
                newRule2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                fwPolicy2.Rules.Add(newRule2);

                rulesDomains.Add(domain);
            }
        }

        /// <summary>
        /// Delete firewall rule
        /// </summary>
        public void DeleteRule(string domain)
        {
            if (rulesDomains.Contains(domain))
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                string address = Dns.GetHostAddresses(domain)[0].ToString();

                //RULE IN
                firewallPolicy.Rules.Remove("SNAK_" + address);
                //RULE OUT
                firewallPolicy.Rules.Remove("SNAK_" + address);

                rulesDomains.Remove(domain);
            }
        }
    }
}
