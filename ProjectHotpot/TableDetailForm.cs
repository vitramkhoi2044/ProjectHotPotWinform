using FontAwesome.Sharp;
using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;

using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Table = ProjectHotpot.DTO.Table;

namespace ProjectHotpot
{
    public partial class TableDetailForm : Form
    {
        private int OrderID;
        private bool flag=false;
        Table table=new Table();
        List<Dish> dishes = new List<Dish>();
        List<OrderDish> ListOrderDishes= new List<OrderDish>();
        List<OrderDish> currentOrderDishes = new List<OrderDish>();
        public TableDetailForm(int TableID, string TableName, string TableStatus)
        {
            InitializeComponent();
            this.dishes = new DishBUS().GetAll();
            this.table.TableID = TableID;
            this.table.TableName = TableName;
            this.table.TableStatus = TableStatus;
            labelTable.Text = TableName;
            HandleOrder(TableID);
            this.FormClosed += ClosedHandler;
        }

        protected void ClosedHandler(object sender, EventArgs e)
        {
            if (!this.flag)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chưa cập nhật! Bạn có muốn cập nhật?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (UpdateOrder())
                    {
                        MessageBox.Show("Update sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update unsucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void HandleOrder(int TableID)
        {
            Order orders = new OrderBUS().GetOrderByTableID(TableID);
            if (orders != null && orders.OrderStatus == "True")
            {
                    this.OrderID = orders.OrderID;
                    Employee employee = new EmployeeBUS().GetDetails(orders.EmployeeID);
                    cbStaff.Text = employee.EmployeeName.ToString();
                    this.currentOrderDishes = new OrderDishBUS().GetOrderDishByOrderID(orders.OrderID);
                    if (this.currentOrderDishes != null)
                    {
                        foreach (var orderDish in this.currentOrderDishes)
                        {
                            Dish dish = new Dish();
                            dish = dishes.Find(d => d.DishID == orderDish.DishID);
                            this.ListOrderDishes.Add(orderDish);
                            AddItem(dish, orderDish.DishQuantity);
                        }
                    }
            }
            else
            {
                Order newOrder = new Order();
                newOrder.TableID = TableID;
                newOrder.EmployeeID = 1;
                newOrder.CustomerID = 4;
                newOrder.OrderStatus = "True";
                newOrder.CreateDate= DateTime.Now;
                bool result = new OrderBUS().AddNewOrder(newOrder);
                Order order = new OrderBUS().GetOrderByTableID(TableID);
                this.OrderID = orders.OrderID+1;
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
            List<Employee> employees = new EmployeeBUS().GetByPosition("Staff");
            cbStaff.DataSource = employees;
            cbStaff.DisplayMember = "EmployeeName";
            //Button addButton = new Button();
            //addButton.Text = "Add";
            //addButton.Location = new Point(70, 70);
            //addButton.Size = new Size(100, 100);
            //addButton.Visible = true;

            listViewDish.View = View.Details;
            listViewDish.Columns.Add("");
            listViewDish.Columns.Add("ID");
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
                    item.SubItems.Add(dish.DishID.ToString());
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
            dgvDishes.Columns[3].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
            dgvDishes.Columns[4].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
        }

        public void LoadDataGridView(Dish dish)
        {
            dgvDishes.Rows.Add(new object[] { dish.DishID,dish.DishName, 1, dish.DishPrice, dish.DishPrice, "Delete" });
            CalculateTotal();
        }

        public void AddItem(Dish dish,int quantity)
        {
            this.flag = false;
            //Dish getDishID = dishes.Find(d => d.DishName == dish.DishName);
            foreach (DataGridViewRow item in dgvDishes.Rows)
            {
                if (item.Cells[1].Value.ToString() == dish.DishName)
                {
                    item.Cells[2].Value = int.Parse(item.Cells[2].Value.ToString()) + 1;
                    int index = this.ListOrderDishes.FindIndex(a => a.DishID == dish.DishID);
                    this.ListOrderDishes[index].DishQuantity += 1;
                    item.Cells[4].Value = (int.Parse(item.Cells[2].Value.ToString()) * double.Parse(item.Cells[3].Value.ToString()));
                    CalculateTotal();
                    return;
                }
            }
            OrderDish newOrderDish = new OrderDish();
            newOrderDish.DishID = dish.DishID;
            newOrderDish.OrderID= this.OrderID;
            newOrderDish.DishQuantity = quantity;
            this.ListOrderDishes.Add(newOrderDish);
            dgvDishes.Rows.Add(new object[] { dish.DishID, dish.DishName, quantity, dish.DishPrice, dish.DishPrice* quantity, "Delete" });
            CalculateTotal();
        }

    public void CalculateTotal()
    {
        double total = 0;
        foreach (DataGridViewRow item in dgvDishes.Rows)
            {
                total += double.Parse(item.Cells[4].Value.ToString());
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
                dish.DishID = int.Parse(item.SubItems[1].Text);
                dish.DishName = item.SubItems[2].Text;
                //Convert currency to int
                dish.DishPrice = int.Parse(item.SubItems[3].Text, NumberStyles.Currency, new CultureInfo("vi-vn"));
                AddItem(dish,1);
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

        private bool UpdateOrder()
        {
            bool flag = true;
            foreach (var OrderDishe in this.ListOrderDishes)
            {
                int index = this.currentOrderDishes.FindIndex(a => a.DishID == OrderDishe.DishID);
                if (index >= 0)
                {
                    bool result = new OrderDishBUS().UpdateOrderDish(OrderDishe);
                    flag = result;
                }
                else
                {
                    bool result = new OrderDishBUS().AddNewOrderDish(OrderDishe);
                    flag = result;
                }
            }
            return flag;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.flag = true;
            CheckOutForm checkOutForm = new CheckOutForm(this.OrderID,this.table.TableID);
            checkOutForm.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateOrder())
            {
                this.flag = true;
                MessageBox.Show("Update sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Update unsucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dgvDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvDishes.CurrentRow.Cells[0].Value.ToString());
                    bool result = new OrderDishBUS().DeleteOrderDish(this.OrderID,ID);
                    if (result)
                    {
                        MessageBox.Show("Delete dish successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDishes.Rows.Remove(dgvDishes.Rows[e.RowIndex]);
                        this.flag = true;
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete dish fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
