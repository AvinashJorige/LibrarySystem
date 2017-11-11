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
        public ActionResult BranchInfoList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BranchListarchevie()
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

            return Json(JsonConvert.SerializeObject(_branchListObjAreaModel), JsonRequestBehavior.AllowGet); // return Json(new { branchData = _branchListObjAreaModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BranchModification(string _branchName = null, string _branchId = null, string _updationType = null)
        {
            var obj = new { status = false, value = string.Empty, error = string.Empty };
            try
            {
                BranchMst _branchMst = new BranchMst();
                IGenericService<BranchMst> _genericService = new GenericService<BranchMst>();
                string returnValue = string.Empty;
                bool statusBool = true;
                string errorStr = string.Empty;

                _branchMst.BranchID = Convert.ToInt32(_branchId);
                _branchMst.BranchName = _branchName;
                _branchMst.isActive = true;


                if (_updationType == "update")
                {
                    if (_branchMst.BranchID != 0 && _branchMst.BranchName != null)
                    {
                        _genericService.Update(_branchMst);
                        returnValue = "Branch Updation Success.";
                    }
                    else
                    {
                        returnValue = "Invalid Information.";
                        errorStr = "false";
                        statusBool = false;
                    }
                }
                else if (_updationType == "add")
                {
                    if (_branchMst.BranchName != null)
                    {
                        _genericService.Insert(_branchMst);
                        returnValue = "Adding new branch completes.";
                    }
                    else
                    {
                        returnValue = "Invalid Information.";
                        errorStr = "false";
                        statusBool = false;
                    }
                }
                else if (_updationType == "delete")
                {
                    if (_branchMst.BranchID != 0)
                    {
                        _branchMst.isActive = false;
                        _genericService.Delete(_branchMst.BranchID);
                        returnValue = "Branch deletion complete.";
                    }
                    else
                    {
                        returnValue = "Invalid Information.";
                        errorStr = "false";
                        statusBool = false;
                    }
                }
                else if (_updationType == "updateDelete")
                {
                    if (_branchMst.BranchID != 0 && _branchMst.BranchName != null)
                    {
                        _branchMst.isActive = false;
                        _genericService.Update(_branchMst);
                        returnValue = "Branch deleted.";
                    }
                    else
                    {
                        returnValue = "Invalid Information.";
                        errorStr = "false";
                        statusBool = false;
                    }
                }
                else if (_updationType == "getBranch")
                {
                    var rasd = _genericService.Get();
                    returnValue = JsonConvert.SerializeObject(_genericService.Get());
                }
                else if(_updationType == "getById")
                {
                    if (_branchMst.BranchID != 0)
                    {
                        returnValue = _genericService.GetById(_branchId).ToString();
                    }
                    else
                    {
                        returnValue = "Invalid Information.";
                        errorStr = "false";
                        statusBool = false;
                    }                    
                }

                obj = new { status = statusBool, value = returnValue, error = errorStr };
            }
            catch (Exception ex)
            {
                obj = new { status = false, value = "Some system failure occured. Try after some time.", error = ex.Message.ToString() };
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

    }
}