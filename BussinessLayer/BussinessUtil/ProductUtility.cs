using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Repositories;
using System.Linq.Expressions;
using BussinessLayer;
namespace BussinessLayer.BussinessUtil
{
  public  class ProductUtility : IRepository<Product>
    {
        private Repository<Product> Repository;
        public Entities Entities;
        public ProductUtility()
        {
            Entities = new Entities();
            Repository = new Repository<Product>(Entities);
        }

        public Product Add(Product entity)
        {
           return  Repository.Add(entity);
        }

        //public async Task<int> AddProduct(Product product)
        //{
        //    Entities.Products.Add(product);

        //    var data = await Entities.SaveChangesAsync();
        //    return data;
        //}

        public Product Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get(Expression<Func<Product, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetSingle(Expression<Func<Product, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
           return  this.Repository.SaveChangesAsync();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<object> AddProduct(Product product)
        {
            this.Add(product);
           return await this.SaveChangesAsync();
        }
    }
}
