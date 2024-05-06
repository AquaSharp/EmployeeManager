using EmployeeManager.Contracts;
using EmployeeManager.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManager.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext repositoryContext;

        public RepositoryBase(AppDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return repositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
        }
       
    }
}
