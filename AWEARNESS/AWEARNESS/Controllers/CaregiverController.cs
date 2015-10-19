﻿using AWEARNESS.Models.Repository;
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

        public ActionResult Index(string qrCodeId, string password)
        {
            User user = UserMng.Instance.GetUserByQRCode(qrCodeId);
            if (user == null || !QrCodeMng.Instance.IsPasswordOk(qrCodeId, password))
            {
                return HttpNotFound();
            }

        
            return View(user);
        }

        public ActionResult Login(string qrCodeId)
        {
            return View();
        }

        public ActionResult CaregiverEvent()
        {
            return View();
        }

        [HttpGet]
        public string IsQRCodePasswordOk(string qrCodeId, string password)
        {
            return QrCodeMng.Instance.IsPasswordOk(qrCodeId, password).ToString();
        }


    }
}
