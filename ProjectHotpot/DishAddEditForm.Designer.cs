namespace ProjectHotpot
{
    partial class DishAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label dishNameLabel1;
            System.Windows.Forms.Label dishPriceLabel1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dishPriceTextBox1 = new System.Windows.Forms.TextBox();
            this.dishBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dishNameTextBox1 = new System.Windows.Forms.TextBox();
            this.pbImageDish = new System.Windows.Forms.PictureBox();
            this.btnChooseAPicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            dishNameLabel1 = new System.Windows.Forms.Label();
            dishPriceLabel1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dishBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageDish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dishNameLabel1
            // 
            dishNameLabel1.AutoSize = true;
            dishNameLabel1.Location = new System.Drawing.Point(17, 50);
            dishNameLabel1.Name = "dishNameLabel1";
            dishNameLabel1.Size = new System.Drawing.Size(47, 16);
            dishNameLabel1.TabIndex = 19;
            dishNameLabel1.Text = "Name:";
            // 
            // dishPriceLabel1
            // 
            dishPriceLabel1.AutoSize = true;
            dishPriceLabel1.Location = new System.Drawing.Point(17, 80);
            dishPriceLabel1.Name = "dishPriceLabel1";
            dishPriceLabel1.Size = new System.Drawing.Size(41, 16);
            dishPriceLabel1.TabIndex = 20;
            dishPriceLabel1.Text = "Price:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(8)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(-120, -6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 130);
            this.panel1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(136, 50);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(92, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "{title}";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(dishPriceLabel1);
            this.panel2.Controls.Add(this.dishPriceTextBox1);
            this.panel2.Controls.Add(dishNameLabel1);
            this.panel2.Controls.Add(this.dishNameTextBox1);
            this.panel2.Controls.Add(this.pbImageDish);
            this.panel2.Controls.Add(this.btnChooseAPicture);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(17, 146);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 366);
            this.panel2.TabIndex = 2;
            // 
            // dishPriceTextBox1
            // 
            this.dishPriceTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dishBindingSource, "DishPrice", true));
            this.dishPriceTextBox1.Location = new System.Drawing.Point(101, 77);
            this.dishPriceTextBox1.Name = "dishPriceTextBox1";
            this.dishPriceTextBox1.Size = new System.Drawing.Size(411, 22);
            this.dishPriceTextBox1.TabIndex = 2;
            // 
            // dishBindingSource
            // 
            this.dishBindingSource.DataSource = typeof(ProjectHotpot.DTO.Dish);
            // 
            // dishNameTextBox1
            // 
            this.dishNameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dishBindingSource, "DishName", true));
            this.dishNameTextBox1.Location = new System.Drawing.Point(101, 47);
            this.dishNameTextBox1.Name = "dishNameTextBox1";
            this.dishNameTextBox1.Size = new System.Drawing.Size(411, 22);
            this.dishNameTextBox1.TabIndex = 1;
            // 
            // pbImageDish
            // 
            this.pbImageDish.Location = new System.Drawing.Point(264, 138);
            this.pbImageDish.Name = "pbImageDish";
            this.pbImageDish.Size = new System.Drawing.Size(248, 131);
            this.pbImageDish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageDish.TabIndex = 17;
            this.pbImageDish.TabStop = false;
            // 
            // btnChooseAPicture
            // 
            this.btnChooseAPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(201)))), ((int)(((byte)(14)))));
            this.btnChooseAPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseAPicture.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseAPicture.ForeColor = System.Drawing.Color.White;
            this.btnChooseAPicture.Location = new System.Drawing.Point(101, 139);
            this.btnChooseAPicture.Margin = new System.Windows.Forms.Padding(4);
            this.btnChooseAPicture.Name = "btnChooseAPicture";
            this.btnChooseAPicture.Size = new System.Drawing.Size(156, 40);
            this.btnChooseAPicture.TabIndex = 4;
            this.btnChooseAPicture.Text = "Choose a picture";
            this.btnChooseAPicture.UseVisualStyleBackColor = false;
            this.btnChooseAPicture.Click += new System.EventHandler(this.btnChooseAPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Image";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(201)))), ((int)(((byte)(14)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(156, 303);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 43);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(8)))), ((int)(((byte)(21)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(285, 303);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 43);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(201)))), ((int)(((byte)(14)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(156, 303);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 43);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(101, 107);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(411, 24);
            this.cbCategory.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Category";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.dishBindingSource;
            // 
            // DishAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 555);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DishAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DishAddEditForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dishBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageDish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbImageDish;
        private System.Windows.Forms.Button btnChooseAPicture;
        private System.Windows.Forms.BindingSource dishBindingSource;
        private System.Windows.Forms.TextBox dishPriceTextBox1;
        private System.Windows.Forms.TextBox dishNameTextBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}