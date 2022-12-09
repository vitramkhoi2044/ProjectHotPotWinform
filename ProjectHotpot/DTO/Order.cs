using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }

        public int EnployeeID { get; set; }
        public int TableID { get; set; }

        public int TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreateDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
