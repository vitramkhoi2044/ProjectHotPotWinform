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
    internal class DishCategoryDAO
    {
        public DishCategoryDAO()
        {
            new SqlDataAccessHelper();
        }
        public List<DishCategory> SelectAll()
        {
            string query = "Select * From DishCategories";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List <DishCategory> dishCategories = new List<DishCategory>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DishCategory dishCategory = new DishCategory();
                    dishCategory.CategoryID = int.Parse(row["CategoryID"].ToString());
                    dishCategory.CategoryName = row["CategoryName"].ToString();
                    dishCategories.Add(dishCategory);
                }
                return dishCategories;
            }
            return null;
        }
        public DishCategory SelectByName(string name)
        {
            string query = "Select * From DishCategories Where CategoryName = @CategoryName";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CategoryName", name);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if(dataTable.Rows.Count > 0)
            {
                DishCategory dishCategory = new DishCategory();
                DataRow row = dataTable.Rows[0];
                dishCategory.CategoryID = int.Parse(row["CategoryID"].ToString());
                dishCategory.CategoryName = row["CategoryName"].ToString();
                return dishCategory;
            }
            return null;
        }
        public DishCategory SelectById(int id)
        {
            string query = "Select * From DishCategories Where CategoryID = @CategoryID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CategoryID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                DishCategory dishCategory = new DishCategory();
                DataRow row = dataTable.Rows[0];
                dishCategory.CategoryID = int.Parse(row["CategoryID"].ToString());
                dishCategory.CategoryName = row["CategoryName"].ToString();
                return dishCategory;
            }
            return null;
        }
    }
}
