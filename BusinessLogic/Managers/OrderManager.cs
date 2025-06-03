using CafeClient.DataAccess.Repositories;
using CafeClient.BusinessLogic.Models;
using System.Collections.Generic;

namespace CafeClient.BusinessLogic.Managers
{
    public class OrderManager
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderItemRepository _orderItemRepository;

        public OrderManager(OrderRepository orderRepository, OrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public void CreateOrder(Order order) => _orderRepository.Add(order);

        public void UpdateOrder(Order order) => _orderRepository.Update(order);

        public void CompleteOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            order.CompleteOrder();
            _orderRepository.Update(order);
        }

        public void AddOrderItem(int orderId, OrderItem item)
        {
            item.OrderId = orderId;
            _orderItemRepository.Add(item);
        }

        public void RemoveOrderItem(int orderId, int orderItemId)
        {
            _orderItemRepository.Delete(orderItemId);
        }

        public decimal CalculateOrderTotal(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            return order.CalculateTotal();
        }

        public void ApplyDiscount(int orderId, decimal discountPercent)
        {
            var order = _orderRepository.GetById(orderId);
            order.ApplyDiscount(discountPercent);
            _orderRepository.Update(order);
        }

        public List<Order> GetOrdersByClientId(int clientId) => _orderRepository.GetByClientId(clientId);

        public Order GetOrderById(int orderId) => _orderRepository.GetById(orderId);
    }
}
