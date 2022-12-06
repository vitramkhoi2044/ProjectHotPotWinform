using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class IngredientBUS
    {
        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new IngredientDAO().SelectAll();
            if (ingredients != null)
            {
                return ingredients;
            }
            return null;
        }
        public Ingredient GetIngredientDetail(int id)
        {
            Ingredient ingredient = new IngredientDAO().SelectById(id);
            if (ingredient != null)
            {
                return ingredient;
            }
            return null;
        }
        public List<Ingredient> Search(string keyword)
        {
            keyword = '%' + keyword.ToLower() + '%';
            List<Ingredient> ingredients = new IngredientDAO().SelectByKeyword(keyword);
            if (ingredients != null)
            {
                return ingredients;
            }
            return null;
        }
        public bool AddNewIngredient(Ingredient newIngredient)
        {
            newIngredient.ImportDate = DateTime.Parse(newIngredient.ImportDate.ToString("yyyy-MM-dd"));
            newIngredient.ExpireDate = DateTime.Parse(newIngredient.ExpireDate.ToString("yyyy-MM-dd"));
            bool result = new IngredientDAO().Insert(newIngredient);
            return result;
        }
        public bool UpdateIngredient(Ingredient newIngredient)
        {
            newIngredient.ImportDate = DateTime.Parse(newIngredient.ImportDate.ToString("yyyy-MM-dd"));
            newIngredient.ExpireDate = DateTime.Parse(newIngredient.ExpireDate.ToString("yyyy-MM-dd"));
            bool result = new IngredientDAO().Update(newIngredient);
            return result;
        }
        public bool DeleteIngredient(int id)
        {
            bool result = new IngredientDAO().Delete(id);
            return result;
        }
    }
}
