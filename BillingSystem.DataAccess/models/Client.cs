namespace model.models
{
    public class Client
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public int Number {  get; set; }
        public int Phone { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}