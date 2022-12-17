namespace ProjectHotpot
{
    partial class IngredientAddEditForm
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
            System.Windows.Forms.Label expireDateLabel;
            System.Windows.Forms.Label importDateLabel;
            System.Windows.Forms.Label ingredientNameLabel;
            System.Windows.Forms.Label ingredientPriceLabel;
            System.Windows.Forms.Label ingredientQuantityLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.expireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.ingredientPriceTextBox = new System.Windows.Forms.TextBox();
            this.ingredientQuantityTextBox = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            expireDateLabel = new System.Windows.Forms.Label();
            importDateLabel = new System.Windows.Forms.Label();
            ingredientNameLabel = new System.Windows.Forms.Label();
            ingredientPriceLabel = new System.Windows.Forms.Label();
            ingredientQuantityLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // expireDateLabel
            // 
            expireDateLabel.AutoSize = true;
            expireDateLabel.Location = new System.Drawing.Point(13, 120);
            expireDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            expireDateLabel.Name = "expireDateLabel";
            expireDateLabel.Size = new System.Drawing.Size(65, 13);
            expireDateLabel.TabIndex = 20;
            expireDateLabel.Text = "Expire Date:";
            // 
            // importDateLabel
            // 
            importDateLabel.AutoSize = true;
            importDateLabel.Location = new System.Drawing.Point(13, 93);
            importDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            importDateLabel.Name = "importDateLabel";
            importDateLabel.Size = new System.Drawing.Size(65, 13);
            importDateLabel.TabIndex = 22;
            importDateLabel.Text = "Import Date:";
            // 
            // ingredientNameLabel
            // 
            ingredientNameLabel.AutoSize = true;
            ingredientNameLabel.Location = new System.Drawing.Point(13, 41);
            ingredientNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ingredientNameLabel.Name = "ingredientNameLabel";
            ingredientNameLabel.Size = new System.Drawing.Size(38, 13);
            ingredientNameLabel.TabIndex = 24;
            ingredientNameLabel.Text = "Name:";
            // 
            // ingredientPriceLabel
            // 
            ingredientPriceLabel.AutoSize = true;
            ingredientPriceLabel.Location = new System.Drawing.Point(13, 65);
            ingredientPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ingredientPriceLabel.Name = "ingredientPriceLabel";
            ingredientPriceLabel.Size = new System.Drawing.Size(34, 13);
            ingredientPriceLabel.TabIndex = 26;
            ingredientPriceLabel.Text = "Price:";
            // 
            // ingredientQuantityLabel
            // 
            ingredientQuantityLabel.AutoSize = true;
            ingredientQuantityLabel.Location = new System.Drawing.Point(13, 145);
            ingredientQuantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ingredientQuantityLabel.Name = "ingredientQuantityLabel";
            ingredientQuantityLabel.Size = new System.Drawing.Size(49, 13);
            ingredientQuantityLabel.TabIndex = 28;
            ingredientQuantityLabel.Text = "Quantity:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(8)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(-90, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 106);
            this.panel1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(102, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(73, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "{title}";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(expireDateLabel);
            this.panel2.Controls.Add(this.expireDateDateTimePicker);
            this.panel2.Controls.Add(importDateLabel);
            this.panel2.Controls.Add(this.importDateDateTimePicker);
            this.panel2.Controls.Add(ingredientNameLabel);
            this.panel2.Controls.Add(this.ingredientNameTextBox);
            this.panel2.Controls.Add(ingredientPriceLabel);
            this.panel2.Controls.Add(this.ingredientPriceTextBox);
            this.panel2.Controls.Add(ingredientQuantityLabel);
            this.panel2.Controls.Add(this.ingredientQuantityTextBox);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(13, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 297);
            this.panel2.TabIndex = 2;
            // 
            // expireDateDateTimePicker
            // 
            this.expireDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ingredientBindingSource, "ExpireDate", true));
            this.expireDateDateTimePicker.Location = new System.Drawing.Point(76, 116);
            this.expireDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.expireDateDateTimePicker.Name = "expireDateDateTimePicker";
            this.expireDateDateTimePicker.Size = new System.Drawing.Size(309, 20);
            this.expireDateDateTimePicker.TabIndex = 21;
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataSource = typeof(ProjectHotpot.DTO.Ingredient);
            // 
            // importDateDateTimePicker
            // 
            this.importDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ingredientBindingSource, "ImportDate", true));
            this.importDateDateTimePicker.Location = new System.Drawing.Point(76, 89);
            this.importDateDateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.importDateDateTimePicker.Name = "importDateDateTimePicker";
            this.importDateDateTimePicker.Size = new System.Drawing.Size(308, 20);
            this.importDateDateTimePicker.TabIndex = 23;
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ingredientBindingSource, "IngredientName", true));
            this.ingredientNameTextBox.Location = new System.Drawing.Point(76, 38);
            this.ingredientNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(309, 20);
            this.ingredientNameTextBox.TabIndex = 25;
            // 
            // ingredientPriceTextBox
            // 
            this.ingredientPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ingredientBindingSource, "IngredientPrice", true));
            this.ingredientPriceTextBox.Location = new System.Drawing.Point(76, 63);
            this.ingredientPriceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ingredientPriceTextBox.Name = "ingredientPriceTextBox";
            this.ingredientPriceTextBox.Size = new System.Drawing.Size(309, 20);
            this.ingredientPriceTextBox.TabIndex = 27;
            // 
            // ingredientQuantityTextBox
            // 
            this.ingredientQuantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ingredientBindingSource, "IngredientQuantity", true));
            this.ingredientQuantityTextBox.Location = new System.Drawing.Point(76, 142);
            this.ingredientQuantityTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ingredientQuantityTextBox.Name = "ingredientQuantityTextBox";
            this.ingredientQuantityTextBox.Size = new System.Drawing.Size(309, 20);
            this.ingredientQuantityTextBox.TabIndex = 29;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(201)))), ((int)(((byte)(14)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(117, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 35);
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
            this.btnCancel.Location = new System.Drawing.Point(214, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 35);
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
            this.btnUpdate.Location = new System.Drawing.Point(117, 246);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 35);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.ingredientBindingSource;
            // 
            // IngredientAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 451);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "IngredientAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IngredientAddEditForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker expireDateDateTimePicker;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private System.Windows.Forms.DateTimePicker importDateDateTimePicker;
        private System.Windows.Forms.TextBox ingredientNameTextBox;
        private System.Windows.Forms.TextBox ingredientPriceTextBox;
        private System.Windows.Forms.TextBox ingredientQuantityTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}