using AWEARNESS.Models.Repository;
using AWEARNESS.Models.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [HttpPost]
        public string Subscribe(string email)
        {
            string returnValue = "false";
            EmailAddressAttribute emailValidator = new EmailAddressAttribute();
            if (!string.IsNullOrEmpty(email) && !email.Equals("your@email.com") && emailValidator.IsValid(email))
            {
                SubscriberMng.Instance.CreateQRCode(email, this);
                returnValue = "true";
            }
            return returnValue;
        }

    }
}
