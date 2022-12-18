using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace ProjectHotpot.DAO
{
    internal class OrderDAO
    {
        public OrderDAO()
        {
            new SqlDataAccessHelper();
        }

        public List<Order> SelectAll()
        {
            string query = "Select * From Orders";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Order> orders = new List<Order>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Order order = new Order();
                    order.OrderID = int.Parse(row["OrderID"].ToString());
                    order.CustomerID= int.Parse(row["CustomerID"].ToString());
                    order.TotalPrice = int.Parse(row["TotalPrice"].ToString());
                    order.TotalQuantity = int.Parse(row["TotalQuantity"].ToString());
                    order.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                    order.TableID = int.Parse(row["TableID"].ToString());
                    order.CreateDate = DateTime.Parse(row["CreateDate"].ToString());    
                    order.OrderStatus = row["OrderStatus"].ToString();
                    orders.Add(order);
                }
                return orders;
            }
            return null;
        }
        public Order SelectByTableID(int TableID)
        {
            string query = "Select * From Orders Where TableID = @TableID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TableID", TableID);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<Order> orders = new List<Order>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Order order = new Order();
                    order.OrderID = int.Parse(row["OrderID"].ToString());
                    order.CustomerID = int.Parse(row["CustomerID"].ToString());
                    order.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                    order.TableID = int.Parse(row["TableID"].ToString());
                    int number1;
                    bool result1 = int.TryParse(row["TotalQuantity"].ToString(), out number1);
                    if (result1)
                    {
                        order.TotalQuantity= number1;
                    }
                    else
                    {
                        order.TotalQuantity = 0;
                    }
                    int number2;
                    bool result2 = int.TryParse(row["TotalQuantity"].ToString(), out number2);
                    if (result2)
                    {
                        order.TotalPrice = number2;
                    }
                    else
                    {
                        order.TotalPrice = 0;
                    }
                    order.OrderStatus = row["OrderStatus"].ToString();
                    order.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                    orders.Add(order);
                }
                return orders.LastOrDefault();
            }
            return null;
        }
        public bool Insert(Order newOrder)
        {
            string query = "Insert into Orders(CustomerID,EmployeeID,TableID,OrderStatus,CreateDate) Values(@CustomerID,@EmployeeID,@TableID,@OrderStatus,@CreateDate)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@CustomerID", newOrder.CustomerID);
            sqlParameters[1] = new SqlParameter("@EmployeeID", newOrder.EmployeeID);
            sqlParameters[2] = new SqlParameter("@TableID", newOrder.TableID);
            sqlParameters[3] = new SqlParameter("@OrderStatus", newOrder.OrderStatus);
            sqlParameters[4] = new SqlParameter("@CreateDate", newOrder.CreateDate);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }

        public bool Update(Order newOrder)
        {
            string query = "UPDATE Orders SET CustomerID = @CustomerID, EnployeeID = @EnployeeID, TableID = @TableID, TotalQuantity = @TotalQuantity, TotalPrice = @TotalPrice , OrderStatus = @OrderStatus, CreateDate = @CreateDate  WHERE OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@CustomerID", newOrder.CustomerID);
            sqlParameters[1] = new SqlParameter("@EnployeeID", newOrder.EmployeeID);
            sqlParameters[2] = new SqlParameter("@TableID", newOrder.TableID);
            sqlParameters[3] = new SqlParameter("@TotalQuantity", newOrder.TotalQuantity);
            sqlParameters[4] = new SqlParameter("@TotalPrice", newOrder.TotalPrice);
            sqlParameters[5] = new SqlParameter("@OrderStatus", newOrder.OrderStatus);
            sqlParameters[6] = new SqlParameter("@CreateDate", newOrder.CreateDate);
            sqlParameters[7] = new SqlParameter("@OrderID", newOrder.OrderID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool UpdateOrderStatus(Order newOrder)
        {
            string query = "UPDATE Orders SET  CustomerID = @CustomerID,OrderStatus = @OrderStatus, TotalQuantity = @TotalQuantity, TotalPrice = @TotalPrice  WHERE OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@CustomerID", newOrder.CustomerID);
            sqlParameters[1] = new SqlParameter("@OrderStatus", newOrder.OrderStatus);
            sqlParameters[2] = new SqlParameter("@TotalQuantity", newOrder.TotalQuantity);
            sqlParameters[3] = new SqlParameter("@TotalPrice", newOrder.TotalPrice);
            sqlParameters[4] = new SqlParameter("@OrderID", newOrder.OrderID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }

        public bool UpdateOrderTableID(Order newOrder)
        {
            string query = "UPDATE Orders SET  TableID = @TableID WHERE OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TableID", newOrder.TableID);
            sqlParameters[1] = new SqlParameter("@OrderID", newOrder.OrderID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
    }
}
