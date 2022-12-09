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
        public bool AddNewOrder(Order newOrder)
        {
            newOrder.CreateDate = DateTime.Parse(newOrder.CreateDate.ToString("yyyy-MM-dd"));
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
    }
}
