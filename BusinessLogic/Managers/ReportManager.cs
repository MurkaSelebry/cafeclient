using CafeClient.DataAccess.Repositories;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CafeClient.BusinessLogic.Managers
{
    public class ReportManager
    {
        private readonly ClientRepository _clientRepository;
        private readonly OrderRepository _orderRepository;
        private readonly MenuItemRepository _menuItemRepository;
        private readonly LoyaltyLevelRepository _loyaltyLevelRepository;

        public ReportManager(ClientRepository clientRepository, OrderRepository orderRepository, MenuItemRepository menuItemRepository, LoyaltyLevelRepository loyaltyLevelRepository)
        {
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
            _loyaltyLevelRepository = loyaltyLevelRepository;
        }

        public string GenerateClientsStatsReport()
        {
            var clients = _clientRepository.GetAll();
            var sb = new StringBuilder();
            sb.AppendLine("Статистика по клиентам:");
            sb.AppendLine($"Всего клиентов: {clients.Count}");
            var byLevel = clients.GroupBy(c => c.LoyaltyLevelId).Select(g => $"Уровень {g.Key}: {g.Count()} клиентов");
            foreach (var line in byLevel) sb.AppendLine(line);
            return sb.ToString();
        }

        public string GeneratePopularItemsReport()
        {
            var orders = _orderRepository.GetAll();
            var sb = new StringBuilder();
            sb.AppendLine("Популярные заказы:");

            // Сортируем заказы по дате и выводим последние 10
            var recentOrders = orders
                .OrderByDescending(o => o.OrderDate)
                .Take(10);

            foreach (var order in recentOrders)
            {
                sb.AppendLine($"Заказ #{order.Id} от {order.OrderDate}: {order.TotalAmount:F2}");
            }

            return sb.ToString();
        }

        public string GenerateOrdersDynamicsReport()
        {
            var orders = _orderRepository.GetAll();
            var byDate = orders.GroupBy(o => o.OrderDate.ToString().Substring(0, 10)).Select(g => $"{g.Key}: {g.Count()} заказов");
            var sb = new StringBuilder();
            sb.AppendLine("Динамика заказов:");
            foreach (var line in byDate) sb.AppendLine(line);
            return sb.ToString();
        }

        public string GenerateLoyaltyEfficiencyReport()
        {
            var clients = _clientRepository.GetAll();
            var sb = new StringBuilder();
            sb.AppendLine("Эффективность лояльности:");
            var byLevel = clients.GroupBy(c => c.LoyaltyLevelId).Select(g => $"Уровень {g.Key}: {g.Count()} клиентов");
            foreach (var line in byLevel) sb.AppendLine(line);
            return sb.ToString();
        }
    }
}
