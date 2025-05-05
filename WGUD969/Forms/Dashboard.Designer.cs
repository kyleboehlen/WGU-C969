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
            lsvCustomers = new ListView();
            label1 = new Label();
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
            tbpCustomers.Controls.Add(label1);
            tbpCustomers.Controls.Add(lsvCustomers);
            tbpCustomers.Location = new Point(4, 24);
            tbpCustomers.Name = "tbpCustomers";
            tbpCustomers.Padding = new Padding(3);
            tbpCustomers.Size = new Size(722, 246);
            tbpCustomers.TabIndex = 1;
            tbpCustomers.Text = "Customers";
            tbpCustomers.UseVisualStyleBackColor = true;
            // 
            // lsvCustomers
            // 
            lsvCustomers.Location = new Point(268, 6);
            lsvCustomers.Name = "lsvCustomers";
            lsvCustomers.Size = new Size(448, 234);
            lsvCustomers.TabIndex = 0;
            lsvCustomers.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 110);
            label1.Name = "label1";
            label1.Size = new Size(249, 21);
            label1.TabIndex = 1;
            label1.Text = "TODO: Customer add/update form";
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
        private Label label1;
    }
}