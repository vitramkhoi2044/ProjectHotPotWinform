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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text.ToString().Trim();
            String password = txtPassword.Text.ToString().Trim();
            Employee employee = new EmployeeBUS().GetDetails(userName);
            if(employee != null)
            {
                if(employee.Username.Equals(userName) && employee.Password.Equals(password))
                {
                    MessageBox.Show("Hello User Login Successful");
                }
                else
                {
                    MessageBox.Show("Your Username or Password incorrect!!!");
                }
            }
        }
    }
}
