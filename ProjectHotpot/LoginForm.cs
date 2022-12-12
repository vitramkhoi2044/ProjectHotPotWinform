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
            bool result = new EmployeeBUS().Login(userName, password);
            if (result)
            {
                MessageBox.Show("Login Sucessful!  Welcome to my app", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm form = new MainForm(userName);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your Username or Password incorrect!!! Please try again","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtUserName.Focus();
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String userName = txtUserName.Text.ToString().Trim();
                String password = txtPassword.Text.ToString().Trim();
                bool result = new EmployeeBUS().Login(userName, password);
                if (result)
                {
                    MessageBox.Show("Login Sucessful!  Welcome to my app", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm form = new MainForm(userName);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your Username or Password incorrect!!! Please try again", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Text = "";
                    txtUserName.Focus();
                }
            }
        }
    }
}
