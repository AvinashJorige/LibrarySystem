using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibraryKnockOut.Areas.Admin.Controllers
{
    public class AdminBranchController : Controller
    {
        // GET: Admin/AdminBranch
        public ActionResult newBranch()
        {
            return View();
        }
    }
}