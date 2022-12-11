using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    internal class OrderDish
    {
       
        public string DishName { get; set; }
      
        public int DishQuantity { get; set; }
        
        public int  DishPrice { get; set; }

        public int DishTotal { get; set; }
    }
}
