using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DAO
{
    internal class OrderDishDao
    {
        public OrderDishDao()
        {
            new SqlDataAccessHelper();
        }
        public List<OrderDish> SelectById(int id)
        {
            string query = "  SELECT D.DishName, O.DishQuantity, D.DishPrice, D.DishPrice * O.DishQuantity  AS \"thanhTien\" from  OrderDishes O inner join  Dishes D on D.DishID = O.DishID where O.OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@OrderID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<OrderDish> orderDishes = new List<OrderDish>();
            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow row in dataTable.Rows)
                {
                    OrderDish orderDish = new OrderDish();
                   
                    orderDish.DishName = row["DishName"].ToString();
                    orderDish.DishQuantity = int.Parse(row["DishQuantity"].ToString());
                    orderDish.DishPrice = int.Parse(row["DishPrice"].ToString());
                    orderDish.DishTotal = int.Parse(row["thanhTien"].ToString());
                    orderDishes.Add(orderDish);

                }
                return orderDishes;
                    
            }
            return null;
        }
        public List<OrderDish> SelectByOrderID(int OrderID)
        {
            string query = "Select * From OrderDishes Where OrderID = @OrderID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@OrderID", OrderID);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<OrderDish> orderDishes = new List<OrderDish>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    OrderDish orderDish = new OrderDish();
                    orderDish.ID = int.Parse(row["ID"].ToString());
                    orderDish.OrderID = int.Parse(row["OrderID"].ToString());
                    orderDish.DishID = int.Parse(row["DishID"].ToString());
                    orderDish.DishQuantity = int.Parse(row["DishQuantity"].ToString());
                    orderDishes.Add(orderDish);
                }
                return orderDishes;
            }
            return null;
        }
        public bool Insert(OrderDish newOrderDish)
        {
            string query = "Insert into OrderDishes(OrderID,DishID,DishQuantity) Values(@OrderID,@DishID,@DishQuantity)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@OrderID", newOrderDish.OrderID);
            sqlParameters[1] = new SqlParameter("@DishID", newOrderDish.DishID);
            sqlParameters[2] = new SqlParameter("@DishQuantity", newOrderDish.DishQuantity);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }

        public bool Update(OrderDish newOrderDish)
        {
            string query = "UPDATE OrderDishes SET OrderID = @OrderID, DishID = @DishID, DishQuantity = @DishQuantity WHERE ID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@OrderID", newOrderDish.OrderID);
            sqlParameters[1] = new SqlParameter("@DishID", newOrderDish.DishID);
            sqlParameters[2] = new SqlParameter("@DishQuantity", newOrderDish.DishQuantity);
            sqlParameters[3] = new SqlParameter("@ID", newOrderDish.ID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool Delete(int OrderID, int DishID)
        {
            string query = "Delete from OrderDishes where OrderID=@OrderID and DishID = @DishID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@OrderID", OrderID);
            sqlParameters[1] = new SqlParameter("@DishID", DishID);
            bool result = SqlDataAccessHelper.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
