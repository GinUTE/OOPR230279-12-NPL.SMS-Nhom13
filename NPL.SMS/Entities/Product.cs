using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Product
    {
        private int productId;

        private string productName;

        private double productPrice;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        public Product() { }

        public Product(int productId, string productName, double productPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
        }
    }
}
