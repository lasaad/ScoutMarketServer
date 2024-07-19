namespace ScoutMarket.Entities
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }
}
