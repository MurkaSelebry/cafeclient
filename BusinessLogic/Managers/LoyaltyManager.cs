using CafeClient.DataAccess.Repositories;
using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;

namespace CafeClient.BusinessLogic.Managers
{
    public class LoyaltyManager
    {
        private readonly LoyaltyLevelRepository _loyaltyLevelRepository;
        private readonly ClientRepository _clientRepository;

        public LoyaltyManager(LoyaltyLevelRepository loyaltyLevelRepository, ClientRepository clientRepository)
        {
            _loyaltyLevelRepository = loyaltyLevelRepository;
            _clientRepository = clientRepository;
        }

        public List<LoyaltyLevel> GetLoyaltyLevels() => _loyaltyLevelRepository.GetAll();

        public void AddLoyaltyLevel(LoyaltyLevel level) => _loyaltyLevelRepository.Add(level);

        public void UpdateLoyaltyLevel(LoyaltyLevel level) => _loyaltyLevelRepository.Update(level);

        public void DeleteLoyaltyLevel(int levelId) => _loyaltyLevelRepository.Delete(levelId);

        public LoyaltyLevel GetClientLoyaltyStatus(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            return _loyaltyLevelRepository.GetById(client.LoyaltyLevelId);
        }
    }
}
