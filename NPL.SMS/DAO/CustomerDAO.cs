using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    internal class CustomerDAO : ICustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        const string GET_ALL_CUSTOMER = @"SELECT DISTINCT Customer.customer_id, customer_name FROM Customer join Orders ON Orders. customer_id = Customer.customer_id";
        const string ADD_CUSTOMER = @"SP_Add_Customer @customer_name ";
        const string DELETE_CUSTOMER = @"SP_Delete_Customer @id";
        const string UPDATE_CUSTOMER = @"SP_Update_Customer @id , @name ";

        /// <summary>
        /// GET ALL CUSTOMER
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();

            DataTable Table = DataProvider.Instance.ExecuteQuery(GET_ALL_CUSTOMER);

            foreach (DataRow row in Table.Rows)
            {
                Customer customer = new Customer
                {
                    CustomerId = Convert.ToInt32(row["customer_id"]),
                    CustomerName = Convert.ToString(row["customer_name"])
                };
                customers.Add(customer);
            }

            return customers;
        }

        /// <summary>
        /// ADD CUSTOMER
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddCustomer(Customer customer)
        {
            try
            {
                object[] Para = new object[] { customer.CustomerName };

                return DataProvider.Instance.ExecuteNonQuery(ADD_CUSTOMER, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// DELETE CUSTOMER BY CUSTOMER ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int customerId)
        {
            try
            {
                object[] Para = new object[] { customerId };

                return DataProvider.Instance.ExecuteNonQuery(DELETE_CUSTOMER, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// UPDATE CUSTOMER
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                object[] Para = new object[] { customer.CustomerId, customer.CustomerName };

                return DataProvider.Instance.ExecuteNonQuery(UPDATE_CUSTOMER, Para) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}