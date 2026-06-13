using System.Threading.Tasks;
using EmployeeMangment.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangment.Reposatory
{
    public class GnericReposatory<T>: IGnericReposatory<T> where T : class
    {
        private readonly ApplecationDbContext context;
        public GnericReposatory(ApplecationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()=>
            await context.Set<T>().ToListAsync();
        public async Task<T> GetById(int id) =>
           await context.Set<T>().FindAsync(id).AsTask();
        public async Task AddAsync(T entity) =>
          await context.Set<T>().AddAsync(entity);
        public void Update(T entity) =>
            context.Set<T>().Update(entity);
        public void Delete(T entity) =>
            context.Set<T>().Remove(entity);
        public async Task SaveAsync()=>
           await context.SaveChangesAsync();
    }
}
