using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class LineItem
    {
        private int orderId;

        private int productId;

        private int quantity;

        private double price;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public LineItem()
        {

        }

        public LineItem(int orderId, int productId, int quantity, double price)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
