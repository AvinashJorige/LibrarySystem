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
        }
    }
}
