namespace WGUD969.Forms
{
    partial class Appointment
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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker3 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            label7 = new Label();
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
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(124, 58);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(216, 23);
            dateTimePicker1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(51, 88);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(114, 23);
            dateTimePicker2.TabIndex = 18;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Location = new Point(226, 88);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(114, 23);
            dateTimePicker3.TabIndex = 19;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "In-Person", "Virtual" });
            comboBox1.Location = new Point(107, 149);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 23);
            comboBox1.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 197);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 21;
            label5.Text = "Located in";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 226);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 22;
            label6.Text = "Accessed at";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(80, 194);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(260, 23);
            comboBox2.TabIndex = 23;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(87, 223);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Virtual Meeting URL";
            textBox3.Size = new Size(253, 23);
            textBox3.TabIndex = 24;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 303);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(328, 135);
            richTextBox1.TabIndex = 26;
            richTextBox1.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 285);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 27;
            label7.Text = "Appointment details";
            // 
            // Appointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 450);
            Controls.Add(label7);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(comboBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker3);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCustomerForm);
            Controls.Add(cmbCustomer);
            Name = "Appointment";
            Text = "Appointment";
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
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private ComboBox comboBox2;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
        private Label label7;
    }
}