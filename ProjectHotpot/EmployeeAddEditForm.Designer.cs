namespace ProjectHotpot
{
    partial class EmployeeAddEditForm
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
            System.Windows.Forms.Label employeeNameLabel;
            System.Windows.Forms.Label shiftLabel;
            System.Windows.Forms.Label employeeStatusLabel;
            System.Windows.Forms.Label positionLabel;
            System.Windows.Forms.Label usernameLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.employeeStatusComboBox = new System.Windows.Forms.ComboBox();
            this.shiftComboBox = new System.Windows.Forms.ComboBox();
            this.employeeNameTextBox = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            employeeNameLabel = new System.Windows.Forms.Label();
            shiftLabel = new System.Windows.Forms.Label();
            employeeStatusLabel = new System.Windows.Forms.Label();
            positionLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.AutoSize = true;
            employeeNameLabel.Location = new System.Drawing.Point(13, 41);
            employeeNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new System.Drawing.Size(38, 13);
            employeeNameLabel.TabIndex = 14;
            employeeNameLabel.Text = "Name:";
            // 
            // shiftLabel
            // 
            shiftLabel.AutoSize = true;
            shiftLabel.Location = new System.Drawing.Point(13, 71);
            shiftLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            shiftLabel.Name = "shiftLabel";
            shiftLabel.Size = new System.Drawing.Size(31, 13);
            shiftLabel.TabIndex = 15;
            shiftLabel.Text = "Shift:";
            // 
            // employeeStatusLabel
            // 
            employeeStatusLabel.AutoSize = true;
            employeeStatusLabel.Location = new System.Drawing.Point(13, 107);
            employeeStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            employeeStatusLabel.Name = "employeeStatusLabel";
            employeeStatusLabel.Size = new System.Drawing.Size(40, 13);
            employeeStatusLabel.TabIndex = 16;
            employeeStatusLabel.Text = "Status:";
            // 
            // positionLabel
            // 
            positionLabel.AutoSize = true;
            positionLabel.Location = new System.Drawing.Point(13, 146);
            positionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new System.Drawing.Size(47, 13);
            positionLabel.TabIndex = 17;
            positionLabel.Text = "Position:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(13, 179);
            usernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(58, 13);
            usernameLabel.TabIndex = 18;
            usernameLabel.Text = "Username:";
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
            this.panel2.Controls.Add(usernameLabel);
            this.panel2.Controls.Add(this.usernameTextBox);
            this.panel2.Controls.Add(positionLabel);
            this.panel2.Controls.Add(this.positionComboBox);
            this.panel2.Controls.Add(employeeStatusLabel);
            this.panel2.Controls.Add(this.employeeStatusComboBox);
            this.panel2.Controls.Add(shiftLabel);
            this.panel2.Controls.Add(this.shiftComboBox);
            this.panel2.Controls.Add(employeeNameLabel);
            this.panel2.Controls.Add(this.employeeNameTextBox);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(13, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 290);
            this.panel2.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(76, 176);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(309, 20);
            this.usernameTextBox.TabIndex = 19;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(ProjectHotpot.DTO.Employee);
            // 
            // positionComboBox
            // 
            this.positionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Position", true));
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Items.AddRange(new object[] {
            "Staff",
            "Manager"});
            this.positionComboBox.Location = new System.Drawing.Point(76, 144);
            this.positionComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(121, 21);
            this.positionComboBox.TabIndex = 18;
            // 
            // employeeStatusComboBox
            // 
            this.employeeStatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "EmployeeStatus", true));
            this.employeeStatusComboBox.FormattingEnabled = true;
            this.employeeStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "In-active"});
            this.employeeStatusComboBox.Location = new System.Drawing.Point(76, 105);
            this.employeeStatusComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.employeeStatusComboBox.Name = "employeeStatusComboBox";
            this.employeeStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.employeeStatusComboBox.TabIndex = 17;
            // 
            // shiftComboBox
            // 
            this.shiftComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Shift", true));
            this.shiftComboBox.FormattingEnabled = true;
            this.shiftComboBox.Items.AddRange(new object[] {
            "7:30 - 14:00",
            "14:20 - 23h00",
            "Fulltime"});
            this.shiftComboBox.Location = new System.Drawing.Point(76, 68);
            this.shiftComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shiftComboBox.Name = "shiftComboBox";
            this.shiftComboBox.Size = new System.Drawing.Size(121, 21);
            this.shiftComboBox.TabIndex = 16;
            // 
            // employeeNameTextBox
            // 
            this.employeeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "EmployeeName", true));
            this.employeeNameTextBox.Location = new System.Drawing.Point(76, 38);
            this.employeeNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.employeeNameTextBox.Name = "employeeNameTextBox";
            this.employeeNameTextBox.Size = new System.Drawing.Size(309, 20);
            this.employeeNameTextBox.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(201)))), ((int)(((byte)(14)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(117, 213);
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
            this.btnCancel.Location = new System.Drawing.Point(214, 213);
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
            this.btnUpdate.Location = new System.Drawing.Point(117, 213);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 35);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.employeeBindingSource;
            // 
            // EmployeeAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 451);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EmployeeAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmployeeAddEditForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.ComboBox employeeStatusComboBox;
        private System.Windows.Forms.ComboBox shiftComboBox;
        private System.Windows.Forms.TextBox employeeNameTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}