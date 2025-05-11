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
            lsvAppointments = new ListView();
            monthCalendar = new MonthCalendar();
            tbpCustomers = new TabPage();
            txtPhoneNumber = new TextBox();
            txtZipCode = new TextBox();
            btnAddCity = new Button();
            cmbCity = new ComboBox();
            txtLine2 = new TextBox();
            txtLine1 = new TextBox();
            lblCustomerAddress = new Label();
            txtCustomerName = new TextBox();
            lblCustomerForm = new Label();
            btnCancel = new Button();
            btnCustomerSave = new Button();
            btnAddCustomer = new Button();
            lsvCustomers = new ListView();
            tbcMainView.SuspendLayout();
            tbpAppointments.SuspendLayout();
            tbpCustomers.SuspendLayout();
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
            tbpAppointments.Controls.Add(lsvAppointments);
            tbpAppointments.Controls.Add(monthCalendar);
            tbpAppointments.Location = new Point(4, 24);
            tbpAppointments.Name = "tbpAppointments";
            tbpAppointments.Padding = new Padding(3);
            tbpAppointments.Size = new Size(722, 246);
            tbpAppointments.TabIndex = 0;
            tbpAppointments.Text = "Appointments";
            tbpAppointments.UseVisualStyleBackColor = true;
            // 
            // lsvAppointments
            // 
            lsvAppointments.Location = new Point(290, 6);
            lsvAppointments.Name = "lsvAppointments";
            lsvAppointments.Size = new Size(426, 234);
            lsvAppointments.TabIndex = 1;
            lsvAppointments.UseCompatibleStateImageBehavior = false;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(12, 39);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            // 
            // tbpCustomers
            // 
            tbpCustomers.Controls.Add(txtPhoneNumber);
            tbpCustomers.Controls.Add(txtZipCode);
            tbpCustomers.Controls.Add(btnAddCity);
            tbpCustomers.Controls.Add(cmbCity);
            tbpCustomers.Controls.Add(txtLine2);
            tbpCustomers.Controls.Add(txtLine1);
            tbpCustomers.Controls.Add(lblCustomerAddress);
            tbpCustomers.Controls.Add(txtCustomerName);
            tbpCustomers.Controls.Add(lblCustomerForm);
            tbpCustomers.Controls.Add(btnCancel);
            tbpCustomers.Controls.Add(btnCustomerSave);
            tbpCustomers.Controls.Add(btnAddCustomer);
            tbpCustomers.Controls.Add(lsvCustomers);
            tbpCustomers.Location = new Point(4, 24);
            tbpCustomers.Name = "tbpCustomers";
            tbpCustomers.Padding = new Padding(3);
            tbpCustomers.Size = new Size(722, 246);
            tbpCustomers.TabIndex = 1;
            tbpCustomers.Text = "Customers";
            tbpCustomers.UseVisualStyleBackColor = true;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(6, 57);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "Phone Number";
            txtPhoneNumber.Size = new Size(175, 23);
            txtPhoneNumber.TabIndex = 2;
            // 
            // txtZipCode
            // 
            txtZipCode.Enabled = false;
            txtZipCode.Location = new Point(6, 188);
            txtZipCode.Name = "txtZipCode";
            txtZipCode.PlaceholderText = "Zip Code";
            txtZipCode.Size = new Size(101, 23);
            txtZipCode.TabIndex = 7;
            txtZipCode.TabStop = false;
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
            cmbCity.TabIndex = 6;
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
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(187, 217);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCustomerSave
            // 
            btnCustomerSave.Location = new Point(106, 217);
            btnCustomerSave.Name = "btnCustomerSave";
            btnCustomerSave.Size = new Size(75, 23);
            btnCustomerSave.TabIndex = 9;
            btnCustomerSave.Text = "Save";
            btnCustomerSave.UseVisualStyleBackColor = true;
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
            // 
            // lsvCustomers
            // 
            lsvCustomers.Location = new Point(268, 6);
            lsvCustomers.Name = "lsvCustomers";
            lsvCustomers.Size = new Size(448, 234);
            lsvCustomers.TabIndex = 0;
            lsvCustomers.UseCompatibleStateImageBehavior = false;
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcMainView;
        private TabPage tbpAppointments;
        private TabPage tbpCustomers;
        private ListView lsvAppointments;
        private MonthCalendar monthCalendar;
        private ListView lsvCustomers;
        private Button btnCancel;
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
    }
}