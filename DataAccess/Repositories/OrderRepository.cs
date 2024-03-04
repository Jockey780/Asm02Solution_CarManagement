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
    }
}
