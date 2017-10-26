using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntity.Implementation;
using BusinessEntity.Interface;
using EntityCore.Mappings;
using Utility;
using System.Web.Security;
using OnlineLibraryKnockOut.Models;

namespace OnlineLibraryKnockOut.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminModel user)
        {
            if (ModelState.IsValid)
            {
                if (new GeneralLoginHelper().LoginValidation(user.Email_Id, user.Password, user.Type))
                {
                    FormsAuthentication.SetAuthCookie(user.Email_Id, true);
                    if(user.Type == "Librarian")
                        return RedirectToAction("Index", "Admin/AdminHome");
                    else
                        return RedirectToAction("Index", "Student/stdHome");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}