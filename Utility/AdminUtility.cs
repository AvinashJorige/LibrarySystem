using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.Interface;
using BusinessEntity.Implementation;
using EntityCore.Mappings;

namespace Utility
{ 
    public class AdminUtility
    {
        private IAdminServices<AdminMst> _adminService;
        
        public AdminUtility()
        {
            _adminService = new AdminServices<AdminMst>();
        }

        public bool LoginValidation(string email, string password, string type)
        {
            bool flag = false;
            var logType =new object() ;
            if (type == "Librarian")
                logType = new AdminMst();
            else
            {
                logType = new StudentMst();
            }
            try
            {
                logType = _adminService.GetFirstOrDefault(m => m.Email_Id == email && m.Password == password);
                if(logType != null)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

    }
}
