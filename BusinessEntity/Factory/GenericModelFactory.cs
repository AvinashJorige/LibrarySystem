using BusinessEntity.Interface;

namespace BusinessEntity.Factory
{
    public abstract class GenericModelFactory<K, T> where T : class, K, new()
    {
        public abstract K genericModelFactory();
    }
}
