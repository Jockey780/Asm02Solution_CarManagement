using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailList();
        public List<OrderDetail> GetOrderDetail(int userID, int orderID);
    }
}
