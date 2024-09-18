namespace model.models
{
    public class ItemInvoice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public virtual Invoice? Invoices { get; set; }
        public virtual Item? Items { get; set; }

    }
}
