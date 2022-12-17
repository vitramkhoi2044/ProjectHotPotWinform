using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHotpot
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Parse(DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd"));
            dtpEndDate.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            LoadData();
        }


        private void LoadData()
        {
           Dashboard model = new DashboardBUS().GetDashboard(dtpStartDate.Value,dtpEndDate.Value);
            if(model != null)
            {
                lblNumOrders.Text = model.numOrders.ToString();
                lblCustomers.Text = model.numCustomers.ToString();
                lblDishes.Text = model.numProducts.ToString();
                lblTotalRevenue.Text = model.totalRevenue.ToString();
                if(model.GrossRevenueList != null)
                {
                    chartGrossRevenue.DataSource = model.GrossRevenueList;
                    chartGrossRevenue.Series[0].XValueMember = "Date";
                    chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                    chartGrossRevenue.DataBind();
                } else
                {
                    chartGrossRevenue.DataSource = null;
                   
                    chartGrossRevenue.DataBind();
                }
              


                if(model.TopProductsList != null)
                {
                    var list = model.TopProductsList.Select(x => new { X = x.dishName, Y = x.quantity }).ToList();
                    chartTopProducts.DataSource = list;
                    chartTopProducts.Series[0].XValueMember = "X";
                    chartTopProducts.Series[0].YValueMembers = "Y";
                    chartTopProducts.DataBind();
                }
                else
                {
                    chartTopProducts.DataSource = null;
                    chartTopProducts.Series[0].XValueMember = "X";
                    chartTopProducts.Series[0].YValueMembers = "Y";
                    chartTopProducts.DataBind();
                }
                


               
                if (model.UnderstockList != null)
                {
                    dgvUnderstock.Rows.Clear();
                    foreach (var item in model.UnderstockList)
                    {
                        String date = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
                        if (item.ExpireDate == date)
                        {
                            dgvUnderstock.Rows.Add(new object[]
                            {
                                    item.IngredientName,
                                    item.IngredientQuantity,
                                     DateTime.Today.AddDays(1).ToString("dd/MM/yyyy")

                        });
                        }
                       
                    }
                }

            }
        }
       
        private void DisableCustomDates()
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOkCustomDate.Visible = false;
        }
        //Event methods
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }
        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }
        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }
        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }
        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkCustomDate.Visible = true;
        }
        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
            {

        }

        private void dgvUnderstock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void chartGrossRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}
