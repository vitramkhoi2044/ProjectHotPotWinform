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
    internal class DishDAO
    {
        public DishDAO()
        {
            new SqlDataAccessHelper();
        }
        public List<Dish> SelectAll()
        {
            string query = "Select * From Dishes";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Dish> dishes = new List<Dish>();
            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Dish dish = new Dish();
                    dish.DishID = int.Parse(row["DishID"].ToString());
                    dish.DishName = row["DishName"].ToString();
                    dish.DishPrice = int.Parse(row["DishPrice"].ToString());
                    dish.Image = row["Image"].ToString();
                    dish.CategoryID = int.Parse(row["CategoryID"].ToString());
                    dishes.Add(dish);
                }
                return dishes;
            }
            return null;
        }
        public Dish SelectById(int id)
        {
            string query = "Select * From Dishes Where DishID = @DishID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@DishID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query,sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                Dish dish = new Dish();
                DataRow row = dataTable.Rows[0];
                dish.DishID = int.Parse(row["DishID"].ToString());
                dish.DishName = row["DishName"].ToString();
                dish.DishPrice = int.Parse(row["DishPrice"].ToString());
                dish.Image = row["Image"].ToString();
                dish.CategoryID = int.Parse(row["CategoryID"].ToString());
                return dish;
            }
            return null;
        }
        public Dish SelectByKeyword(string keyword)
        {
            string query = "Select * From Dishes Where DishName LIKE @Keyword";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Keyword", keyword);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                Dish dish = new Dish();
                DataRow row = dataTable.Rows[0];
                dish.DishID = int.Parse(row["DishID"].ToString());
                dish.DishName = row["DishName"].ToString();
                dish.DishPrice = int.Parse(row["DishPrice"].ToString());
                dish.Image = row["Image"].ToString();
                dish.CategoryID = int.Parse(row["CategoryID"].ToString());
                return dish;
            }
            return null;
        }
        public bool Insert(Dish newDish)
        {
            string query = "Insert into Dishes(DishName,DishPrice,Image,CategoryID) Values(@DishName,@DishPrice,@Image,@CategoryID)";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@DishName", newDish.DishName);
            sqlParameters[1] = new SqlParameter("@DishPrice", newDish.DishPrice);
            sqlParameters[2] = new SqlParameter("@Image", newDish.Image);
            sqlParameters[3] = new SqlParameter("@CategoryID", newDish.CategoryID);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }
        public bool Update(Dish newDish)
        {
            string query = "UPDATE Dishes SET DishName = @DishName, DishPrice = @DishPrice, Image = @Image, CategoryID = @CategoryID WHERE DishID = @DishID";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@DishName", newDish.DishName);
            sqlParameters[1] = new SqlParameter("@DishPrice", newDish.DishPrice);
            sqlParameters[2] = new SqlParameter("@Image", newDish.Image);
            sqlParameters[3] = new SqlParameter("@CategoryID", newDish.CategoryID);
            sqlParameters[4] = new SqlParameter("@DishID", newDish.DishID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool Delete(int id)
        {
            string query = "Delete from Dishes where DishID=@DishID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@DishID", id);
            bool result = SqlDataAccessHelper.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }

        public List<Dish> SelectDishesFromCategoryID(int id)
        {
            string query = "Select * From Dishes Where CategoryID = @CategoryID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CategoryID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<Dish> dishes = new List<Dish>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Dish dish = new Dish();
                    dish.DishID = int.Parse(row["DishID"].ToString());
                    dish.DishName = row["DishName"].ToString();
                    dish.DishPrice = int.Parse(row["DishPrice"].ToString());
                    dish.Image = row["Image"].ToString();
                    dish.CategoryID = int.Parse(row["CategoryID"].ToString());
                    dishes.Add(dish);
                }
                return dishes;
            }
            return null;
        }
    }
}
