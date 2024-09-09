using BillingSystem.DataAccess.Context;
using BillingSystem.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext Context;
        private DbSet<T> DbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public void Delete(T item)
        {
            DbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T item)
        {
            DbSet.Update(item);
        }
    }
}
