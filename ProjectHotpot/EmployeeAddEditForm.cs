using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class EmployeeAddEditForm : Form
    {
        Employee employee = null;
        private bool addStatus = false;
        private bool updateStatus = false;
        public EmployeeAddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm nhân viên";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            addStatus = false;
            employeeBindingSource.DataSource = new Employee();
        }

        public EmployeeAddEditForm(int ID)
        {
            InitializeComponent();
            lblTitle.Text = "Update nhân viên";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            usernameTextBox.Enabled = false;
            updateStatus = false;
            this.employee = new EmployeeBUS().GetDetails(ID);
            employeeBindingSource.DataSource = employee;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            employeeBindingSource.EndEdit();
            Employee newEmployee = employeeBindingSource.Current as Employee;
            if(newEmployee != null)
            {
                if (newEmployee.IsValid)
                {
                    bool result = new EmployeeBUS().AddNewEmployee(newEmployee);
                    if (result)
                    {
                        MessageBox.Show("Add new employee sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        addStatus = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry add new employee fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
            employeeBindingSource.EndEdit();
            Employee newEmployee = employeeBindingSource.Current as Employee;
            newEmployee.EmployeeID = this.employee.EmployeeID;
            if (newEmployee.IsValid)
            {
                bool result = new EmployeeBUS().UpdateEmployee(newEmployee);
                if (result)
                {
                    MessageBox.Show("Update employee sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateStatus = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Sorry update employee fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng sửa lại các trường chưa hợp lệ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
