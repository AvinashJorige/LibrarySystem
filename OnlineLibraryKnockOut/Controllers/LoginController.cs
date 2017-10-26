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
using System.Security.Principal;
using EntityCore.Core;

namespace OnlineLibraryKnockOut.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();
            return View();
        }

        //GET: EnsureLoggedOut
        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminModel user)
        {
            string OldHASHValue = string.Empty;

            if (ModelState.IsValid)
            {

                UserModelCore _core = new GeneralLoginHelper().LoginValidation(user.Email_Id, user.Password, user.Type);
                if (_core != null)
                {
                    var username = _core.Email_Id != null ? _core.Email_Id : _core.Email_Id;
                    OldHASHValue = _core.HashKey == null ? new Cipher().Encrypt(username + _core.Password) : _core.HashKey;

                    bool isLogin = new GeneralLoginHelper().CompareHashValue(username, _core.Password, OldHASHValue);
                    if (isLogin)
                    {
                        //Login Success
                        //For Set Authentication in Cookie (Remeber ME Option)
                        SignInRemember(username, user.isRemember);

                        Session["User_EntryDate"] = _core.EntryDate;
                        //Set A Unique ID in session
                        if (user.Type == "Librarian")
                        {
                            Session["User_Email"] = _core.Email_Id;
                            Session["User_Name"] = _core.UserName;
                            Session["UserID"] = _core.AID;
                            return RedirectToAction("Index", "Admin/AdminHome");
                        }
                        else
                        {
                            Session["User_Email"] = _core.Email;
                            Session["User_Name"] = _core.StudentName;
                            Session["UserID"] = _core.SID;
                            return RedirectToAction("Index", "Student/stdHome");
                        }
                    }
                    else
                    {
                        //Login Fail
                        ModelState.AddModelError("", "Login data is incorrect!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        //GET: SignInAsync
        private void SignInRemember(string userName, bool isPersistent = false)
        {
            try
            {
                // Clear any lingering authencation data
                FormsAuthentication.SignOut();

                // Write the authentication cookie
                FormsAuthentication.SetAuthCookie(userName, isPersistent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET: RedirectToLocal
        private ActionResult RedirectToLocal(string returnURL = "")
        {
            try
            {
                // If the return url starts with a slash "/" we assume it belongs to our site
                // so we will redirect to this "action"
                if (!string.IsNullOrWhiteSpace(returnURL) && Url.IsLocalUrl(returnURL))
                    return Redirect(returnURL);

                // If we cannot verify if the url is local to our host we redirect to a default location
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                throw;
            }
        }


        //POST: Logout
        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                // First we clean the authentication ticket like always
                //required NameSpace: using System.Web.Security;
                FormsAuthentication.SignOut();

                // Second we clear the principal to ensure the user does not retain any authentication
                //required NameSpace: using System.Security.Principal;
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

                Session.Clear();
                System.Web.HttpContext.Current.Session.RemoveAll();

                // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
                // this clears the Request.IsAuthenticated flag since this triggers a new request
                return RedirectToLocal();
            }
            catch
            {
                throw;
            }
        }
    }
}