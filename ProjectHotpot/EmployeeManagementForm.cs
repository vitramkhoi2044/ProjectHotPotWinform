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
            dgvEmployee.Rows.Clear();
            foreach(var emp in emps)
            {
                dgvEmployee.Rows.Add(new object[]
                {
                    emp.EmployeeID,
                    emp.EmployeeName,
                    emp.Shift,
                    emp.EmployeeStatus,
                    emp.Position,
                    emp.Username,
                    emp.Password,
                    "Edit",
                    "Delete"
                });
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            new AddEditForm().ShowDialog();
        }

       

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) //edit
            {
                new AddEditForm((Employee)dgvEmployee.CurrentRow.Tag).ShowDialog();
            }
            else if (e.ColumnIndex == 8) //update
            {

            }
        }

       
    }
}
