using R2S.Training.Dao;
using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Main
{
    class SaleManagement
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int option;
            bool end_signal = false;
            do
            {
                Console.Write
                ("\n[1]. Get all customers\n" +
                "[2]. Get all orders by customer ID\n" +
                "[3]. Get all items by order ID\n" +
                "[4]. Compute order total\n" +
                "[5]. Add customer\n" +
                "[6]. Delete customer\n" +
                "[7]. Update customer\n" +
                "[8]. Add order\n" +
                "[9]. Add lineitem\n" +
                "[10]. Update order total\n" +
                "[11]. Exit\n" +
                "========================\n" +
                "Your option: ");
                option = InputInt();

                if (option < 0 || option > 11)
                {
                    Console.WriteLine("Invalid option!");
                    continue;
                }

                Console.WriteLine();
                switch (option)
                {
                    case 1: GetAllCustomers(); break;
                    case 2: GetAllOrdersByCustomerId(); break;
                    case 3: GetAllItemsByOrderId(); break;
                    case 4: ComputeOrderTotal(); break;
                    case 5: AddCustomer(); break;
                    case 6: DeleteCustomer(); break;
                    case 7: UpdateCustomer(); break;
                    case 8: AddOrder(); break;
                    case 9: AddLineItem(); break;
                    case 10: UpdateOrderTotal(); break;
                    case 11: end_signal = true; break;
                    default: Console.WriteLine("Invalid option"); break;
                }
            } while (option < 0 || option > 11 || !end_signal);
        }

        static int InputInt()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }

                catch (Exception)
                {
                    Console.Write("Input only numbers: ");
                }
            }
        }

        /// <summary>
        /// CHECK IF ORDER ID EXISTS
        /// </summary>
        /// <param name="order_id"></param>
        /// <returns></returns>
        static bool IsExistOrderID(int order_id)
        {
            try
            {
                const string CheckOrderID = @"SELECT count (*) FROM LineItem WHERE order_id = @id ";
                object[] para = new object[] { order_id };
                object count = DataProvider.Instance.ExecuteScalar(CheckOrderID, para);
                return (int)count != 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// CHECK IF CUSTOMER ID EXISTS
        /// </summary>
        /// <param name="customer_id"></param>
        /// <returns></returns>
        static bool IsExistCustomerID(int customer_id)
        {
            try
            {
                const string CheckCustomerID = @"SELECT count (*) FROM Customer WHERE customer_id = @id ";
                object[] para = new object[] { customer_id };
                object count = DataProvider.Instance.ExecuteScalar(CheckCustomerID, para);
                return (int)count != 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// CHECK IF PRODUCT ID EXISTS
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        static bool IsExistProductID(int product_id)
        {
            try
            {
                const string CheckProductID = @"SELECT count (*) FROM Product WHERE product_id = @id ";
                object[] para = new object[] { product_id };
                object count = DataProvider.Instance.ExecuteScalar(CheckProductID, para);
                return (int)count != 0;
            }
            catch
            {
                return false;
            }
        }

        //Func1
        static void GetAllCustomers()
        {
            List<Customer> customers = CustomerDAO.Instance.GetAllCustomer();

            if (customers.Count == 0)
                Console.WriteLine("No customer found!");
            else
            {
                foreach (Customer customer in customers)
                {
                    Console.Write(customer.CustomerId + " ");
                    Console.WriteLine(customer.CustomerName);
                }
            }
        }

        //Func 2
        static void GetAllOrdersByCustomerId()
        {
            Console.Write("Enter customer ID: ");
            int customer_id = InputInt();

            List<Order> orders = OrderDAO.Instance.GetAllOrdersByCustomerId(customer_id);

            if (orders.Count == 0)
                Console.WriteLine("No order found!");
            else
            {
                foreach (Order order in orders)
                {
                    Console.Write(order.OrderId + "\t");
                    Console.Write(order.OrderDate + "\t");
                    Console.Write(order.CustomerId + "\t");
                    Console.Write(order.EmployeeId + "\t");
                    Console.WriteLine(order.Total);
                }
            }
        }

        //Func3
        static void GetAllItemsByOrderId()
        {
            Console.Write("Enter order ID: ");
            int order_id = InputInt();

            List<LineItem> lineItems = LineItemDAO.Instance.GetAllItemsByOrderId(order_id);

            if (lineItems.Count == 0)
                Console.WriteLine("No item found!");
            else
            {
                foreach (LineItem lineItem in lineItems)
                {
                    Console.Write(lineItem.OrderId + "\t");
                    Console.Write(lineItem.ProductId + "\t");
                    Console.Write(lineItem.Quantity + "\t");
                    Console.WriteLine(lineItem.Price);
                }
            }
        }

        //Func4
        static void ComputeOrderTotal()
        {
            int order_id;
            while (true)
            {
                Console.Write("Enter order ID: ");
                order_id = InputInt();

                if (IsExistOrderID(order_id))
                    break;
                Console.WriteLine("Order ID does not exist!");
            }

            double orderTotal = OrderDAO.Instance.ComputeOrderTotal(order_id);
            Console.WriteLine("Order total: " + orderTotal);
        }
        
        //Func5
        static void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter customer name: ");
            customer.CustomerName = Console.ReadLine();

            bool status = CustomerDAO.Instance.AddCustomer(customer);
            if (status)
                Console.WriteLine("Add successful!");
            else Console.WriteLine("Add failed!");
        }

        //Func6
        static void DeleteCustomer()
        {
            int customer_id;
            while (true)
            {
                Console.Write("Enter customer ID: ");
                customer_id = InputInt();

                if (IsExistCustomerID(customer_id))
                    break;
                Console.WriteLine("Customer ID does not exist!");
            }

            bool status = CustomerDAO.Instance.DeleteCustomer(customer_id);
            if (status)
                Console.WriteLine("Delete successful!");
            else Console.WriteLine("Delete failed!");
        }

        //Func7
        static void UpdateCustomer()
        {
            int customer_id;
            while (true)
            {
                Console.Write("Enter customer ID: ");
                customer_id = InputInt();

                if (IsExistCustomerID(customer_id))
                    break;
                Console.WriteLine("Customer ID does not exist!");
            }

            Console.Write("Enter customer name: ");
            string customer_name = Console.ReadLine();

            Customer customer = new Customer(customer_id, customer_name);

            bool status = CustomerDAO.Instance.UpdateCustomer(customer);
            if (status)
                Console.WriteLine("Update successful!");
            else Console.WriteLine("Update failed!");
        }

        //Func8
        static void AddOrder()
        {
            Order order = new Order
            {
                OrderDate = DateTime.Now
            };

            Console.Write("Enter customer ID: ");
            order.CustomerId = InputInt();

            Console.Write("Enter employee ID: ");
            order.EmployeeId = InputInt();

            bool status = OrderDAO.Instance.AddOrder(order);
            if (status)
                Console.WriteLine("Add successful!");
            else Console.WriteLine("Add failed!");
        }

        //Func9
        static void AddLineItem()
        {
            LineItem item = new LineItem();

            int order_id;
            while (true)
            {
                Console.Write("Enter order ID: ");
                order_id = InputInt();

                if (IsExistOrderID(order_id))
                    break;
                Console.WriteLine("Order ID does not exist!");
            }
            item.OrderId = order_id;

            int product_id;
            while (true)
            {
                Console.Write("Enter product ID: ");
                product_id = InputInt();

                if (IsExistProductID(product_id))
                    break;
                Console.WriteLine("Product ID does not exist!");
            }
            item.ProductId = product_id;

            Console.Write("Enter quantity: ");
            item.Quantity = InputInt();

            Console.Write("Enter price: ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            bool status = LineItemDAO.Instance.AddLineItem(item);

            if (status)
                Console.WriteLine("Add successful!");
            else Console.WriteLine("Add failed!");
        }

        //Func10
        static void UpdateOrderTotal()
        {
            int order_id;
            while (true)
            {
                Console.Write("Enter order ID: ");
                order_id = InputInt();

                if (IsExistOrderID(order_id))
                    break;
                Console.WriteLine("Order ID does not exist!");
            }

            bool status = OrderDAO.Instance.UpdateOrderTotal(order_id);

            if (status)
                Console.WriteLine("Update successful!");
            else Console.WriteLine("Update failed!");
        }
    }
}