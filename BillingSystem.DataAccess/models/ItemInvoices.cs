namespace model.models
{
    public class ItemInvoices
    {
        
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Item> Items { get; set; }

    }
}
