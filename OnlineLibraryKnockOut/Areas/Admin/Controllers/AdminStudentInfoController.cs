using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}