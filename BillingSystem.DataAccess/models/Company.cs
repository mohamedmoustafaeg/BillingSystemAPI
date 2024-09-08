namespace model.models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }

        public virtual List<Type> Types { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
