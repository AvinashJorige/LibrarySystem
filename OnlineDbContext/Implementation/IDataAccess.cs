using EntityCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDbRepo.Implementation
{
    public interface IDataAccess<TEntity> : ILibraryClass<TEntity>
    {

    }
}
