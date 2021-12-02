using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    internal interface IOrderDAO
    {
        List<Order> GetAllOrdersByCustomerId(int customerId);
        Double ComputeOrderTotal(int orderId);
        bool AddOrder(Order order);
        bool UpdateOrderTotal(int orderId);
    }
}
