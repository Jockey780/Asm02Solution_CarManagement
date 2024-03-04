using BusinessObjects.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public Order CreateOrders(Order order)
        {
            return orderRepository.CreateOrders(order);
        }

        public Order DeleteOrder(int orderID)
        {
            return orderRepository.DeleteOrder(orderID);
        }

        public int GetNumberOfOrders()
        {
            return orderRepository.GetNumberOfOrders();
        }

        public Order GetOrderByID(int id)
        {
            return orderRepository.GetOrderByID(id);
        }

        public List<Order> GetOrdersList()
        {
            return orderRepository.GetOrdersList();
        }

        public Order UpdateOrder(Order order)
        {
            return orderRepository.UpdateOrder(order);
        }
    }
}
