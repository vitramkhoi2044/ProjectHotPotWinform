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
    public partial class OrderManagementForm : Form
    {
        public OrderManagementForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
          
                List<Order> orders = new BUS.OrderBUS().GetAll();
                if (orders != null)
                {
                    dgvOrder.Rows.Clear();
                    foreach (var order in orders)
                    {
                   
                    dgvOrder.Rows.Add(new object[]
                        {
                    order.OrderID,
                      order.CustomerID,
                       order.TotalPrice,
                        order.TotalQuantity,
                         order.EmployeeID,
                          order.TableID,
                         order.CreateDate.ToShortDateString(),
                          order.OrderStatus,
                             "Details"


                        });
                    }
                }
                else
                {
                    MessageBox.Show("Cannot load data", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) //edit
            {
                int ID = int.Parse(dgvOrder.CurrentRow.Cells[0].Value.ToString());
                OrderDetails orderDetails = new OrderDetails(ID);
                orderDetails.ShowDialog();
                /* if (customerAddEditForm.getUpdateStatus())
                {
                    loadListCustomer();
                } */
            }
        }
    }
}
