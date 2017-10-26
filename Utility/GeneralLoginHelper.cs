using System;
using BusinessEntity.Factory;
using BusinessEntity.ConcreteFactory;
using EntityCore.Mappings;
using EntityCore.Interface;
using BusinessEntity.Interface;

namespace Utility
{
    public class GeneralLoginHelper
    {
        public GeneralLoginHelper()
        {

        }
        public bool LoginValidation(string email, string password, string type)
        {
            bool flag = false;

            ILibrary _iModelLibrary = null;

            if (type == "Librarian")
            {
                GenericFactory<AdminMst> _genericFactory = new ConcreteGenericServiceFactory<AdminMst>();
                ILibraryClass<AdminMst> _iLibrary = _genericFactory.genericServiceFactory();

                GenericModelFactory<ILibrary, AdminMst> _genericModelFactory = new ConcreteModelFactory<ILibrary, AdminMst>();
                _iModelLibrary = _genericModelFactory.genericModelFactory();

                _iModelLibrary = _iLibrary.GetFirstOrDefault(m => m.Email_Id == email && m.Password == password); 
            }
            else
            {
                GenericFactory<StudentMst> _genericFactory = new ConcreteGenericServiceFactory<StudentMst>();
                ILibraryClass<StudentMst> _iLibrary = _genericFactory.genericServiceFactory();

                GenericModelFactory<ILibrary, StudentMst> _genericModelFactory = new ConcreteModelFactory<ILibrary, StudentMst>();
                 _iModelLibrary = _genericModelFactory.genericModelFactory();

                _iModelLibrary = _iLibrary.GetFirstOrDefault(m => m.Email == email && m.Password == password);
            }

            try
            {
                if (_iModelLibrary != null)
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
