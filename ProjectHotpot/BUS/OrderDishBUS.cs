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
        public bool AddNewOrderDish(OrderDish newOrderDish)
        {
            bool result = new OrderDishDao().Insert(newOrderDish);
            return result;
        }
        public List<OrderDish> GetOrderDishByOrderID(int OrderID)
        {
            List<OrderDish> orderDishes = new OrderDishDao().SelectByOrderID(OrderID);
            if (orderDishes != null)
            {
                return orderDishes;
            }
            return null;
        }
        public bool UpdateOrderDish(OrderDish newOrderDish)
        {
            bool result = new OrderDishDao().Update(newOrderDish);
            return result;
        }
        public bool DeleteOrderDish(int OrderID, int DishID)
        {
            bool result = new OrderDishDao().Delete(OrderID, DishID);
            return result;
        }
    }
}
