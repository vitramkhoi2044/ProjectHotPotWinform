using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHotpot.DAO;
using ProjectHotpot.DTO;

namespace ProjectHotpot.BUS
{
    internal class DishBUS
    {
        public List<Dish> GetAll()
        {
            List<Dish> dishes = new DishDAO().SelectAll();
            if (dishes != null)
            {
                return dishes;
            }
            return null;
        }
        public Dish GetDishDetail(int id)
        {
            Dish dish = new DishDAO().SelectById(id);
            if(dish != null)
            {
                return dish;
            }
            return null;
        }
        public List<Dish> Search(string keyword)
        {
            keyword = '%' + keyword.ToLower() + '%';
            List<Dish> dishes = new DishDAO().SelectByKeyword(keyword);
            if (dishes != null)
            {
                return dishes;
            }
            return null;
        }
        public bool AddNewDish(Dish newDish, string categoryName)
        {
            newDish.CategoryID = new DishCategoryDAO().SelectByName(categoryName).CategoryID;
            bool result = new DishDAO().Insert(newDish);
            return result;
        }
        public bool UpdateDish(Dish newDish, string categoryName)
        {
            newDish.CategoryID = new DishCategoryDAO().SelectByName(categoryName).CategoryID;
            bool result = new DishDAO().Update(newDish);
            return result;
        }
        public bool DeleteDish(int id)
        {
            bool result = new DishDAO().Delete(id);
            return result;
        }

        public List<Dish> GetAllDishesByCategoryID(int id)
        {
            List<Dish> dishes = new DishDAO().SelectDishesFromCategoryID(id);
            if (dishes != null)
            {
                return dishes;
            }
            return null;
        }
    }
}
