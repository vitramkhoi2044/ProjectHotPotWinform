using ProjectHotpot.BUS;
using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                button.Text =  item.TableName + "\n" + ( item.TableStatus == "False" ? "Trống" : "Có người");
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
                // button.Click += Button_Click;
                flowLayoutPanel1.Controls.Add(button);

            }
         
            cbListTable.DataSource = listTable;
            cbListTable.DisplayMember = "TableName"; 
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbListTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selected = this.cbListTable.GetItemText(this.cbListTable.SelectedItem);
            Table table = new TableBUS().GetTableDetail(selected);
            if(table.TableStatus == "False")
            {
                string [] arr = { "Trống", "Có người"};
                cbTableStatus.DataSource = arr;
            } else
            {
                string[] arr = { "Có người", "Trống" };
                cbTableStatus.DataSource = arr;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string name = this.cbListTable.GetItemText(this.cbListTable.SelectedItem);
            string status = this.cbTableStatus.GetItemText(this.cbTableStatus.SelectedItem);
            if(status == "Trống")
            {
                status = "False";
            } else
            {
                status = "True";
            }
            int id = Int32.Parse(name.Substring(name.Length - 1));

            Table newTable = new Table();
            newTable.TableID = id;
            newTable.TableName = name;
            newTable.TableStatus = status;

            bool result = new TableBUS().UpdateTable(newTable);
            if(newTable.TableStatus == "")
            {
                result = false;
            }
            if (result)
            {
                MessageBox.Show("Update table successful", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadListTable();
            }
            else
            {
                MessageBox.Show("Sorry update table failed", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
