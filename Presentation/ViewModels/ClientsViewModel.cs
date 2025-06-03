using CafeClient.BusinessLogic.Models;
using CafeClient.BusinessLogic.Services;

namespace CafeClient.Presentation.ViewModels
{
    public class ClientsViewModel
    {
        private readonly ClientService _clientService;

        public ClientsViewModel(ClientService clientService)
        {
            _clientService = clientService;
        }

      

        // Other methods for UI interaction...
    }
}