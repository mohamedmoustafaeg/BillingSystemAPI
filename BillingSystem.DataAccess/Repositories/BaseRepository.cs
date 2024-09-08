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
        public void add(T item)
        {
            DbSet.Add(item);
        }

        public void delete(T item)
        {
            DbSet.Remove(item);
        }

        public IEnumerable<T> getAll()
        {
            return DbSet.ToList();
        }

        public T getById(int id)
        {
            return DbSet.Find(id);
        }

        public void save()
        {
            Context.SaveChanges();
        }

        public void update(T item)
        {
            DbSet.Update(item);
        }
    }
}
