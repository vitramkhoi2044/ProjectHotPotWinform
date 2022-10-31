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
    public partial class DishAddEditForm : Form
    {
        Dish dish = null;
        private bool addStatus = false;
        private bool updateStatus = false;
        public DishAddEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Thêm món ăn";
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            loadListCategoryName();
            addStatus = false;
        }

        public DishAddEditForm(int ID)
        {
            InitializeComponent();
            lblTitle.Text = "Update món ăn";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            updateStatus = false;
            loadListCategoryName();
            this.dish = new DishBUS().GetDishDetail(ID);
            txtName.Text = this.dish.DishName;
            txtPrice.Text = this.dish.DishPrice.ToString();
            pbImageDish.Image = HelperMethod.ConvertBinaryToImage((byte[])this.dish.Image);
            cbCategory.Text = new DishCategoryBUS().GetCategoryByID(this.dish.CategoryID).CategoryName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dish newDish = new Dish
            {
                DishName = txtName.Text.ToString().Trim(),
                DishPrice = int.Parse(txtPrice.Text.ToString().Trim()),
                Image = HelperMethod.ConvertImageToBinary(pbImageDish.Image)
            };
            string categoryName = cbCategory.Text.ToString().Trim();
            bool result = new DishBUS().AddNewDish(newDish,categoryName);
            if (result)
            {
                MessageBox.Show("Add new dish sucessful!!!");
                addStatus = true;
                Close();
            }
            else
            {
                MessageBox.Show("Sorry add new dish fail!!!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dish newDish = new Dish
            {
                DishID = this.dish.DishID,
                DishName = txtName.Text.ToString().Trim(),
                DishPrice = int.Parse(txtPrice.Text.ToString().Trim()),
                Image = HelperMethod.ConvertImageToBinary(pbImageDish.Image)
            };
            string categoryName = cbCategory.Text.ToString().Trim();
            bool result = new DishBUS().UpdateDish(newDish,categoryName);
            if (result)
            {
                MessageBox.Show("Update dish sucessful!!!");
                updateStatus = true;
                Close();
            }
            else
            {
                MessageBox.Show("Sorry update dish fail!!!");
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
        public void loadListCategoryName()
        {
            List<DishCategory> dishCategories = new DishCategoryBUS().GetAll();
            if (dishCategories.Count > 0)
            {
                foreach (DishCategory dishCategory in dishCategories)
                {
                    cbCategory.Items.Add(dishCategory.CategoryName);
                }

            }
        }
        string fileName;
        private void btnChooseAPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG|*.jpg";
            openFileDialog.ValidateNames = true;
            openFileDialog.Multiselect = false;
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    pbImageDish.Image = Image.FromFile(fileName);
                    pbImageDish.Refresh();
                }
            }
        }
    }
}
