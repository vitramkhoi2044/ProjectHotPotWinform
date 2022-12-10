using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DAO
{
    internal class DashboardDAO
    {
        public DashboardDAO()
        {
            new SqlDataAccessHelper();
        }
        public int totalOrder()
        {
            string query = "Select count(OrderID) From Orders";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return int.Parse(row[0].ToString());
            }
            return -1;
        }

        public int totalCustomer()
        {
            string query = "Select count(CustomerID) From Customers";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return int.Parse(row[0].ToString());
            }
            return -1;
        }
        public int totalProduct()
        {
            string query = "Select count(DishID) From Dishes";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return int.Parse(row[0].ToString());
            }
            return -1;
        }
        public List<TopProduct> GetTopProducts(DateTime startDate, DateTime endDate)
        {

            string query = "select top 5 P.ProductName, sum(OrderItem.Quantity) as Q from OrderItem inner join Product P on P.Id = OrderItem.ProductId inner  join [Order] O on O.Id = OrderItem.OrderId  where OrderDate between @fromDate and @toDate group by P.ProductName";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@fromDate", startDate);
            sqlParameters[1] = new SqlParameter("@toDate", endDate);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<TopProduct> list = new List<TopProduct>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    TopProduct tp = new TopProduct();
                    tp.dishName = row[0].ToString();
                    tp.quantity = int.Parse(row[1].ToString());
                    list.Add(tp);
                }
                return list;
            }
            return null;
        }
        public List<UnderstockProduct> GetOutStockProducts()
        {

            string query = "select IngredientName, IngredientQuantity from Ingredients Where IngredientQuantity <= 5 and ExpireDate < GetDate()";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<UnderstockProduct> list = new List<UnderstockProduct>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    UnderstockProduct us = new UnderstockProduct();
                    us.IngredientName = row[0].ToString();
                    us.IngredientQuantity = int.Parse(row[1].ToString());
                    list.Add(us);
                }
                return list;
            }
            return null;
        }

    }
}
