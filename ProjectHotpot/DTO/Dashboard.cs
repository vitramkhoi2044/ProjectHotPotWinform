using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    public class RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class TopProduct
    {
        public String dishName;
        public int quantity;
    }
    public class UnderstockProduct
    {
        public String IngredientName;
        public int IngredientQuantity;

        public string ExpireDate;
    }
    internal class Dashboard
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;
        public int numCustomers { get; set; }
        public int numProducts { get;  set; }
        public List<TopProduct> TopProductsList { get;  set; }
        public List<UnderstockProduct> UnderstockList { get;  set; }
        public List<RevenueByDate> GrossRevenueList { get;  set; }
        public int numOrders { get; set; }
        public decimal totalRevenue { get; set; }
       
    }
}
