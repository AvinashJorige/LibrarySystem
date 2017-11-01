using EntityCore.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryKnockOut.Areas.Admin.Models
{
    public class BranchListObjAreaModel
    {
        public BranchMst BranchMst { get; set; }
        public BookMst BookMst { get; set; }
        public StudentMst StudentMst { get; set; }
        public List<BranchMst> BranchList { get; set; }
        public List<BookMst> BookList { get; set; }
        public List<StudentMst> StudentList { get; set; }
    }
}