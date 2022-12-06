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
    public partial class ChangePasswordForm : Form
    {
        private string userName = null;
        public ChangePasswordForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = userName.ToString();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.ToString();
            string rePassword = txtRePassword.Text.ToString();
            if (newPassword.Equals(rePassword))
            {
                bool result = new EmployeeBUS().ChangePassword(userName, newPassword);
                if (result)
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtRePassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtNewPassword.Text = "";
                txtRePassword.Text = "";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '*';
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            txtRePassword.PasswordChar = '*';
        }
    }
}
