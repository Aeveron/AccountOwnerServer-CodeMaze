using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RespositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RespositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RespositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RespositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.RespositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RespositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RespositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.RespositoryContext.SaveChanges();
        }
    }
}
