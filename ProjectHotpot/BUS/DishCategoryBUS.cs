using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectHotpot.BUS
{
    internal class DishCategoryBUS
    {
        public List<DishCategory> GetAll()
        {
            List<DishCategory> dishCategories = new DishCategoryDAO().SelectAll();
            if (dishCategories != null)
            {
                return dishCategories;
            }
            return null;
        }
        public DishCategory GetCategoryByName(string name)
        {
            DishCategory dishCategory = new DishCategoryDAO().SelectByName(name);
            if(dishCategory != null)
            {
                return dishCategory;
            }
            return null;
        }
        public DishCategory GetCategoryByID(int id)
        {
            DishCategory dishCategory = new DishCategoryDAO().SelectById(id);
            if (dishCategory != null)
            {
                return dishCategory;
            }
            return null;
        }
    }
}
