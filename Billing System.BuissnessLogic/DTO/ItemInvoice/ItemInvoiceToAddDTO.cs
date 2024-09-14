using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.ItemInvoice
{
    public class ItemInvoiceToAddDTO
    {
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue)]
        public int Total { get; set; }
        [Range(0, int.MaxValue)]
        public int SellingPrice { get; set; }
    }
}
