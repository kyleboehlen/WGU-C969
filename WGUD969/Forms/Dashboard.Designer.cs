namespace WGUD969.Forms
{
    partial class Dashboard
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
            tbcMainView = new TabControl();
            tbpAppointments = new TabPage();
            monthCalendar = new MonthCalendar();
            tbpCustomers = new TabPage();
            dgvCustomers = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            PostalCode = new DataGridViewTextBoxColumn();
            txtPhoneNumber = new TextBox();
            txtZipCode = new TextBox();
            btnAddCity = new Button();
            cmbCity = new ComboBox();
            txtLine2 = new TextBox();
            txtLine1 = new TextBox();
            lblCustomerAddress = new Label();
            txtCustomerName = new TextBox();
            lblCustomerForm = new Label();
            btnDelete = new Button();
            btnCustomerSave = new Button();
            btnAddCustomer = new Button();
            tbcMainView.SuspendLayout();
            tbpAppointments.SuspendLayout();
            tbpCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // tbcMainView
            // 
            tbcMainView.Controls.Add(tbpAppointments);
            tbcMainView.Controls.Add(tbpCustomers);
            tbcMainView.Location = new Point(12, 12);
            tbcMainView.Name = "tbcMainView";
            tbcMainView.SelectedIndex = 0;
            tbcMainView.Size = new Size(730, 274);
            tbcMainView.TabIndex = 0;
            // 
            // tbpAppointments
            // 
            tbpAppointments.Controls.Add(monthCalendar);
            tbpAppointments.Location = new Point(4, 24);
            tbpAppointments.Name = "tbpAppointments";
            tbpAppointments.Padding = new Padding(3);
            tbpAppointments.Size = new Size(722, 246);
            tbpAppointments.TabIndex = 0;
            tbpAppointments.Text = "Appointments";
            tbpAppointments.UseVisualStyleBackColor = true;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(12, 39);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            // 
            // tbpCustomers
            // 
            tbpCustomers.Controls.Add(dgvCustomers);
            tbpCustomers.Controls.Add(txtPhoneNumber);
            tbpCustomers.Controls.Add(txtZipCode);
            tbpCustomers.Controls.Add(btnAddCity);
            tbpCustomers.Controls.Add(cmbCity);
            tbpCustomers.Controls.Add(txtLine2);
            tbpCustomers.Controls.Add(txtLine1);
            tbpCustomers.Controls.Add(lblCustomerAddress);
            tbpCustomers.Controls.Add(txtCustomerName);
            tbpCustomers.Controls.Add(lblCustomerForm);
            tbpCustomers.Controls.Add(btnDelete);
            tbpCustomers.Controls.Add(btnCustomerSave);
            tbpCustomers.Controls.Add(btnAddCustomer);
            tbpCustomers.Location = new Point(4, 24);
            tbpCustomers.Name = "tbpCustomers";
            tbpCustomers.Padding = new Padding(3);
            tbpCustomers.Size = new Size(722, 246);
            tbpCustomers.TabIndex = 1;
            tbpCustomers.Text = "Customers";
            tbpCustomers.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { name, PhoneNumber, City, PostalCode });
            dgvCustomers.Location = new Point(268, 6);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(448, 234);
            dgvCustomers.TabIndex = 11;
            dgvCustomers.SelectionChanged += dgvCustomer_SelectionChanged;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            // 
            // City
            // 
            City.HeaderText = "City";
            City.Name = "City";
            City.ReadOnly = true;
            // 
            // PostalCode
            // 
            PostalCode.HeaderText = "Zip Code";
            PostalCode.Name = "PostalCode";
            PostalCode.ReadOnly = true;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(6, 57);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Phone Number";
            txtPhoneNumber.Size = new Size(175, 23);
            txtPhoneNumber.TabIndex = 2;
            txtPhoneNumber.TextChanged += OnTextBoxValueChange;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            // 
            // txtZipCode
            // 
            txtZipCode.Location = new Point(6, 188);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.PlaceholderText = "Zip Code";
            txtZipCode.Size = new Size(101, 23);
            txtZipCode.TabIndex = 6;
            txtZipCode.TabStop = false;
            txtZipCode.TextChanged += OnTextBoxValueChange;
            txtZipCode.KeyPress += txtZipCde_KeyPress;
            // 
            // btnAddCity
            // 
            btnAddCity.Location = new Point(187, 158);
            btnAddCity.Name = "btnAddCity";
            btnAddCity.Size = new Size(75, 23);
            btnAddCity.TabIndex = 10;
            btnAddCity.TabStop = false;
            btnAddCity.Text = "Add City";
            btnAddCity.UseVisualStyleBackColor = true;
            btnAddCity.Click += btnAddCity_Click;
            // 
            // cmbCity
            // 
            cmbCity.FormattingEnabled = true;
            cmbCity.Items.AddRange(new object[] { "--Select City--" });
            cmbCity.Location = new Point(3, 159);
            cmbCity.Name = "cmbCity";
            cmbCity.Size = new Size(171, 23);
            cmbCity.TabIndex = 5;
            // 
            // txtLine2
            // 
            txtLine2.Location = new Point(3, 130);
            txtLine2.Name = "txtLine2";
            txtLine2.PlaceholderText = "Address Line 2";
            txtLine2.Size = new Size(171, 23);
            txtLine2.TabIndex = 4;
            // 
            // txtLine1
            // 
            txtLine1.Location = new Point(3, 101);
            txtLine1.Name = "txtLine1";
            txtLine1.PlaceholderText = "Address Line 1";
            txtLine1.Size = new Size(171, 23);
            txtLine1.TabIndex = 3;
            txtLine1.TextChanged += OnTextBoxValueChange;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.AutoSize = true;
            lblCustomerAddress.Location = new Point(3, 83);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(104, 15);
            lblCustomerAddress.TabIndex = 6;
            lblCustomerAddress.Text = "Customer Address";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(6, 28);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "Customer Name";
            txtCustomerName.Size = new Size(175, 23);
            txtCustomerName.TabIndex = 1;
            txtCustomerName.TextChanged += OnTextBoxValueChange;
            // 
            // lblCustomerForm
            // 
            lblCustomerForm.AutoSize = true;
            lblCustomerForm.Location = new Point(6, 10);
            lblCustomerForm.Name = "lblCustomerForm";
            lblCustomerForm.Size = new Size(84, 15);
            lblCustomerForm.TabIndex = 4;
            lblCustomerForm.Text = "Add Customer";
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(187, 217);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCustomerSave
            // 
            btnCustomerSave.Location = new Point(106, 217);
            btnCustomerSave.Name = "btnCustomerSave";
            btnCustomerSave.Size = new Size(75, 23);
            btnCustomerSave.TabIndex = 7;
            btnCustomerSave.Text = "Save";
            btnCustomerSave.UseVisualStyleBackColor = true;
            btnCustomerSave.Click += btnCustomerSave_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(187, 6);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(75, 23);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.TabStop = false;
            btnAddCustomer.Text = "Add New";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 298);
            Controls.Add(tbcMainView);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Form_Load;
            tbcMainView.ResumeLayout(false);
            tbpAppointments.ResumeLayout(false);
            tbpCustomers.ResumeLayout(false);
            tbpCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcMainView;
        private TabPage tbpAppointments;
        private TabPage tbpCustomers;
        private MonthCalendar monthCalendar;
        private Button btnDelete;
        private Button btnCustomerSave;
        private Button btnAddCustomer;
        private ComboBox cmbCity;
        private TextBox txtLine2;
        private TextBox txtLine1;
        private Label lblCustomerAddress;
        private TextBox txtCustomerName;
        private Label lblCustomerForm;
        private Button btnAddCity;
        private TextBox txtPhoneNumber;
        private TextBox txtZipCode;
        private DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn PostalCode;
    }
}