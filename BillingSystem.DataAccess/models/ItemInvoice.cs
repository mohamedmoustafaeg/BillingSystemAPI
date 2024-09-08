namespace model.models
{
    public class ItemInvoice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice? Invoices { get; set; }
        public virtual Item? Items { get; set; }

    }
}
