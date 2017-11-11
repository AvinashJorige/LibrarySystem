using BusinessEntity.Implementation;
using BusinessEntity.Interface;
using EntityCore.Core;
using EntityCore.Mappings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace OnlineLibraryKnockOut.Areas.Admin.Controllers
{
    public class AdminStudentInfoController : Controller
    {
        // GET: Admin/AdminStudentInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AdminStudentInfo
        public ActionResult AddStudent()
        {
            return View();
        }

        // GET: Admin/AdminStudentInfo
        public ActionResult ModifyStudents()
        {
            return View();
        }
        
        // GET: Admin/AdminStudentInfo
        public ActionResult StudentList()
        {
            return View();
        }

        // GET: Admin/AdminStudentInfo
        public ActionResult ArchivedStudents()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentInfoAPI(string _updationType, StudentMst _stdInfo = null)
        {
            var obj = new { status = false, value = string.Empty, error = string.Empty };
            try
            {
                StudentMst _stdMst = new StudentMst();
                IGenericService<StudentMst> _genericService = new GenericService<StudentMst>();
                string returnValue = string.Empty;
                bool statusBool = true;

                if (_stdInfo != null)
                {
                    _stdMst = _stdInfo;
                }

                _stdMst.isActive = true;

                if (_updationType == "update")
                {
                    _genericService.Update(_stdMst);
                    returnValue = "Student Updation Success.";
                }
                else if (_updationType == "add")
                {
                   if(IsValidEmail(_stdMst.Email))
                    {
                        // checking with this hashkey while login into the student page..
                        _stdMst.HashKey = new Cipher().Encrypt(_stdMst.StudentName + _stdMst.Password);
                        _genericService.Insert(_stdMst);

                        // Sending the email welcoming
                        string bodyTemplate = PopulateBody(_stdMst);
                        new EmailSupport().sendMail(_stdMst.Email, "Library System Login Details", bodyTemplate);

                        returnValue = "Adding new Student completes.";
                    }
                   else
                    {
                        statusBool = false;
                        returnValue = "BAD Unable to connect to any one of mail servers for "+ _stdMst.Email;
                    }
                }
                else if (_updationType == "delete")
                {
                    _stdMst.isActive = false;
                     _genericService.Delete(_stdMst.SID);
                    returnValue = "Student deletion complete.";
                }
                else if (_updationType == "getStudent")
                {
                    returnValue = JsonConvert.SerializeObject(_genericService.Get());
                }
                else if (_updationType == "updateDelete")
                {
                    _stdMst.isActive = false;
                     _genericService.Update(_stdMst);
                    returnValue = "Student deleted.";
                }

                obj = new { status = statusBool, value = returnValue, error = string.Empty };
            }
            catch (Exception ex)
            {
                obj = new { status = false, value = "Some system failure occured. Try after some time.", error = ex.Message.ToString() };
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        private string PopulateBody(StudentMst _coreModel)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Areas/Admin/config/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{userName}", _coreModel.StudentName);
            body = body.Replace("{userMail}", _coreModel.Email);
            body = body.Replace("{userId}", _coreModel.SID.ToString());
            body = body.Replace("{userPassword}", _coreModel.Password);
            return body;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}