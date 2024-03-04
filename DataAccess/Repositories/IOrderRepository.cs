using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        public int GetNumberOfOrders();
        public List<Order> GetOrdersList();
        public Order GetOrderByID(int id);
        public Order CreateOrders(Order order);
        public Order UpdateOrder(Order order);
        public Order DeleteOrder(int orderID);
    }
}
