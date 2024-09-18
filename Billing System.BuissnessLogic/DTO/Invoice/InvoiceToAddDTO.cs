using Billing_System.BuissnessLogic.DTO.ItemInvoice;
using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Invoice
{
    public class InvoiceToAddDTO
    {

        public DateTime BillDate { get; set; } = DateTime.Now;
        public int PaidUp { get; set; }
        [Range(0, int.MaxValue)]
        public int Net { get; set; }
        [Range(0, int.MaxValue)]
        public int DiscountValue { get; set; }
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }
        public int ClientId { get; set; }
        public int BillsTotal { get; set; }
        public int EmployeeId { get; set; }
        public List<ItemInvoiceToAddDTO> ItemInvoices { get; set; } = new List<ItemInvoiceToAddDTO>();
    }
}
