﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWEARNESS.Models.Repository;
using System.IO;
using Newtonsoft.Json;

namespace AWEARNESS.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(UserMng.Instance.AllUsers);
        }
      public  AwearnessDB m_AwearnessDB = new AwearnessDB();
        public ActionResult GetImage(string userid)
        {
            var dir = Server.MapPath("/Images/UsersProfiles");
            var path = Path.Combine(dir, userid + ".jpg");
            return base.File(path, "image/jpeg");
        }
        [HttpGet]
        public JsonResult GetContacts(string userid)
        {
            string data = string.Empty;
            List<string> contactStrings = new List<string>();
            List<UserContacts> contacts = m_AwearnessDB.UserContacts.Where(x => x.UserId == userid).ToList();
           User contact=null;
            foreach(UserContacts userContact in contacts)
            {
                contact = UserMng.Instance.GetUser(userContact.ContactUserId);
                contactStrings.Add("[" + userContact.Relationship + "] " + contact.FirstName + " " + contact.LastName);
            }
       

                if (contactStrings.Count >0)
                {
                    data = JsonConvert.SerializeObject(new { contacts = contactStrings });
                }
                return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Registration = DateTime.Now;
                UserMng.Instance.CreateUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(string id = null)
        {
            User user = UserMng.Instance.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserMng.Instance.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(string id = null)
        {
            User user = UserMng.Instance.GetUserFromDB(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserMng.Instance.DeleteUser(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
