using FontAwesome.Sharp;
using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace ProjectHotpot
{
    public partial class TableDetailForm : Form
    {
        Table table=new Table();
        public TableDetailForm(int TableID, string TableName, string TableStatus)
        {
            InitializeComponent();
            this.table.TableID = TableID;
            this.table.TableName = TableName;
            this.table.TableStatus = TableStatus;
            List<Employee> employees = new EmployeeBUS().GetByPosition("Staff");
            cbStaff.DataSource = employees;
            cbStaff.DisplayMember = "EmployeeName";
            labelTable.Text = TableName;
            HandleOrder(TableID);
        }

        private void HandleOrder(int TableID)
        {
            //Order orders = new OrderBUS().GetOrderByTableID(TableID);
            //if (orders != null)
            //{
            //    if (orders.OrderStatus == "True")
            //    {
            //        Employee employee = new EmployeeBUS().GetDetails(orders.EnployeeID);
            //        cbStaff.Text = employee.EmployeeName;
            //    }
            //}
            //else
            {
                Order newOrder = new Order();
                newOrder.TableID = TableID;
                newOrder.EnployeeID = 1;
                newOrder.CustomerID = 1;
                newOrder.OrderStatus = "True";
                newOrder.CreateDate= DateTime.Now;
                bool result = new OrderBUS().AddNewOrder(newOrder);
                if (result)
                {
                    MessageBox.Show("Add new order sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Add new order unsucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DishViewForm_Load(object sender, EventArgs e)
        {
            tvCategory.ShowLines = false;
            LoadTreeView();

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
                    imageList1.Images.Add(dish.DishID.ToString(), HelperMethod.ConvertBinaryToImage(dish.Image));
                    //imageList1.ImageSize = new Size(68,68);
                    item.ImageKey = dish.DishID.ToString();
                    item.SubItems.Add(dish.DishName);
                    item.SubItems.Add(dish.DishPrice.ToString("C0", CultureInfo.GetCultureInfo("vi-vn")));
                    listViewDish.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Cannot Load Data!!!");
            }
            //Set currency VND
            dgvDishes.Columns[2].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
            dgvDishes.Columns[3].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
        }

        public void AddItem(Dish dish)
        {
            foreach (DataGridViewRow item in dgvDishes.Rows)
            {
                if (item.Cells[0].Value.ToString() == dish.DishName)
                {
                    item.Cells[1].Value = int.Parse(item.Cells[1].Value.ToString()) + 1;
                    item.Cells[3].Value = (int.Parse(item.Cells[1].Value.ToString()) * double.Parse(item.Cells[2].Value.ToString()));
                    CalculateTotal();
                    return;
                }
            }
            dgvDishes.Rows.Add(new object[] { dish.DishName, 1, dish.DishPrice, dish.DishPrice, "Delete" });
            CalculateTotal();
        }

    public void CalculateTotal()
    {
        double total = 0;
        foreach (DataGridViewRow item in dgvDishes.Rows)
            {
                total += double.Parse(item.Cells[3].Value.ToString());
            }
            txtTotal.Text = total.ToString("C0", CultureInfo.GetCultureInfo("vi-vn"));
    }

    public void LoadTreeView()
        {
            List<DishCategory> cates = new DishCategoryBUS().GetAll();
            foreach(var cate in cates)
            {
                TreeNode treeNode = new TreeNode(cate.CategoryName);
                treeNode.Tag = cate.CategoryID;
                tvCategory.Nodes.Add(treeNode);
            }
        }

        private void listViewDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDish.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewDish.SelectedItems[0];

                Dish dish = new Dish();
                dish.DishName = item.SubItems[1].Text;
                //Convert currency to int
                dish.DishPrice = int.Parse(item.SubItems[2].Text, NumberStyles.Currency, new CultureInfo("vi-vn"));
                AddItem(dish);
            }
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int cateID = (int)tvCategory.SelectedNode.Tag;
            List<Dish> dishes = new DishBUS().GetAllDishesByCategoryID(cateID);
            
            listViewDish.Items.Clear();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    ListViewItem item = new ListViewItem(dish.DishName);
                    imageList1.Images.Add(dish.DishID.ToString(), HelperMethod.ConvertBinaryToImage(dish.Image));
                    item.ImageKey = dish.DishID.ToString();
                    item.SubItems.Add(dish.DishName);
                    item.SubItems.Add(dish.DishPrice.ToString());
                    listViewDish.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Món ăn chưa có ở danh mục này");
            }
        }
        private ImageList setListImage()
        {
            ImageList list = new ImageList();

            List<Dish> dishes = new DishBUS().GetAll();

            foreach (var dish in dishes)
            {
                list.Images.Add(HelperMethod.ConvertBinaryToImage(dish.Image));
            }
            return list;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }


        private void dgvDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   
                }
            }
        }

        private void dgvDishes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDishes_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    dgvDishes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Brown;
            //}
        }

        private void dgvDishes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    dgvDishes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Brown;
            //}
        }
    }
}
