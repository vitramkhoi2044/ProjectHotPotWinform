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
    public partial class IngredientAddEditForm : Form
    {
        Ingredient ingredient = null;
        private bool addStatus = false;
        private bool updateStatus = false;
        public IngredientAddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm nguyên liệu";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            addStatus = false;
            ingredientBindingSource.DataSource = new Ingredient();
        }

        public IngredientAddEditForm(int ID)
        {
            InitializeComponent();
            lblTitle.Text = "Update nguyên liệu";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            updateStatus = false;
            this.ingredient = new IngredientBUS().GetIngredientDetail(ID);
            ingredientBindingSource.DataSource = this.ingredient;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ingredientBindingSource.EndEdit();
            Ingredient newIngredient = ingredientBindingSource.Current as Ingredient;
            if (newIngredient != null)
            {
                if (newIngredient.IsValid)
                {
                    newIngredient.ImportDate = DateTime.Parse(importDateDateTimePicker.Text.ToString());
                    newIngredient.ExpireDate = DateTime.Parse(expireDateDateTimePicker.Text.ToString());
                    bool result = new IngredientBUS().AddNewIngredient(newIngredient);
                    if (result)
                    {
                        MessageBox.Show("Add new ingredient sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        addStatus = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorry add new ingredient fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ingredientBindingSource.EndEdit();
            Ingredient newIngredient = ingredientBindingSource.Current as Ingredient;
            newIngredient.IngredientID = this.ingredient.IngredientID;
            if (newIngredient.IsValid)
            {
                newIngredient.ImportDate = DateTime.Parse(importDateDateTimePicker.Text.ToString());
                newIngredient.ExpireDate = DateTime.Parse(expireDateDateTimePicker.Text.ToString());
                bool result = new IngredientBUS().UpdateIngredient(newIngredient);
                if (result)
                {
                    MessageBox.Show("Update ingredient sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateStatus = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Sorry update ingredient fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng sửa lại các trường chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
