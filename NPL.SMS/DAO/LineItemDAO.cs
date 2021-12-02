using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    internal class LineItemDAO : ILineItemDAO
    {
        readonly string SELECT = "SELECT * FROM LineItem WHERE order_id = @order_id";
        const string ADD_LINEITEM = @"SP_Add_LineItem @oder_id , @product_id , @quantity , @price";

        private static LineItemDAO instance;

        public static LineItemDAO Instance
        {
            get { if (instance == null) instance = new LineItemDAO(); return LineItemDAO.instance; }
            private set { LineItemDAO.instance = value; }
        }

        /// <summary>
        /// ADD LINE ITEM
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddLineItem(LineItem item)
        {
            try
            {
                object[] Para = new object[] { item.OrderId, item.ProductId, item.Quantity, item.Price };

                return DataProvider.Instance.ExecuteNonQuery(ADD_LINEITEM, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// GET ALL ITEMS BY ORDER ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<LineItem> GetAllItemsByOrderId(int orderId)
        {
            List<LineItem> items = new List<LineItem>();

            DataTable Table = DataProvider.Instance.ExecuteQuery(SELECT, new object[] { orderId });

            foreach (DataRow row in Table.Rows)
            {
                LineItem item = new LineItem
                {
                    OrderId = Convert.ToInt32(row["order_id"]),
                    ProductId = Convert.ToInt32(row["product_id"]),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    Price = Convert.ToInt32(row["price"])
                };
                items.Add(item);
            }

            return items;
        }
    }
}