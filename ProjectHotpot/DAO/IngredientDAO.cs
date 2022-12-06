using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHotpot.BUS;

namespace ProjectHotpot.DAO
{
    internal class IngredientDAO
    {
        public IngredientDAO()
        {
            new SqlDataAccessHelper();
        }

        public List<Ingredient> SelectAll()
        {
            string query = "Select * From Ingredients";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Ingredient> ingredients = new List<Ingredient>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.IngredientID = int.Parse(row["IngredientID"].ToString());
                    ingredient.IngredientName = row["IngredientName"].ToString();
                    ingredient.IngredientPrice = int.Parse(row["IngredientPrice"].ToString());
                    ingredient.ImportDate = DateTime.Parse(row["ImportDate"].ToString());
                    ingredient.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                    ingredient.IngredientQuantity = int.Parse(row["IngredientQuantity"].ToString());
                    ingredients.Add(ingredient);
                }
                return ingredients;
            }
            return null;
        }
        public Ingredient SelectById(int id)
        {
            string query = "Select * From Ingredients Where IngredientID = @IngredientID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@IngredientID", id);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Ingredient ingredient = new Ingredient();
                ingredient.IngredientID = int.Parse(row["IngredientID"].ToString());
                ingredient.IngredientName = row["IngredientName"].ToString();
                ingredient.IngredientPrice = int.Parse(row["IngredientPrice"].ToString());
                ingredient.ImportDate = DateTime.Parse(row["ImportDate"].ToString());
                ingredient.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                ingredient.IngredientQuantity = int.Parse(row["IngredientQuantity"].ToString());
                return ingredient;
            }
            return null;
        }
        public List<Ingredient> SelectByKeyword(string keyword)
        {
            string query = "Select * From Ingredients Where IngredientName LIKE @Keyword";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Keyword", keyword);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<Ingredient> ingredients = new List<Ingredient>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.IngredientID = int.Parse(row["IngredientID"].ToString());
                    ingredient.IngredientName = row["IngredientName"].ToString();
                    ingredient.IngredientPrice = int.Parse(row["IngredientPrice"].ToString());
                    ingredient.ImportDate = DateTime.Parse(row["ImportDate"].ToString());
                    ingredient.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                    ingredient.IngredientQuantity = int.Parse(row["IngredientQuantity"].ToString());
                    ingredients.Add(ingredient);
                }
                return ingredients;
            }
            return null;
        }
        public bool Insert(Ingredient newIngredient)
        {
            string query = "Insert into Ingredients(IngredientName,IngredientPrice,ImportDate,ExpireDate,IngredientQuantity) Values(@IngredientName,@IngredientPrice,@ImportDate,@ExpireDate,@IngredientQuantity)";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IngredientName", newIngredient.IngredientName);
            sqlParameters[1] = new SqlParameter("@IngredientPrice", newIngredient.IngredientPrice);
            sqlParameters[2] = new SqlParameter("@ImportDate", newIngredient.ImportDate);
            sqlParameters[3] = new SqlParameter("@ExpireDate", newIngredient.ExpireDate);
            sqlParameters[4] = new SqlParameter("@IngredientQuantity", newIngredient.IngredientQuantity);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query, sqlParameters);
            return result;
        }
        public bool Update(Ingredient newIngredient)
        {
            string query = "UPDATE Ingredients SET IngredientName = @IngredientName, IngredientPrice = @IngredientPrice, ImportDate = @ImportDate, ExpireDate = @ExpireDate, IngredientQuantity = @IngredientQuantity WHERE IngredientID = @IngredientID";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@IngredientName", newIngredient.IngredientName);
            sqlParameters[1] = new SqlParameter("@IngredientPrice", newIngredient.IngredientPrice);
            sqlParameters[2] = new SqlParameter("@ImportDate", newIngredient.ImportDate);
            sqlParameters[3] = new SqlParameter("@ExpireDate", newIngredient.ExpireDate);
            sqlParameters[4] = new SqlParameter("@IngredientQuantity", newIngredient.IngredientQuantity);
            sqlParameters[5] = new SqlParameter("@IngredientID", newIngredient.IngredientID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool Delete(int id)
        {
            string query = "Delete from Ingredients where IngredientID=@IngredientID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@IngredientID", id);
            bool result = SqlDataAccessHelper.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
