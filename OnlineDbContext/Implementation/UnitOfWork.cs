using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDbRepo.Implementation
{
    /// <summary>  
    /// The UnitOfWork class designed for binding classes to generic class DataAccess. This class is the conversion or binding class  
    /// </summary>  
    /// <seealso cref="System.IDisposable" />  
    public class UnitOfWork<T> : IUnitOfWork<T>, System.IDisposable where T : class
    {
        private readonly OnlineLibrary _context;
        private IDataAccess<T> _modelRepository;

        public UnitOfWork()
        {
            _context = new OnlineLibrary();
        }

        public IDataAccess<T> ModelRepository
        {
            get { return _modelRepository ?? (_modelRepository = new DataAccessRepository<T>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
