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
using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace ProjectHotpot
{
    public partial class AddEditForm : Form
    {
        Employee employee = null;
        private bool addStatus = false;
        public AddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm nhân viên";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            addStatus = false;
        }

        public AddEditForm(Employee employee)
        {
            InitializeComponent();
            lblTitle.Text = "Update nhân viên";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            this.employee = employee;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee
            {
                EmployeeName = txtName.Text.ToString().Trim(),
                Shift = cbShift.Text.ToString().Trim(),
                EmployeeStatus = cbStatus.Text.ToString().Trim(),
                Position = cbPosition.Text.ToString().Trim(),
                Username = txtUsername.Text.ToString().Trim()
            };
            bool result = new EmployeeBUS().AddNewEmployee(newEmployee);
            if (result)
            {
                MessageBox.Show("Add new employee sucessful!!!");
                addStatus = true;
                Close();
            }
            else
            {
                MessageBox.Show("Sorry add new employee fail!!!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {

        }
        public bool getAddStatus()
        {
            return addStatus;
        }
    }
}
