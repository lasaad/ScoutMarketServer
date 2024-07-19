namespace ScoutMarket.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string Marque { get; set; }
        public string Gamme { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }
}
