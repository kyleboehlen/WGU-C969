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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpDate = new DateTimePicker();
            dtlpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            cmbAppointmentType = new ComboBox();
            cmbLocationCity = new ComboBox();
            txtVirtualMeetingURL = new TextBox();
            rtbAppointmentDetails = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            rabInPerson = new RadioButton();
            rabVirtually = new RadioButton();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Items.AddRange(new object[] { "--Select City--" });
            cmbCustomer.Location = new Point(116, 6);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(224, 23);
            cmbCustomer.TabIndex = 7;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 9;
            label1.Text = "Appointment is on";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 152);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 16;
            label4.Text = "Appointment is";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(124, 58);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(216, 23);
            dtpDate.TabIndex = 17;
            // 
            // dtlpStartTime
            // 
            dtlpStartTime.Format = DateTimePickerFormat.Time;
            dtlpStartTime.Location = new Point(51, 88);
            dtlpStartTime.Name = "dtlpStartTime";
            dtlpStartTime.Size = new Size(114, 23);
            dtlpStartTime.TabIndex = 18;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(226, 88);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(114, 23);
            dtpEndTime.TabIndex = 19;
            // 
            // cmbAppointmentType
            // 
            cmbAppointmentType.FormattingEnabled = true;
            cmbAppointmentType.Items.AddRange(new object[] { "Presentation", "Scrum" });
            cmbAppointmentType.Location = new Point(108, 149);
            cmbAppointmentType.Name = "cmbAppointmentType";
            cmbAppointmentType.Size = new Size(232, 23);
            cmbAppointmentType.TabIndex = 20;
            // 
            // cmbLocationCity
            // 
            cmbLocationCity.FormattingEnabled = true;
            cmbLocationCity.Location = new Point(160, 176);
            cmbLocationCity.Name = "cmbLocationCity";
            cmbLocationCity.Size = new Size(180, 23);
            cmbLocationCity.TabIndex = 23;
            // 
            // txtVirtualMeetingURL
            // 
            txtVirtualMeetingURL.Enabled = false;
            txtVirtualMeetingURL.Location = new Point(153, 204);
            txtVirtualMeetingURL.Name = "txtVirtualMeetingURL";
            txtVirtualMeetingURL.PlaceholderText = "Virtual Meeting URL";
            txtVirtualMeetingURL.Size = new Size(187, 23);
            txtVirtualMeetingURL.TabIndex = 24;
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
            this.rabInPerson.AutoSize = true;
            this.rabInPerson.Location = new Point(67, 180);
            this.rabInPerson.Name = "rabInPerson";
            this.rabInPerson.Size = new Size(87, 19);
            this.rabInPerson.TabIndex = 29;
            this.rabInPerson.TabStop = true;
            this.rabInPerson.Text = "in person at";
            this.rabInPerson.UseVisualStyleBackColor = true;
            // 
            // rabVirtually
            // 
            rabVirtually.AutoSize = true;
            rabVirtually.Location = new Point(67, 205);
            rabVirtually.Name = "rabVirtually";
            rabVirtually.Size = new Size(80, 19);
            rabVirtually.TabIndex = 30;
            rabVirtually.TabStop = true;
            rabVirtually.Text = "virtually at";
            rabVirtually.UseVisualStyleBackColor = true;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 424);
            Controls.Add(rabVirtually);
            Controls.Add(this.rabInPerson);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(rtbAppointmentDetails);
            Controls.Add(txtVirtualMeetingURL);
            Controls.Add(cmbLocationCity);
            Controls.Add(cmbAppointmentType);
            Controls.Add(dtpEndTime);
            Controls.Add(dtlpStartTime);
            Controls.Add(dtpDate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCustomerForm);
            Controls.Add(cmbCustomer);
            Name = "AppointmentForm";
            Text = "Appointment";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCustomer;
        private Label lblCustomerForm;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDate;
        private DateTimePicker dtlpStartTime;
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
    }
}