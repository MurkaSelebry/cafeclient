using CafeClient.DataAccess.Repositories;
using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;

namespace CafeClient.BusinessLogic.Managers
{
    public class ClientManager
    {
        private readonly ClientRepository _clientRepository;
        private readonly LoyaltyLevelRepository _loyaltyLevelRepository;

        public ClientManager(ClientRepository clientRepository, LoyaltyLevelRepository loyaltyLevelRepository)
        {
            _clientRepository = clientRepository;
            _loyaltyLevelRepository = loyaltyLevelRepository;
        }

        public void RegisterClient(Client client) => _clientRepository.Add(client);

        public void UpdateClient(Client client) => _clientRepository.Update(client);

        public void DeleteClient(int clientId) => _clientRepository.Delete(clientId);

        public Client GetClientById(int clientId) => _clientRepository.GetById(clientId);

        public List<Client> GetAllClients() => _clientRepository.GetAll();

        public List<Client> SearchClients(string searchTerm) => _clientRepository.Search(searchTerm);

        public void AddBonusPoints(int clientId, int points)
        {
            var client = _clientRepository.GetById(clientId);
            client.UpdateBonusPoints(points);
            _clientRepository.Update(client);
            UpdateLoyaltyLevel(clientId);
        }

        public void UpdateLoyaltyLevel(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            var levels = _loyaltyLevelRepository.GetAll();
            foreach (var level in levels)
            {
                if (client.BonusPoints >= level.MinPoints)
                    client.LoyaltyLevelId = level.Id;
            }
            _clientRepository.Update(client);
        }

        public decimal GetClientDiscountPercent(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            var level = _loyaltyLevelRepository.GetById(client.LoyaltyLevelId);
            return level?.DiscountPercent ?? 0;
        }
    }
}
