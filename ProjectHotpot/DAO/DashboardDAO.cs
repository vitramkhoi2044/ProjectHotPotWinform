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

        public decimal totalRevenue(DateTime startDate, DateTime endDate)
        {
            decimal total = 0;
            string query = "  select sum(TotalPrice) from Orders where CreateDate between @fromDate and @toDate group by CreateDate";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@fromDate", startDate);
            sqlParameters[1] = new SqlParameter("@toDate", endDate);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<RevenueByDate> list = new List<RevenueByDate>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    RevenueByDate item = new RevenueByDate();

                    item.TotalAmount = int.Parse(row[0].ToString());
                    total += item.TotalAmount;

                }
                return total;
            }
            return 0;
        }

        public List<RevenueByDate> GetOrderAnalisys(DateTime startDate, DateTime endDate)
        {
            string query = "  select CreateDate, sum(TotalPrice) from Orders where CreateDate between @fromDate and @toDate group by CreateDate";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@fromDate", startDate);
            sqlParameters[1] = new SqlParameter("@toDate", endDate);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<RevenueByDate> list = new List<RevenueByDate>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    RevenueByDate item = new RevenueByDate();
                    item.Date = row[0].ToString();
                    item.TotalAmount = int.Parse(row[1].ToString());
                    var firstSpaceIndex = item.Date.IndexOf(" ");
                     item.Date = item.Date.Substring(0, firstSpaceIndex);
                    list.Add(item);
                }
                return list;
            }
            return null;
        }

        public int totalOrder(DateTime startDate, DateTime endDate)
        {
            string query = "Select count(OrderID) From Orders where CreateDate between @fromDate and @toDate";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@fromDate", startDate);
            sqlParameters[1] = new SqlParameter("@toDate", endDate);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);

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

            string query = "select top 5 D.DishName, sum(OrderDishes.DishQuantity) as Q  from OrderDishes inner join Dishes D on D.DishID = OrderDishes.DishID  inner  join Orders O on O.OrderID = OrderDishes.OrderId  where CreateDate between @fromDate and @toDate  group by D.DishName";
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

            string query = "select IngredientName, IngredientQuantity, ExpireDate from Ingredients Where IngredientQuantity <= 5 or ExpireDate < GetDate()";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<UnderstockProduct> list = new List<UnderstockProduct>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    UnderstockProduct us = new UnderstockProduct();
                    us.IngredientName = row[0].ToString();
                    us.IngredientQuantity = int.Parse(row[1].ToString());
                    us.ExpireDate =row[2].ToString();
                    var firstSpaceIndex = us.ExpireDate.IndexOf(" ");
                    us.ExpireDate = us.ExpireDate.Substring(0, firstSpaceIndex);
                    list.Add(us);
                }
                return list;
            }
            return null;
        }

    }
}
