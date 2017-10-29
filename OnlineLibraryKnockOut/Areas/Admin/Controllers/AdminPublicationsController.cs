using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibraryKnockOut.Areas.Admin.Controllers
{
    public class AdminPublicationsController : Controller
    {
        // GET: Admin/AdminPublications
        public ActionResult Index()
        {
            return View();
        }
    }
}