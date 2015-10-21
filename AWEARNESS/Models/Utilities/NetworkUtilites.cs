using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWEARNESS.Models.Utilities
{
    public class NetworkUtilites
    {
          private static NetworkUtilites m_Instance;
          private NetworkUtilites()
        {

        }
          public static NetworkUtilites Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new NetworkUtilites();
                }
                return m_Instance;
            }
        }
 
        public string getUserIP(Controller i_Controller)
        {
            string ipList = i_Controller.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return i_Controller.Request.ServerVariables["REMOTE_ADDR"];
        }
        public string getHostnameFromIP(string i_ip)
        {
            string hostname = string.Empty;
            try
            {
                System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(i_ip);
                hostname = ip.HostName;
            }
            catch (Exception ex)
            {

            }
            return hostname;
        }
    }

}