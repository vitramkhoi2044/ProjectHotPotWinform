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
        private bool updateStatus = false;
        public AddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm nhân viên";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            addStatus = false;
        }

        public AddEditForm(int ID)
        {
            InitializeComponent();
            lblTitle.Text = "Update nhân viên";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            labelUserName.Visible = false;
            txtUsername.Visible = false;
            updateStatus = false;
            this.employee = new EmployeeBUS().GetDetails(ID);
            txtName.Text = this.employee.EmployeeName;
            cbShift.Text = this.employee.Shift;
            cbStatus.Text= this.employee.EmployeeStatus;
            cbPosition.Text=this.employee.Position;

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
            Employee newEmployee = new Employee
            {
                EmployeeID = this.employee.EmployeeID,
                EmployeeName = txtName.Text.ToString().Trim(),
                Shift = cbShift.Text.ToString().Trim(),
                EmployeeStatus = cbStatus.Text.ToString().Trim(),
                Position = cbPosition.Text.ToString().Trim(),
                Username = this.employee.Username,
                Password = this.employee.Password,
            };
            bool result = new EmployeeBUS().UpdateEmployee(newEmployee);
            if (result)
            {
                MessageBox.Show("Update employee sucessful!!!");
                updateStatus = true;
                Close();
            }
            else
            {
                MessageBox.Show("Sorry update employee fail!!!"
                    +newEmployee.EmployeeID+" "+newEmployee.EmployeeName + " " + newEmployee.EmployeeStatus + " "
                    +newEmployee.Shift + " "
                    +newEmployee.Position + " "
                    +newEmployee.Username + " "
                    + newEmployee.Password + " ");
            }
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
        public bool getUpdateStatus()
        {
            return updateStatus;
        }

        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
