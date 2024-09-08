namespace model.models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }
        public int AvailableQyantity { get; set; }
        public int BuyingPrice { get; set; }
        public int SellingPrice { get; set; }
        public int TypeId { get; set; }
        public int CompanyId    { get; set; }
        public int UnitId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Type Type { get; set; }

    }
}
