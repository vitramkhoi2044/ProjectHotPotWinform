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
    public partial class DishManagementForm : Form
    {
        public DishManagementForm()
        {
            InitializeComponent();
        }
        private void DishManagementForm_Load(object sender, EventArgs e)
        {
            List<Dish> dishes = new DishBUS().GetAll();
            if (dishes != null)
            {
                dgvDish.Rows.Clear();
                foreach (var dish in dishes)
                {
                    dgvDish.Rows.Add(new object[]
                    {
                    dish.DishID,
                    dish.DishName,
                    dish.DishPrice,
                    dish.CategoryID,
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

        public void loadListDish()
        {
            List<Dish> dishes = new DishBUS().GetAll();
            if (dishes != null)
            {
                dgvDish.Rows.Clear();
                foreach (var dish in dishes)
                {
                    dgvDish.Rows.Add(new object[]
                    {
                    dish.DishID,
                    dish.DishName,
                    dish.DishPrice,
                    dish.CategoryID,
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DishAddEditForm dishAddEditForm = new DishAddEditForm();
            dishAddEditForm.ShowDialog();
            if (dishAddEditForm.getAddStatus())
            {
                loadListDish();
            }
        }

        private void dgvDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //edit
            {
                int ID = int.Parse(dgvDish.CurrentRow.Cells[0].Value.ToString());
                DishAddEditForm dishAddEditForm = new DishAddEditForm(ID);
                dishAddEditForm.ShowDialog();
                if (dishAddEditForm.getUpdateStatus())
                {
                    loadListDish();
                }
            }
            else if (e.ColumnIndex == 5) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvDish.CurrentRow.Cells[0].Value.ToString());
                    bool result = new DishBUS().DeleteDish(ID);
                    if (result)
                    {
                        MessageBox.Show("Delete dish successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadListDish();
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete dish fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.ToString().Trim();
                List<Dish> dishes = new DishBUS().Search(keyword);
                if (dishes != null)
                {
                    dgvDish.Rows.Clear();
                    foreach (var dish in dishes)
                    {
                        dgvDish.Rows.Add(new object[]
                        {
                            dish.DishID,
                            dish.DishName,
                            dish.DishPrice,
                            dish.CategoryID,
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
