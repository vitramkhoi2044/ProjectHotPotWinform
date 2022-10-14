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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHotpot
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.MaxLength = 14;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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
                    MessageBox.Show("Hello " +employee.EmployeeName+ " Login Successful");
                }
                else
                {
                    MessageBox.Show("Your Username or Password incorrect!!!");
                }
            }
            else
            {
                MessageBox.Show("Your Username or Password incorrect!!!");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
           if(txtUserName.Text.Equals("Username"))
            {
                txtUserName.Text = "";
            }
        }
        private void txtUserName_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals("Username"))
            {
                txtUserName.Text = "";
            }
        }
        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
