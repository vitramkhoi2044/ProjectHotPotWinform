using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    internal class OrderDish
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int DishID { get; set; }
        public string DishName { get; set; }
      
        public int DishQuantity { get; set; }
        
        public int  DishPrice { get; set; }

        public int DishTotal { get; set; }
    }
}
