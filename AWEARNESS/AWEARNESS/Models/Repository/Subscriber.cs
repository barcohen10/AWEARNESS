using AWEARNESS.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AWEARNESS.Models.Repository
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
    }
    public class SubscriberMng
    {
        private static SubscriberMng m_Instance;
        private AwearnessDB m_DB = new AwearnessDB();

        public static SubscriberMng Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new SubscriberMng();
                }
                return m_Instance;
            }
        }


        public void CreateQRCode(string i_Email,Controller i_Controller)
        {
            Subscriber sub= new Subscriber();
            sub.Time=DateTime.Now;
            sub.Id = Guid.NewGuid();
            sub.Email=i_Email;
            sub.IP = NetworkUtilites.Instance.getUserIP(i_Controller);
            m_DB.Subscribers.Add(sub);
            m_DB.SaveChanges();
        }

    }
}
