using AWEARNESS.Models.Repository;
using AWEARNESS.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWEARNESS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Subscribe(Subscriber subscriber)
        //{
        //    return "";
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Subscribe(string email)
        {
            SubscriberMng.Instance.CreateQRCode(email,this);
        }

    }
}
