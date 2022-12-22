using ProjectHotpot.BUS;
using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProjectHotpot
{
    public partial class TableManagementForm : Form
    {
        private int borderSize = 2;
        private int OrderID=-1;
        private bool flag = false;
        Table table = new Table();
        List<Dish> dishes = new List<Dish>();
        List<OrderDish> ListOrderDishes = new List<OrderDish>();
        List<OrderDish> currentOrderDishes = new List<OrderDish>();
        public TableManagementForm()
        {
            InitializeComponent();
           // menuStrip1.BackColor = Color.Black;
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(191, 15, 48);
             loadListTable();
         
          //  menuStrip1.Renderer = new MyRenderer();
        }

        public void loadListTable()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Table> listTable = new TableBUS().GetAll();
            flowLayoutPanel1.Padding = new Padding(0, 20, 0, 0);
            foreach (Table item in listTable)
            {
                Button button = new Button();
                button.Text = item.TableName + "\n" + (item.TableStatus == "False" ? "Trống" : "Có người");
                button.Width = 123;
                button.Height = 115;

                button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.BackColor = Color.Black;
                button.Tag = item;
                if (item.TableStatus == "False")
                {
                    button.ForeColor = Color.FromArgb(243, 119, 53);
                    button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(243, 119, 53);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(0, 143, 140);
                    button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(1, 89, 88);
                }
                button.Click += new System.EventHandler(this.btnButton_Click); ;
                flowLayoutPanel1.Controls.Add(button);
            }

        }


        void btnButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.table = (Table)btn.Tag;
            this.ListOrderDishes = new List<OrderDish>();
            this.OrderID = -1;
            HandleOrder();
        }



        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }
           
        }

        private void TableManagementForm_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 8);
                    break;
                case FormWindowState.Normal:
                   if(this.Padding.Top != borderSize)
                    {
                        this.Padding = new Padding(borderSize);
                    }
                    break;
            }
        }

        private void Open_DropDownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev) => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                    ctrl.BackColor = Color.FromArgb(159, 161, 224);
                else
                    ctrl.BackColor = Color.FromArgb(191, 15, 48);
            }
        }

      

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            EmployeeManagementForm form = new EmployeeManagementForm();
            form.MdiParent = this.MdiParent;
            LayoutMdi(MdiLayout.TileHorizontal);
            form.Show();
        }

        

        private void quảnLýMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DishManagementForm form = new DishManagementForm();
            form.MdiParent = this.MdiParent;
            LayoutMdi(MdiLayout.TileHorizontal);
            form.Show();
           
        }

        private void TableManagementForm_Load(object sender, EventArgs e)
        {
            LoadTableManagement();
            LoadListView();
            //Set currency VND
            dgvDishes.Columns[3].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
            dgvDishes.Columns[4].DefaultCellStyle.Format = "C0";
            dgvDishes.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-vn");
        }

        public void LoadTableManagement()
        {
            List<Employee> employees = new EmployeeBUS().GetByPosition("Staff");
            cbStaff.DataSource = employees;
            cbStaff.DisplayMember = "EmployeeName";
            List<Table> table = new TableBUS().GetAllNotActive();
            cbTable.DataSource = table;
            cbTable.DisplayMember = "TableName";
            txtTotal.Text = "";
            dgvDishes.Rows.Clear();
            dgvDishes.Refresh();
        }

            public void LoadListView()
        {
            Button addButton = new Button();
            addButton.Text = "Add";
            addButton.Width = 30;
            addButton.Height = 20;
            addButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            addButton.Location = new Point(70, 70);
            addButton.Size = new Size(100, 100);
            addButton.Visible = true;
            //button.Click += new System.EventHandler(this.btnButton_Click);

            listViewDish.View = View.Details;
            listViewDish.Columns.Add("");
            listViewDish.Columns.Add("ID");
            listViewDish.Columns.Add("Name");
            listViewDish.Columns.Add("Price");
            listViewDish.Columns.Add("");

            List<Dish> dishes = new DishBUS().GetAll();

            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    ListViewItem item = new ListViewItem(dish.DishName);
                    imageList1.Images.Add(dish.DishID.ToString(), HelperMethod.ConvertBinaryToImage(dish.Image));
                    imageList1.ImageSize = new Size(68, 68);
                    item.ImageKey = dish.DishID.ToString();
                    item.SubItems.Add(dish.DishID.ToString());
                    item.SubItems.Add(dish.DishName);
                    item.SubItems.Add(dish.DishPrice.ToString("C0", CultureInfo.GetCultureInfo("vi-vn")));
                    //item.SubItems.Add(addButton);
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
                Dish dish = new Dish();
                dish.DishID = int.Parse(item.SubItems[1].Text);
                dish.DishName = item.SubItems[2].Text;
                //Convert currency to int
                dish.DishPrice = int.Parse(item.SubItems[3].Text, NumberStyles.Currency, new CultureInfo("vi-vn"));
                AddItem(dish, 1);
            }
        }
        
        public void AddItem(Dish dish, int quantity)
        {
            this.flag = false;
            
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
            newOrderDish.OrderID = this.OrderID;
            newOrderDish.DishQuantity = quantity;
            this.ListOrderDishes.Add(newOrderDish);
            dgvDishes.Rows.Add(new object[] { dish.DishID, dish.DishName, quantity, dish.DishPrice, dish.DishPrice * quantity, "Delete" });
            CalculateTotal();
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

        private void HandleOrder()
        {
            LoadTableManagement();
            labelTable.Text = this.table.TableName;
            Order orders = new OrderBUS().GetOrderByTableID(this.table.TableID);
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
                        dish = new DishBUS().GetDishDetail(orderDish.DishID);
                        this.ListOrderDishes.Add(orderDish);
                        AddItem(dish, orderDish.DishQuantity);
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("Order mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }



        private bool UpdateOrder()
        {
            bool flag = true;
            if (this.OrderID < 0)
            {
                Order newOrder = new Order();
                newOrder.TableID = this.table.TableID;
                Employee selected = (Employee)cbStaff.SelectedItem;
                newOrder.EmployeeID = selected.EmployeeID;
                newOrder.CustomerID = 1;
                newOrder.OrderStatus = "True";
                newOrder.CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                bool result = new OrderBUS().AddNewOrder(newOrder);
                if (result)
                {
                    Order order = new OrderBUS().GetOrderByTableID(this.table.TableID);
                    this.OrderID = order.OrderID;
                    this.table.TableStatus = "True";
                    bool result2 = new TableBUS().UpdateTable(this.table);
                }
            }
            foreach (var OrderDishe in this.ListOrderDishes)
            {
                OrderDishe.OrderID = this.OrderID;
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
            loadListTable();
            return flag;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.flag = true;
            CheckOutForm checkOutForm = new CheckOutForm(this.OrderID,this.table.TableID);
            checkOutForm.ShowDialog();
            loadListTable();
            LoadTableManagement();
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


        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            Table selected = (Table)cbTable.SelectedItem;
            Order order = new OrderBUS().GetOrderByTableID(this.table.TableID);
            order.TableID = selected.TableID;
            bool result1 = new OrderBUS().UpdateOrderTableID(order);
            
            //this.OrderID = order.OrderID;

            this.table.TableStatus = "False";
            bool result2 = new TableBUS().UpdateTable(this.table);
            Table table = new Table();
            table.TableID=selected.TableID;
            table.TableStatus = "True";
            bool result3 = new TableBUS().UpdateTable(table);
            if (result1 && result2 && result3)
            {
                this.flag = true;
                MessageBox.Show("Change table sucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Change table unsucessful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadListTable();
        }

        public void LoadDataGridView(Dish dish)
        {
            dgvDishes.Rows.Add(new object[] { dish.DishID, dish.DishName, 1, dish.DishPrice, dish.DishPrice, "Delete" });
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


        private void dgvDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) //Delete
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int ID = int.Parse(dgvDishes.CurrentRow.Cells[0].Value.ToString());
                    bool result = new OrderDishBUS().DeleteOrderDish(this.OrderID, ID);
                    if (result)
                    {
                        MessageBox.Show("Delete dish successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDishes.Rows.Remove(dgvDishes.Rows[e.RowIndex]);
                        CalculateTotal();
                        this.flag = true;
                    }
                    else
                    {
                        MessageBox.Show("Sorry delete dish fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        //private void rjButton1_Click(object sender, EventArgs e)
        //{
        //    string name = this.cbListTable.GetItemText(this.cbListTable.SelectedItem);
        //    string status = this.cbTableStatus.GetItemText(this.cbTableStatus.SelectedItem);
        //    if(status == "Trống")
        //    {
        //        status = "False";
        //    } else
        //    {
        //        status = "True";
        //    }
        //    int id = Int32.Parse(name.Substring(name.Length - 1));

        //    Table newTable = new Table();
        //    newTable.TableID = id;
        //    newTable.TableName = name;
        //    newTable.TableStatus = status;

        //    bool result = new TableBUS().UpdateTable(newTable);
        //    if(newTable.TableStatus == "")
        //    {
        //        result = false;
        //    }
        //    if (result)
        //    {
        //        MessageBox.Show("Update table successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        loadListTable();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sorry update table failed", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
