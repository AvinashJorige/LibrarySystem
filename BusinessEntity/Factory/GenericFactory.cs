using BusinessEntity.Interface;
using EntityCore.Interface;

namespace BusinessEntity.Factory
{
    public abstract class GenericFactory<T> where T : class
    {
        public abstract IGenericService<T> genericServiceFactory();
    }
}
