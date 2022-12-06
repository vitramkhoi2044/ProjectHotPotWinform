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
    public partial class EmployeeManagementForm : Form
    {
        public EmployeeManagementForm()
        {
            InitializeComponent();
        }
        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {
            List<Employee> emps = new BUS.EmployeeBUS().GetAll();
            if(emps != null)
            {
                dgvEmployee.Rows.Clear();
                foreach (var emp in emps)
                {
                    dgvEmployee.Rows.Add(new object[]
                    {
                    emp.EmployeeID,
                    emp.EmployeeName,
                    emp.Shift,
                    emp.EmployeeStatus,
                    emp.Position,
                    emp.Username,
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
       
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //edit
            {
                int ID = int.Parse(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
                EmployeeAddEditForm employeeAddEditForm = new EmployeeAddEditForm(ID);
                employeeAddEditForm.ShowDialog();
                if (employeeAddEditForm.getUpdateStatus())
                {
                    loadListEmployee();
                }
            }
            else if (e.ColumnIndex == 7) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
                    bool result = new EmployeeBUS().DeleteEmployee(ID);
                    if (result)
                    {
                        MessageBox.Show("Delete employee successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadListEmployee();
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete employees fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddEditForm employeeAddEditForm =  new EmployeeAddEditForm();
            employeeAddEditForm.ShowDialog();
            if (employeeAddEditForm.getAddStatus())
            {
                loadListEmployee();
            }
        }
        public void loadListEmployee()
        {
            List<Employee> emps = new BUS.EmployeeBUS().GetAll();
            if (emps != null)
            {
                dgvEmployee.Rows.Clear();
                foreach (var emp in emps)
                {
                    dgvEmployee.Rows.Add(new object[]
                    {
                    emp.EmployeeID,
                    emp.EmployeeName,
                    emp.Shift,
                    emp.EmployeeStatus,
                    emp.Position,
                    emp.Username,
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.ToString().Trim();
                List<Employee> emps = new EmployeeBUS().Search(keyword);
                if (emps != null)
                {
                    dgvEmployee.Rows.Clear();
                    foreach (var emp in emps)
                    {
                        dgvEmployee.Rows.Add(new object[]
                        {
                            emp.EmployeeID,
                            emp.EmployeeName,
                            emp.Shift,
                            emp.EmployeeStatus,
                            emp.Position,
                            emp.Username,
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
        }
    }
}
