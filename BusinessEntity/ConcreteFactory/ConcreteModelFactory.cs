using EntityCore.Interface;
using EntityCore.Mappings;
using BusinessEntity.Implementation;
using BusinessEntity.Factory;
using System;

namespace BusinessEntity.ConcreteFactory
{
   public class ConcreteModelFactory<K, T> : GenericModelFactory<K, T> where T : class, K, new()
    {
        public override K genericModelFactory()
        {

            return new FactoryModelPattern<K, T>().CreateInstance();
            //switch (Type)
            //{
            //    case "AdminMst":
            //        return new FactoryModelPattern<ILibrary, AdminMst>().CreateInstance();
            //    case "StudentMst":
            //        return new FactoryModelPattern<ILibrary, StudentMst>().CreateInstance();
            //    case "BookMst":
            //        return new FactoryModelPattern<ILibrary, BookMst>().CreateInstance();
            //    case "BranchMst":
            //        return new FactoryModelPattern<ILibrary, BranchMst>().CreateInstance();
            //    case "PenaltyMst":
            //        return new FactoryModelPattern<ILibrary, PenaltyMst>().CreateInstance();
            //    case "PublicationMst":
            //        return new FactoryModelPattern<ILibrary, PublicationMst>().CreateInstance();
            //    case "RentMst":
            //        return new FactoryModelPattern<ILibrary, RentMst>().CreateInstance();
            //    default:
            //        throw new ApplicationException(string.Format("Type '{0}' cannot be created", Type));
            //}
        }
    }
}
