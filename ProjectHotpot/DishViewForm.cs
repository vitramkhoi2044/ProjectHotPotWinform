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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace ProjectHotpot
{
    public partial class DishViewForm : Form
    {

        public DishViewForm()
        {
            InitializeComponent();
        }

        private void DishViewForm_Load(object sender, EventArgs e)
        {
            //Button addButton = new Button();
            //addButton.Text = "Add";
            //addButton.Location = new Point(70, 70);
            //addButton.Size = new Size(100, 100);
            //addButton.Visible = true;

            listViewDish.View = View.Details;
            listViewDish.Columns.Add("");
            listViewDish.Columns.Add("Name");
            listViewDish.Columns.Add("Price");
            listViewDish.Columns.Add("");

            //int cateID = Int32.Parse(treeViewDish.SelectedNode.Tag.ToString());
            List<Dish> dishes = new DishBUS().GetAll();
            
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    ListViewItem item = new ListViewItem(dish.DishName);
                    item.ImageKey = dish.Image;
                    item.SubItems.Add(dish.DishName);
                    item.SubItems.Add(dish.DishPrice.ToString());
                    listViewDish.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Cannot Load Data!!!");
            }
        }

        private void listViewDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDish.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewDish.SelectedItems[0];
                MessageBox.Show("Thêm món "+item.Text+" thành công");
            }
        }
    }
}
