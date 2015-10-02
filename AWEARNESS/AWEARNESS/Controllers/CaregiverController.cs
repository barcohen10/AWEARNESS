using AWEARNESS.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWEARNESS.Controllers
{
    public class CaregiverController : Controller
    {
        //
        // GET: /Caregiver/

        public ActionResult Index(string qrCodeId)
        {
            User user = UserMng.Instance.GetUserByQRCode(qrCodeId);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
