using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Order
    {
        private int orderId;

        private DateTime orderDate;

        private int customerId;

        private int employeeId;

        private double total;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public Order() { }

        public Order(int orderId, DateTime orderDate, int customerId, int employeeId, double total)
        {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.total = total;
        }
    }
}
