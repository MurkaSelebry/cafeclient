namespace CafeClient.BusinessLogic.Models
{
    public class LoyaltyLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPoints { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
