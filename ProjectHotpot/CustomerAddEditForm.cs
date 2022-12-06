using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
    public partial class CustomerAddEditForm : Form
    {
        Customer customer = null;
        private bool addStatus = false;
        private bool updateStatus = false;
        public CustomerAddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm khách hàng";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            addStatus = false;
            customerBindingSource.DataSource = new Customer();
        }

        public CustomerAddEditForm(int ID)
        {
            InitializeComponent();
            lblTitle.Text = "Update khách hàng";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            updateStatus = false;
            this.customer = new CustomerBUS().GetCustomerDetail(ID);
            customerBindingSource.DataSource = this.customer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            customerBindingSource.EndEdit();
            Customer newCustomer = customerBindingSource.Current as Customer;
            if (newCustomer != null)
            {
                if (newCustomer.IsValid)
                {
                    bool result = new CustomerBUS().AddNewCustomer(newCustomer);
                    if (result)
                    {
                        MessageBox.Show("Add new customer sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        addStatus = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry add new customer fail","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng sửa lại các trường chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            customerBindingSource.EndEdit();
            Customer newCustomer = customerBindingSource.Current as Customer;
            newCustomer.CustomerID = this.customer.CustomerID;
            if (newCustomer.IsValid)
            {
                bool result = new CustomerBUS().UpdateCustomer(newCustomer);
                if (result)
                {
                    MessageBox.Show("Update customer sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateStatus = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Sorry update customer fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng sửa lại các trường chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool getAddStatus()
        {
            return addStatus;
        }
        public bool getUpdateStatus()
        {
            return updateStatus;
        }
        
    }
}
