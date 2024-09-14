using Billing_System.BuissnessLogic.DTO.ItemInvoice;
using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Invoice
{
    public class InvoiceToReturnDTO
    {
        public DateTime BillDate { get; set; } = DateTime.Now;
        public int PaidUp { get; set; }
        [Range(1, int.MaxValue)]
        public int Net { get; set; }
        public int DiscountValue { get; set; }
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }
        public int BillsTotal { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
        public List<ItemInvoiceToReturnDTO> Items { get; set; }

    }
}
