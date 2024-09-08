namespace model.models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<Item>? Items { get; set; }
    }
}
