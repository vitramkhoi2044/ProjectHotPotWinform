using ProjectHotpot.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    internal class OrderDishBUS
    {
        public List<OrderDish> GetOrderDishes(int id)
        {
            List<OrderDish> orderDishes = new OrderDishDao().SelectById(id);
            if (orderDishes != null)
            {
                return orderDishes;
            }
            return null;
        }
    }
}
