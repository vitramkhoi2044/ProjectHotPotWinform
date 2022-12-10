using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class DashboardBUS
    {
        public Dashboard GetDashboard(DateTime startDate, DateTime endDate)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.totalRevenue = new DashboardDAO().totalRevenue(startDate, endDate);
            dashboard.numOrders = new DashboardDAO().totalOrder(startDate, endDate);
            dashboard.numProducts = new DashboardDAO().totalProduct();
            dashboard.GrossRevenueList = new DashboardDAO().GetOrderAnalisys(startDate, endDate);
            dashboard.numCustomers = new DashboardDAO().totalCustomer();
            dashboard.TopProductsList = new DashboardDAO().GetTopProducts(startDate, endDate);
            dashboard.UnderstockList = new DashboardDAO().GetOutStockProducts();
            return dashboard;
        }
      
    }
}
