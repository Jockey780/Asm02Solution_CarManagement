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

        public int GetNumberOfOrders()
        {
            return orderRepository.GetNumberOfOrders();
        }
    }
}
