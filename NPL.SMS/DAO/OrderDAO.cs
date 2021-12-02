using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    internal class OrderDAO : IOrderDAO
    {
        private static OrderDAO instance;
        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return OrderDAO.instance; }
            private set { OrderDAO.instance = value; }
        }
        private OrderDAO() { }

        const string SELECT = "SELECT * FROM Orders WHERE customer_id = @customer_id";
        const string ADD_ORDER = @"SP_Add_Order @order_date , @customer_id , @employee_id";
        const string COMPUTE_ORDER_TOTAL = @"SELECT dbo.Fn_ComputeOrderTotal ( @order_id )";
        const string UPDATE_ORDER_TOTAL = @"SP_Update_Order_Total @order_id , @total";

        /// <summary>
        /// ADD ORDER
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool AddOrder(Order order)
        {
            try
            {
                object[] Para = new object[] { order.OrderDate, order.CustomerId, order.EmployeeId };

                return DataProvider.Instance.ExecuteNonQuery(ADD_ORDER, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// COMPUTE ORDER TOTAL BY ORDER ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public double ComputeOrderTotal(int orderId)
        {
            object[] Para = new object[] { orderId };

            var orderTotal = DataProvider.Instance.ExecuteScalar(COMPUTE_ORDER_TOTAL, Para);

            if (orderTotal is DBNull)
                return 0;
            return Convert.ToDouble(orderTotal);
        }

        /// <summary>
        /// GET ALL ORDERS BY CUSTOMER ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Order> GetAllOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();

            DataTable Table = DataProvider.Instance.ExecuteQuery(SELECT, new object[] { customerId });

            foreach (DataRow row in Table.Rows)
            {
                Order order = new Order
                {
                    OrderId = Convert.ToInt32(row["order_id"]),
                    OrderDate = Convert.ToDateTime(row["order_date"]),
                    CustomerId = Convert.ToInt32(row["customer_id"]),
                    EmployeeId = Convert.ToInt32(row["employee_id"]),
                    Total = Convert.ToDouble(row["total"])
                };
                orders.Add(order);
            }

            return orders;
        }
        
        /// <summary>
        /// UPDATE ORDER TOTAL BY ORDER ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool UpdateOrderTotal(int orderId)
        {
            try
            {
                double orderTotal = ComputeOrderTotal(orderId);
                object[] Para = new object[] { orderId, orderTotal };

                return DataProvider.Instance.ExecuteNonQuery(UPDATE_ORDER_TOTAL, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}