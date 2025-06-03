using System;

namespace CafeClient.BusinessLogic.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int LoyaltyLevelId { get; set; }
        public int BonusPoints { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string GetFullName() => $"{FirstName} {LastName}";

        public void UpdateBonusPoints(int points) => BonusPoints += points;

        public void UpdateLoyaltyLevel(int newLevelId) => LoyaltyLevelId = newLevelId;
    }
}
