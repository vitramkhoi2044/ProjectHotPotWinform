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
    public partial class OrderDetails : Form
    {
        public OrderDetails()
        {
            InitializeComponent();
        }
        public OrderDetails(int ID)
        {
            InitializeComponent();
            List<OrderDish> orderDish = new OrderDishBUS().GetOrderDishes(ID);
            if (orderDish != null)
            {
                dgvOrderDish.Rows.Clear();
                foreach (var order in orderDish)
                {

                    dgvOrderDish.Rows.Add(new object[]
                        {
                    order.DishName,
                  
                    order.DishQuantity,
                      order.DishPrice,
                      order.DishTotal



                        });
                }
            }
            else
            {
                MessageBox.Show("Cannot load data", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
