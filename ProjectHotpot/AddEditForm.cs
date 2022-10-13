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
    public partial class AddEditForm : Form
    {
        Employee employee = null; 
        public AddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm nhân viên";
        }

        public AddEditForm(Employee emp)
        {
            InitializeComponent();
            lblTitle.Text = "Update nhân viên";
            employee = emp;
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
    }
}
