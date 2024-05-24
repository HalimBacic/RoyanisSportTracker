using System.Linq.Expressions;

namespace SportActivityAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
