using BusinessEntity.Implementation;
using BusinessEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Factory
{
    public class FactoryGenericClassPattern<T> where T : class
    {
        public IGenericService<T> CreateInstance()
        {
            IGenericService<T> objK;

            objK = new GenericService<T>();

            return objK;
        }
    }

}