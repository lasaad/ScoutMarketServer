namespace ScoutMarket.Models
{
    public class Price
    {
        public required int Id { get; set; }
        public required int StoreId {  get; set; }
        public required int ProductId { get; set; }
        public required int Currency {  get; set; }
        public required int Amount  { get; set; }
        public required DateTime UpdateDate {get; set; }
    }
}
