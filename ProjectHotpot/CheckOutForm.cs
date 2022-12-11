using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using ProjectHotpot.BUS;
using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using RestSharp.Extensions;
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace ProjectHotpot
{
    public partial class CheckOutForm : Form
    {
        private int orderID;
        private int TotalPrice=0;
        private int TotalQuantity=0;
        public CheckOutForm(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }
        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            listViewOrderDish.View = View.Details;
            List<Customer> customers = new CustomerBUS().GetAll();
            cbCustomer.DataSource = customers;
            cbCustomer.DisplayMember = "CustomerName";

            listViewOrderDish.Columns.Add("Name");
            listViewOrderDish.Columns.Add("Quantity");
            listViewOrderDish.Columns.Add("Price");
            listViewOrderDish.Columns.Add("Total");
            listViewOrderDish.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewOrderDish.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            List<OrderDish> orderDishes = new OrderDishBUS().GetOrderDishes(this.orderID);

            if (orderDishes != null)
            {
                foreach (var orderDish in orderDishes)
                {
                    ListViewItem item = new ListViewItem(orderDish.DishName);
                    item.SubItems.Add(orderDish.DishQuantity.ToString());
                    item.SubItems.Add(orderDish.DishPrice.ToString("C0", CultureInfo.GetCultureInfo("vi-vn")));
                    this.TotalPrice += orderDish.DishQuantity * orderDish.DishPrice;
                    this.TotalQuantity += orderDish.DishQuantity;
                    item.SubItems.Add((orderDish.DishQuantity*orderDish.DishPrice).ToString("C0", CultureInfo.GetCultureInfo("vi-vn")));
                    listViewOrderDish.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Cannot Load Data!!!");
            }
            txtTotal.Text = this.TotalPrice.ToString("C0", CultureInfo.GetCultureInfo("vi-vn"));
        }

        private void listViewOrderDish_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            Customer selected = (Customer)cbCustomer.SelectedItem;
            order.OrderID = this.orderID;
            order.OrderStatus = "False";
            order.TotalPrice=this.TotalPrice;
            order.TotalQuantity = this.TotalQuantity;
            order.CustomerID = selected.CustomerID;
            bool result = new OrderBUS().UpdateOrderStatus(order);
            if (result)
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
