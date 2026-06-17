using System.Linq.Expressions;

namespace EmployeeMangment.Reposatory
{
    public interface IGnericReposatory<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
