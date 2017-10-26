using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Factory
{
    public class FactoryModelPattern<K, T> where T : class, K, new()
    {
        public K CreateInstance()
        {
            K objK;

            objK = new T();

            return objK;
        }
    }
}
