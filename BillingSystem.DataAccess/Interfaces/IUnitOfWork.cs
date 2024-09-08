using model.models;

namespace BillingSystem.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Client> Clients { get; }
        IBaseRepository<Company> Companies { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Invoice> Invoices { get; }
        IBaseRepository<Item> Items { get; }
        IBaseRepository<ItemInvoice> ItemsInvoices { get; }
        IBaseRepository<model.models.Type> Types { get; }
        IBaseRepository<Unit> Units { get; }
        int Complete();
    }
}
