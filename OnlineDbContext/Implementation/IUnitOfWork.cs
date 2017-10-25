namespace OnlineDbRepo.Implementation
{
    public interface IUnitOfWork<T>
    {
        IDataAccess<T> ModelRepository { get; }
        void Save();
    }
}
