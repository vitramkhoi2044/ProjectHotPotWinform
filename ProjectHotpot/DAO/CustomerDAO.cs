using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DAO
{
    internal class CustomerDAO
    {
        public CustomerDAO()
        {
            new SqlDataAccessHelper();
        }
        public List<Customer> SelectAll()
        {
            string query = "Select * From Customers";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Customer> customers = new List<Customer>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = int.Parse(row["CustomerID"].ToString());
                    customer.CustomerName = row["CustomerName"].ToString();
                    customer.Score = int.Parse(row["Score"].ToString());
                    customers.Add(customer);
                }
                return customers;
            }
            return null;
        }
        public Customer SelectById(int id)
        {
            string query = "Select * From Customers Where CustomerID = @CustomerID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CustomerID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Customer customer = new Customer();
                customer.CustomerID = int.Parse(row["CustomerID"].ToString());
                customer.CustomerName = row["CustomerName"].ToString();
                customer.Score = int.Parse(row["Score"].ToString());
                return customer;
            }
            return null;
        }
        public List<Customer> SelectByKeyword(string keyword)
        {
            string query = "Select * From Customers Where CustomerName LIKE @Keyword";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Keyword", keyword);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<Customer> customers = new List<Customer>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = int.Parse(row["CustomerID"].ToString());
                    customer.CustomerName = row["CustomerName"].ToString();
                    customer.Score = int.Parse(row["Score"].ToString());
                    customers.Add(customer);
                }
                return customers;
            }
            return null;
        }
        public bool Insert(Customer newCustomer)
        {
            string query = "Insert into Customers(CustomerName,Score) Values(@CustomerName,@Score)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@CustomerName", newCustomer.CustomerName);
            sqlParameters[1] = new SqlParameter("@Score", newCustomer.Score);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }
        public bool Update(Customer newCustomer)
        {
            string query = "UPDATE Customers SET CustomerName = @CustomerName, Score = @Score WHERE CustomerID = @CustomerID";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@CustomerName", newCustomer.CustomerName);
            sqlParameters[1] = new SqlParameter("@Score", newCustomer.Score);
            sqlParameters[2] = new SqlParameter("@CustomerID", newCustomer.CustomerID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool Delete(int id)
        {
            string query = "Delete from Customers where CustomerID=@CustomerID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CustomerID", id);
            bool result = SqlDataAccessHelper.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
