namespace model.models
{
    public class Invoice
    {
        
        public int Id { get; set; }
        public DateTime BillDate { get; set; }
        public int PaidUp { get; set; }
        public int Quantity { get; set; }
        public int TotalValue { get; set; }
        public int DiscountValue { get; set; }
        public int DiscountPercentage { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId  { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
