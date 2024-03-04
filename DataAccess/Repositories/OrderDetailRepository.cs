using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailList()=>OrderDetailDAO.Instance.GetOrderDetailList();
        public List<OrderDetail> GetOrderDetail(int userID, int orderID)=>OrderDetailDAO.Instance.GetOrderDetail(userID, orderID);
    }
}
