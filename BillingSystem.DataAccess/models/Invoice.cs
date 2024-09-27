using System.ComponentModel.DataAnnotations;

namespace model.models
{
    public class Invoice
    {

        public int Id { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        [Range(1, int.MaxValue)]
        public int Net { get; set; }
        public int BillNumber { get; set; }
        public int DiscountValue { get; set; }
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }
        public int BillsTotal { get; set; }
        public int ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Client? Client { get; set; }
        //   public virtual Employee? Employee { get; set; }
        public virtual List<ItemInvoice>? ItemInvoices { get; set; }
    }
}
