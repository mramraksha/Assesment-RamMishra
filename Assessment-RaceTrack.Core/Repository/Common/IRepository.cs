using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeDoor.Core.Repository.Common
{
    public interface IRepository<T> where T:class
    {
        Task Delete(T entityToDelete);
        Task Delete(object id);
       IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             string includeProperties = "");
        Task<T> GetByID(object id);

        Task Insert(T entity);
        Task Update(T entityToUpdate);
    }
}
