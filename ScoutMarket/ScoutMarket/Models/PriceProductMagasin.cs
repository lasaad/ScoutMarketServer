namespace ScoutMarket.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int StoreId {  get; set; }
        public int ProductId { get; set; }
        public int Currency {  get; set; }
        public int Amount  { get; set; }
        public DateTime UpdateDate {get; set; }
    }
}
