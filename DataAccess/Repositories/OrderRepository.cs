using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public int GetNumberOfOrders() => OrderDAO.Instance.GetNumberOfOrders();
        public List<Order> GetOrdersList()=>OrderDAO.Instance.GetOrdersList();
        public Order GetOrderByID(int id)=>OrderDAO.Instance.GetOrderByID(id);
        public Order CreateOrders(Order order)=>OrderDAO.Instance.CreateOrders(order);
        public Order UpdateOrder(Order order)=>OrderDAO.Instance.UpdateOrder(order);
        public Order DeleteOrder(int orderID)=>OrderDAO.Instance.DeleteOrder(orderID);
    }
}
