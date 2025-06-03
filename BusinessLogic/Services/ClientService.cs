using CafeClient.BusinessLogic.Models;
using CafeClient.DataAccess.Repositories;

namespace CafeClient.BusinessLogic.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

       

        // Other business logic methods...
    }
}
