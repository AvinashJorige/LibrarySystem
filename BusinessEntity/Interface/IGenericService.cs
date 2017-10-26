
using EntityCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessEntity.Interface
{
    public partial interface IGenericService<TEntity> : ILibraryClass<TEntity> where TEntity: class
    {  
    }
}
