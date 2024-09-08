using BillingSystem.DataAccess.Context;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace BillingSystem.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Client> Clients { get; private set; }

        public IBaseRepository<Company> Companies { get; private set; }

        public IBaseRepository<Employee> Employees { get; private set; }

        public IBaseRepository<Invoice> Invoices { get; private set; }

        public IBaseRepository<Item> Items { get; private set; }

        public IBaseRepository<ItemInvoice> ItemsInvoices { get; private set; }

        public IBaseRepository<model.models.Type> Types { get; private set; }

        public IBaseRepository<Unit> Units { get; private set; }

        public UnitOfWork(ApplicationDbContext context,
                          IBaseRepository<Company> companies,
                          IBaseRepository<Client> clients,
                          IBaseRepository<Employee> employees,
                          IBaseRepository<Invoice> invoices,
                          IBaseRepository<Item> items,
                          IBaseRepository<ItemInvoice> itemInvoices,
                          IBaseRepository<model.models.Type> types,
                          IBaseRepository<Unit> units
            )
        {
            _context = context;
            Companies = companies;
            Clients = clients;
            Employees = employees;
            Invoices = invoices;
            Items = items;
            ItemsInvoices = itemInvoices;
            Types = types;
            Units = units;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
