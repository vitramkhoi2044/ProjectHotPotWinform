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

namespace ProjectHotpot
{
    public partial class MainForm : Form
    {
        private int borderSize = 2;
        private Size formSize;
        public MainForm()
        {
            InitializeComponent();
            CollapseMenu();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(191, 15, 48);
            this.WindowState = FormWindowState.Maximized;
            
        }
       

        private void btnMinimized_Click(object sender, EventArgs e)
        {   
            this.WindowState =FormWindowState.Minimized;

        }


     
        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                
                    break;
                case FormWindowState.Normal:
                   if(this.Padding.Top != borderSize)
                    {
                        this.Padding = new Padding(borderSize);
                    }
                    break;
            }
        }

       
        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
         if(this.pnSidebar.Width > 200)
            {
                pnSidebar.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach(Button menuButton in pnSidebar.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0, 0, 0, 0);
                }
            } else
            {
                pnSidebar.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in pnSidebar.Controls.OfType<Button>())
                {
                    menuButton.Text =menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(10,0,0,0);
                }
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

            EmployeeManagementForm form = new EmployeeManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
           
          
         }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Open_DropDownMenu(rjDropdownMenu1, sender);
        }

        private void quảnLýMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DishManagementForm form = new DishManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

     

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableManagementForm form = new TableManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }

        private void quảnLýThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagementForm form = new CustomerManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }

        private void quảnLýNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngredientManagementForm form = new IngredientManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DashboardForm form = new DashboardForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }

        private void quảnLýOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderManagementForm form = new OrderManagementForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            form.MdiParent = this;
            LayoutMdi(MdiLayout.TileHorizontal);
            pnContent.Controls.Add(form);
            form.Show();
        }
    }
}
