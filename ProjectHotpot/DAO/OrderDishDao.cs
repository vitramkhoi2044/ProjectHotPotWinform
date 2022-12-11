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
    }
}
