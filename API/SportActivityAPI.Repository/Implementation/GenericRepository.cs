using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;
using System.Linq.Expressions;

namespace SportActivityAPI.Repository.Implementation
{
    internal class GenericRepository<T> : IRepository<T> where T : class
    {
        protected SporttrackerContext DbContext { get; set; }

        public GenericRepository(SporttrackerContext context)
        {
            DbContext = context;
        }

        public async virtual Task<T> AddAsync(T entity)
        {
            return (await DbContext.Set<T>().AddAsync(entity)).Entity;
        }


        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression);
        }

        public virtual T Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            return DbContext.Set<T>().Update(entity).Entity;
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }
    }
}
