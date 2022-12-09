using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjectHotpot.DAO
{
    internal class OrderDAO
    {
        public OrderDAO()
        {
            new SqlDataAccessHelper();
        }
        public Order SelectByTableID(int tableID)
        {
            string query = "Select * From Orders Where TableID=@tableID";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Order> orders = new List<Order>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Order order = new Order();
                    order.OrderID = int.Parse(row["OrderID"].ToString());
                    order.CustomerID = int.Parse(row["CustomerID"].ToString());
                    order.EnployeeID = int.Parse(row["EnployeeID"].ToString());
                    order.TableID = int.Parse(row["TableID"].ToString());
                    order.TotalQuantity = int.Parse(row["TotalQuantity"].ToString());
                    order.TotalPrice = int.Parse(row["TotalPrice"].ToString());
                    order.OrderStatus = row["OrderStatus"].ToString();
                    order.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                    orders.Add(order);
                }
                return orders[orders.Count-1];
            }
            return null;
        }
        public bool Insert(Order newOrder)
        {
            string query = "Insert into Orders(CustomerID,EnployeeID,TableID,OrderStatus) Values(@CustomerID,@EnployeeID,@TableID,@OrderStatus)";
            //,CreateDate
            //,@CreateDate
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@CustomerID", newOrder.CustomerID);
            sqlParameters[1] = new SqlParameter("@EnployeeID", newOrder.EnployeeID);
            sqlParameters[2] = new SqlParameter("@TableID", newOrder.TableID);
            sqlParameters[3] = new SqlParameter("@OrderStatus", newOrder.OrderStatus);
            //sqlParameters[4] = new SqlParameter("@CreateDate", newOrder.CreateDate);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }

        public bool Update(Order newOrder)
        {
            string query = "UPDATE Orders SET CustomerID = @CustomerID, EnployeeID = @EnployeeID, TableID = @TableID, TotalQuantity = @TotalQuantity, TotalPrice = @TotalPrice , OrderStatus = @OrderStatus, CreateDate = @CreateDate  WHERE OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@CustomerID", newOrder.CustomerID);
            sqlParameters[1] = new SqlParameter("@EnployeeID", newOrder.EnployeeID);
            sqlParameters[2] = new SqlParameter("@TableID", newOrder.TableID);
            sqlParameters[3] = new SqlParameter("@TotalQuantity", newOrder.TotalQuantity);
            sqlParameters[4] = new SqlParameter("@TotalPrice", newOrder.TotalPrice);
            sqlParameters[5] = new SqlParameter("@OrderStatus", newOrder.OrderStatus);
            sqlParameters[6] = new SqlParameter("@CreateDate", newOrder.CreateDate);
            sqlParameters[7] = new SqlParameter("@OrderID", newOrder.OrderID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
    }
}
