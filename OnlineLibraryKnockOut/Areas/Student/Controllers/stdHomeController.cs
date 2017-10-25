using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibraryKnockOut.Areas.Student.Controllers
{
    public class stdHomeController : Controller
    {
        // GET: Student/stdHome
        public ActionResult Index()
        {
            return View();
        }
    }
}