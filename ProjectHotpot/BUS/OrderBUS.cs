using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class OrderBUS
    {

        public List<Order> GetAll()
        {
            List<Order> orders = new OrderDAO().SelectAll();
            if (orders != null)
            {
                return orders;
            }
            return null;
        }


        public bool AddNewOrder(Order newOrder)
        {
            
            bool result = new OrderDAO().Insert(newOrder);
            return result;
        }
        public Order GetOrderByTableID(int TableID)
        {
            Order order = new OrderDAO().SelectByTableID(TableID);
            if (order != null)
            {
                return order;
            }
            return null;
        }
        public bool UpdateOrderStatus(Order newOrder)
        {
            bool result = new OrderDAO().UpdateOrderStatus(newOrder);
            return result;
        }

        public bool UpdateOrderTableID(Order newOrder)
        {
            bool result = new OrderDAO().UpdateOrderTableID(newOrder);
            return result;
        }
    }
}
