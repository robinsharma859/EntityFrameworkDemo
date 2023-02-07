using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using BussinessLayer.Repositories;

namespace BussinessLayer
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly Entities _entities = null;

        public Repository(Entities entities)
        {
            this._entities = entities;
        }

        public T Add(T entity)
        {
           var result = this._entities.Set<T>().Add(entity);
            return result;
        }

        public T Delete(T entity)
        {
          return  this._entities.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            IQueryable<T> retValue = this._entities.Set<T>();
            if(condition!=null)
            {
                retValue = retValue.Where(condition);
            }
            return retValue; 
        }

        public async Task<T> GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            return await this._entities.Set<T>().Where(condition).SingleOrDefaultAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return this._entities.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return this._entities.SaveChanges();
        }

        public T Update(T entity)
        {
             this._entities.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
