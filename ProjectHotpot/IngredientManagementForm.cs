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
    public partial class IngredientManagementForm : Form
    {
        public IngredientManagementForm()
        {
            InitializeComponent();
        }

        private void IngredientManagementForm_Load(object sender, EventArgs e)
        {
            List<Ingredient> ingredients = new IngredientBUS().GetAll();
            if (ingredients != null)
            {
                dgvIngredient.Rows.Clear();
                foreach (var ingredient in ingredients)
                {
                    dgvIngredient.Rows.Add(new object[]
                    {
                        ingredient.IngredientID,
                        ingredient.IngredientName,
                        ingredient.IngredientPrice,
                        ingredient.ImportDate.ToShortDateString(),
                        ingredient.ExpireDate.ToShortDateString(),
                        ingredient.IngredientQuantity,
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

        public void loadListIngredient()
        {
            List<Ingredient> ingredients = new IngredientBUS().GetAll();
            if (ingredients != null)
            {
                dgvIngredient.Rows.Clear();
                foreach (var ingredient in ingredients)
                {
                    dgvIngredient.Rows.Add(new object[]
                    {
                        ingredient.IngredientID,
                        ingredient.IngredientName,
                        ingredient.IngredientPrice,
                        ingredient.ImportDate.ToShortDateString(),
                        ingredient.ExpireDate.ToShortDateString(),
                        ingredient.IngredientQuantity,
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
            IngredientAddEditForm IngredientAddEditForm = new IngredientAddEditForm();
            IngredientAddEditForm.ShowDialog();
            if (IngredientAddEditForm.getAddStatus())
            {
                loadListIngredient();
            }
        }

        private void dgvIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //edit
            {
                int ID = int.Parse(dgvIngredient.CurrentRow.Cells[0].Value.ToString());
                IngredientAddEditForm ingredientAddEditForm = new IngredientAddEditForm(ID);
                ingredientAddEditForm.ShowDialog();
                if (ingredientAddEditForm.getUpdateStatus())
                {
                    loadListIngredient();
                }
            }
            else if (e.ColumnIndex == 7) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvIngredient.CurrentRow.Cells[0].Value.ToString());
                    bool result = new IngredientBUS().DeleteIngredient(ID);
                    if (result)
                    {
                        MessageBox.Show("Delete ingredient successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadListIngredient();
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete ingredient fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearch.Text.ToString().Trim();
                List<Ingredient> ingredients = new IngredientBUS().Search(keyword);
                if (ingredients != null)
                {
                    dgvIngredient.Rows.Clear();
                    foreach (var ingredient in ingredients)
                    {
                        dgvIngredient.Rows.Add(new object[]
                        {
                            ingredient.IngredientID,
                            ingredient.IngredientName,
                            ingredient.IngredientPrice,
                            ingredient.ImportDate.ToShortDateString(),
                            ingredient.ExpireDate.ToShortDateString(),
                            ingredient.IngredientQuantity,
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
