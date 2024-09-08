namespace BillingSystem.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(int id);
        void add(T item);
        void update(T item);
        void delete(T item);
        void save();

    }
}
