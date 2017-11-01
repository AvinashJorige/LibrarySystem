using BusinessEntity.Factory;
using BusinessEntity.ConcreteFactory;
using EntityCore.Mappings;
using EntityCore.Interface;
using System.Web.Mvc;
using OnlineLibraryKnockOut.Areas.Admin.Models;
using System;
using Newtonsoft.Json;
using BusinessEntity.Interface;
using BusinessEntity.Implementation;

namespace OnlineLibraryKnockOut.Areas.Admin.Controllers
{
    public class AdminBranchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BranchList()
        {
            return View();
        }

        /// <summary>
        /// Fetching the data from the branch, student and book table.
        /// 
        /// </summary>
        /// <param name="empty"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BranchList(string empty)
        {
            BranchListObjAreaModel _branchListObjAreaModel = new BranchListObjAreaModel();

            GenericFactory<BranchMst> _genericFactory = new ConcreteGenericServiceFactory<BranchMst>();
            ILibraryClass<BranchMst> _iLibrary = _genericFactory.genericServiceFactory();

            GenericFactory<BookMst> _genericFactoryBookMst = new ConcreteGenericServiceFactory<BookMst>();
            ILibraryClass<BookMst> _iLibraryBookMst = _genericFactoryBookMst.genericServiceFactory();

            GenericFactory<StudentMst> _genericFactoryStudentMst = new ConcreteGenericServiceFactory<StudentMst>();
            ILibraryClass<StudentMst> _iLibraryStudentMst = _genericFactoryStudentMst.genericServiceFactory();

            _branchListObjAreaModel.BranchList = _iLibrary.Get();
            _branchListObjAreaModel.BookList = _iLibraryBookMst.Get();
            _branchListObjAreaModel.StudentList = _iLibraryStudentMst.Get();

            return Json( JsonConvert.SerializeObject(_branchListObjAreaModel), JsonRequestBehavior.AllowGet); // return Json(new { branchData = _branchListObjAreaModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult newBranch(string _branchName)
        {
            var obj = new { status = false, value = string.Empty, error = string.Empty };
            try
            {
                BranchMst _branchMst = new BranchMst();
                if(!string.IsNullOrEmpty(_branchName))
                {
                    _branchMst.BranchName = _branchName;
                    _branchMst.isActive = true;
                }

                IGenericService<BranchMst> _genericService = new GenericService<BranchMst>();
                _genericService.Insert(_branchMst);


                obj = new { status = true, value = "New branch added.", error = string.Empty };
            }
            catch (Exception ex)
            {
                obj = new { status = false, value = "New branch fail to add.", error = ex.Message.ToString() };
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}