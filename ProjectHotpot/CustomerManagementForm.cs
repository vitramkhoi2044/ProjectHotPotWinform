using Bunifu.UI.WinForms.Helpers.Transitions;
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
    public partial class CustomerManagementForm : Form
    {
        public CustomerManagementForm()
        {
            InitializeComponent();
        }
        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            List<Customer> customers = new CustomerBUS().GetAll();
            if (customers != null)
            {
                dgvCustomer.Rows.Clear();
                foreach (var customer in customers)
                {
                    dgvCustomer.Rows.Add(new object[]
                    {
                        customer.CustomerID,
                        customer.CustomerName,
                        customer.Score,
                        "Edit",
                        "Delete"
                    });
                }
            }
            else
            {
                MessageBox.Show("Cannot load data", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadListCustomer()
        {
            List<Customer> customers = new CustomerBUS().GetAll();
            if (customers != null)
            {
                dgvCustomer.Rows.Clear();
                foreach (var customer in customers)
                {
                    dgvCustomer.Rows.Add(new object[]
                    {
                        customer.CustomerID,
                        customer.CustomerName,
                        customer.Score,
                        "Edit",
                        "Delete"
                    });
                }
            }
            else
            {
                MessageBox.Show("Cannot load data", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //edit
            {
                int ID = int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString());
                CustomerAddEditForm customerAddEditForm = new CustomerAddEditForm(ID);
                customerAddEditForm.ShowDialog();
                if (customerAddEditForm.getUpdateStatus())
                {
                    loadListCustomer();
                }
            }
            else if (e.ColumnIndex == 4) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvCustomer.CurrentRow.Cells[0].Value.ToString());
                    bool result = new CustomerBUS().DeleteCustomer(ID);
                    if (result)
                    {
                        MessageBox.Show("Delete customer successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadListCustomer();
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete customer fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerAddEditForm customerAddEditForm = new CustomerAddEditForm();
            customerAddEditForm.ShowDialog();
            if (customerAddEditForm.getAddStatus())
            {
                loadListCustomer();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.ToString().Trim();
                List<Customer> customers = new CustomerBUS().Search(keyword);
                if (customers != null)
                {
                    dgvCustomer.Rows.Clear();
                    foreach (var customer in customers)
                    {
                        dgvCustomer.Rows.Add(new object[]
                        {
                            customer.CustomerID,
                            customer.CustomerName,
                            customer.Score,
                            "Edit",
                            "Delete"
                        });
                    }
                }
                else
                {
                    MessageBox.Show("Cannot load data","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
