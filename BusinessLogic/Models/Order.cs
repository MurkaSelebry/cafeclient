using System;
using System.Collections.Generic;

namespace CafeClient.BusinessLogic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int BonusPointsUsed { get; set; }
        public int BonusPointsEarned { get; set; }
        public string Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public void AddItem(OrderItem item) => Items.Add(item);

        public void RemoveItem(int orderItemId) => Items.RemoveAll(i => i.Id == orderItemId);

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.Price * item.Quantity;
            return total - DiscountAmount;
        }

        public void ApplyDiscount(decimal percent)
        {
            DiscountAmount = CalculateTotal() * percent / 100m;
        }

        public void UseClientBonusPoints(int points)
        {
            BonusPointsUsed = points;
            // Adjust total if needed
        }

        public int CalculateBonusPoints()
        {
            // Example: 1 point per 100 spent
            return (int)(CalculateTotal() / 100);
        }

        public void CompleteOrder()
        {
            Status = "Closed";
            BonusPointsEarned = CalculateBonusPoints();
        }
    }
}
