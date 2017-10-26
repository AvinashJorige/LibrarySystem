using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity.Factory;
using BusinessEntity.Implementation;
using EntityCore.Mappings;
using BusinessEntity.Interface;
using EntityCore.Interface;

namespace BusinessEntity.ConcreteFactory
{
    public class ConcreteGenericServiceFactory<T> : GenericFactory<T> where T : class
    {
        public override IGenericService<T> genericServiceFactory()
        {
            return new FactoryGenericClassPattern<T>().CreateInstance();
            //switch (type)
            //{
            //    case "AdminMst":
            //        return new FactoryGenericClassPattern<AdminMst>().CreateInstance();
            //    case "StudentMst":
            //        return new FactoryGenericClassPattern<StudentMst>().CreateInstance();
            //    case "BookMst":
            //        return new FactoryGenericClassPattern<BookMst>().CreateInstance();
            //    case "BranchMst":
            //        return new FactoryGenericClassPattern<BranchMst>().CreateInstance();
            //    case "PenaltyMst":
            //        return new FactoryGenericClassPattern<PenaltyMst>().CreateInstance();
            //    case "PublicationMst":
            //        return new FactoryGenericClassPattern<PublicationMst>().CreateInstance();
            //    case "RentMst":
            //        return new FactoryGenericClassPattern<RentMst>().CreateInstance();
            //    default:
            //        throw new ApplicationException(string.Format("Type '{0}' cannot be created", type));
            //}
        }
    }
}
