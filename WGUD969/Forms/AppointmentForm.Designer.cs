namespace WGUD969.Forms
{
    partial class AppointmentForm
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
            cmbCustomer = new ComboBox();
            lblCustomerForm = new Label();
            lblDate = new Label();
            label2 = new Label();
            label3 = new Label();
            lblType = new Label();
            dtpDate = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbAppointmentType = new ComboBox();
            cmbLocationCity = new ComboBox();
            txtVirtualMeetingURL = new TextBox();
            rtbAppointmentDetails = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            rabInPerson = new RadioButton();
            rabVirtually = new RadioButton();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Items.AddRange(new object[] { "--Select Customer--" });
            cmbCustomer.Location = new Point(116, 6);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(224, 23);
            cmbCustomer.TabIndex = 7;
            cmbCustomer.SelectedIndexChanged += RunValidation;
            // 
            // lblCustomerForm
            // 
            lblCustomerForm.AutoSize = true;
            lblCustomerForm.Location = new Point(12, 9);
            lblCustomerForm.Name = "lblCustomerForm";
            lblCustomerForm.Size = new Size(98, 15);
            lblCustomerForm.TabIndex = 8;
            lblCustomerForm.Text = "Appointment For";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 64);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(106, 15);
            lblDate.TabIndex = 9;
            lblDate.Text = "Appointment is on";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 14;
            label2.Text = "from";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(186, 94);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 15;
            label3.Text = "to";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(12, 152);
            lblType.Name = "lblType";
            lblType.Size = new Size(89, 15);
            lblType.TabIndex = 16;
            lblType.Text = "Appointment is";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(124, 58);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(216, 23);
            dtpDate.TabIndex = 17;
            dtpDate.ValueChanged += RunValidation;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(51, 88);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(114, 23);
            dtpStartTime.TabIndex = 18;
            dtpStartTime.ValueChanged += RunValidation;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(226, 88);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(114, 23);
            dtpEndTime.TabIndex = 19;
            dtpEndTime.ValueChanged += RunValidation;
            // 
            // cmbAppointmentType
            // 
            cmbAppointmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAppointmentType.FormattingEnabled = true;
            cmbAppointmentType.Items.AddRange(new object[] { "Presentation", "Scrum" });
            cmbAppointmentType.Location = new Point(108, 149);
            cmbAppointmentType.Name = "cmbAppointmentType";
            cmbAppointmentType.Size = new Size(232, 23);
            cmbAppointmentType.TabIndex = 20;
            cmbAppointmentType.SelectedIndexChanged += RunValidation;
            // 
            // cmbLocationCity
            // 
            cmbLocationCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocationCity.FormattingEnabled = true;
            cmbLocationCity.Location = new Point(160, 176);
            cmbLocationCity.Name = "cmbLocationCity";
            cmbLocationCity.Size = new Size(180, 23);
            cmbLocationCity.TabIndex = 23;
            cmbLocationCity.SelectedIndexChanged += RunValidation;
            // 
            // txtVirtualMeetingURL
            // 
            txtVirtualMeetingURL.Enabled = false;
            txtVirtualMeetingURL.Location = new Point(153, 204);
            txtVirtualMeetingURL.Name = "txtVirtualMeetingURL";
            txtVirtualMeetingURL.PlaceholderText = "Virtual Meeting URL";
            txtVirtualMeetingURL.Size = new Size(187, 23);
            txtVirtualMeetingURL.TabIndex = 24;
            txtVirtualMeetingURL.TextChanged += RunValidation;
            // 
            // rtbAppointmentDetails
            // 
            rtbAppointmentDetails.Location = new Point(12, 273);
            rtbAppointmentDetails.Name = "rtbAppointmentDetails";
            rtbAppointmentDetails.Size = new Size(328, 135);
            rtbAppointmentDetails.TabIndex = 26;
            rtbAppointmentDetails.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 255);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 27;
            label7.Text = "Appointment details";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 194);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 28;
            label8.Text = "Located";
            // 
            // rabInPerson
            // 
            rabInPerson.AutoSize = true;
            rabInPerson.Checked = true;
            rabInPerson.Location = new Point(67, 180);
            rabInPerson.Name = "rabInPerson";
            rabInPerson.Size = new Size(87, 19);
            rabInPerson.TabIndex = 29;
            rabInPerson.TabStop = true;
            rabInPerson.Text = "in person at";
            rabInPerson.UseVisualStyleBackColor = true;
            rabInPerson.CheckedChanged += rabInPerson_CheckedChanged;
            // 
            // rabVirtually
            // 
            rabVirtually.AutoSize = true;
            rabVirtually.Location = new Point(67, 205);
            rabVirtually.Name = "rabVirtually";
            rabVirtually.Size = new Size(80, 19);
            rabVirtually.TabIndex = 30;
            rabVirtually.Text = "virtually at";
            rabVirtually.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(267, 427);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 32;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(186, 429);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 31;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 464);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rabVirtually);
            Controls.Add(rabInPerson);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(rtbAppointmentDetails);
            Controls.Add(txtVirtualMeetingURL);
            Controls.Add(cmbLocationCity);
            Controls.Add(cmbAppointmentType);
            Controls.Add(dtpEndTime);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpDate);
            Controls.Add(lblType);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblDate);
            Controls.Add(lblCustomerForm);
            Controls.Add(cmbCustomer);
            Name = "AppointmentForm";
            Text = "ee";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCustomer;
        private Label lblCustomerForm;
        private Label lblDate;
        private Label label2;
        private Label label3;
        private Label lblType;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private ComboBox cmbAppointmentType;
        private Label label6;
        private ComboBox cmbLocationCity;
        private TextBox txtVirtualMeetingURL;
        private RichTextBox rtbAppointmentDetails;
        private Label label7;
        private Label label8;
        private RadioButton rabInPerson;
        private RadioButton rabVirtually;
        private Button btnCancel;
        private Button btnSave;
    }
}