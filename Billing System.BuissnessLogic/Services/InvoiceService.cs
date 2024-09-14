using Billing_System.BuissnessLogic.DTO.Invoice;
using Billing_System.BuissnessLogic.DTO.ItemInvoice;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace Billing_System.BuissnessLogic.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _context;
        public InvoiceService(IUnitOfWork context)
        {
            _context = context;
        }
        public void AddInvoice(InvoiceToAddDTO invoice)
        {
            if (invoice == null)
                throw new Exception("invoice can't be null");
            var client = _context.Clients.GetById(invoice.ClientId);
            if (client == null)
                throw new Exception($"The client with id ${invoice.ClientId} does not exist");
            var employee = _context.Employees.GetById(invoice.EmployeeId);
            if (employee == null)
                throw new Exception($"Employee with Id {invoice.EmployeeId} does not exist in database");
            foreach (var item in invoice.ItemInvoices)
            {
                var itemInDb = _context.Items.GetById(item.ItemId);
                if (itemInDb == null)
                    throw new Exception($"Item with Id {item.ItemId} does not exist in database");
            }
            var invoiceToCreate = new Invoice()
            {
                BillDate = invoice.BillDate,
                PaidUp = invoice.PaidUp,
                Net = invoice.Net,
                DiscountPercentage = invoice.DiscountPercentage,
                DiscountValue = invoice.DiscountValue,
                BillsTotal = invoice.BillsTotal,
                ClientId = invoice.ClientId,
                EmployeeId = invoice.EmployeeId,
            };
            _context.Invoices.Add(invoiceToCreate);
            _context.Complete();
            foreach (var item in invoice.ItemInvoices)
            {
                _context.ItemsInvoices.Add(
                    new ItemInvoice()
                    {
                        ItemId = item.ItemId,
                        InvoiceId = invoiceToCreate.Id,
                        Quantity = item.Quantity,
                        Total = item.Total
                    }

                    );
            }
            _context.Complete();
        }

        public List<InvoiceToReturnDTO> GetAllInvoices()
        {
            var invoicesInDb = _context.Invoices.GetAll();
            if (invoicesInDb == null)
                throw new Exception("No Invoices Found");
            var invoices = new List<InvoiceToReturnDTO>();
            foreach (var invoice in invoicesInDb)
            {

                var invoiceToAdd = new InvoiceToReturnDTO()
                {
                    Id = invoice.Id,
                    BillDate = invoice.BillDate,
                    PaidUp = invoice.PaidUp,
                    Net = invoice.Net,
                    DiscountValue = invoice.DiscountValue,
                    DiscountPercentage = invoice.DiscountPercentage,
                    BillsTotal = invoice.BillsTotal,
                    ClientName = invoice.Client.Name,
                    EmployeeName = invoice.Employee.Name,
                };
                invoiceToAdd.Items = new List<ItemInvoiceToReturnDTO>();

                foreach (var item in invoice.ItemInvoices)
                {
                    invoiceToAdd.Items.Add(new ItemInvoiceToReturnDTO()
                    {
                        ItemName = item.Items.Name,
                        Quantity = item.Quantity,
                        Total = item.Total,
                    });
                }

                invoices.Add(invoiceToAdd);
            }
            return invoices;
        }
        public void DeleteInvoice(int id)
        {
            var invoice = _context.Invoices.GetById(id);
            if (invoice == null)
                throw new Exception($"No Invoice found with id {id}");
            foreach (var item in invoice.ItemInvoices)
            {
                _context.ItemsInvoices.Delete(item);
            }
            _context.Invoices.Delete(invoice);
            _context.Complete();
        }
    }
}
