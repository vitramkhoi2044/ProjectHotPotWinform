using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    public partial class Dish
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public int DishPrice { get; set; }
        public byte[] Image { get; set; }
        public int CategoryID { get; set; }
    }
}
