using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class CustomerBUS
    {
        public List<Customer> GetAll()
        {
            List<Customer> customers = new CustomerDAO().SelectAll();
            if (customers != null)
            {
                return customers;
            }
            return null;
        }
        public Customer GetCustomerDetail(int id)
        {
            Customer customer = new CustomerDAO().SelectById(id);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }
        public List<Customer> Search(string keyword)
        {
            keyword = '%' + keyword.ToLower() + '%';
            List<Customer> customers = new CustomerDAO().SelectByKeyword(keyword);
            if (customers != null)
            {
                return customers;
            }
            return null;
        }
        public bool AddNewCustomer(Customer newCustomer)
        {
            bool result = new CustomerDAO().Insert(newCustomer);
            return result;
        }
        public bool UpdateCustomer(Customer newCustomer)
        {
            bool result = new CustomerDAO().Update(newCustomer);
            return result;
        }
        public bool DeleteCustomer(int id)
        {
            bool result = new CustomerDAO().Delete(id);
            return result;
        }
    }
}
