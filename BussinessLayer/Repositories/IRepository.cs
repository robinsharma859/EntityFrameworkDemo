using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repositories
{
    public interface IRepository<T>
    {     
        IQueryable<T> Get(Expression<Func<T, bool>> condition);

        Task<T> GetSingle(Expression<Func<T, bool>> condition);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}
