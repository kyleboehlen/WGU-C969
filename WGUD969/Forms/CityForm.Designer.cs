namespace WGUD969.Forms
{
    partial class CityForm
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
            txtCountry = new TextBox();
            txtCity = new TextBox();
            lblAddCity = new Label();
            btnCityCancel = new Button();
            btnCitySave = new Button();
            SuspendLayout();
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(12, 56);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Country";
            txtCountry.Size = new Size(175, 23);
            txtCountry.TabIndex = 2;
            txtCountry.TextChanged += OnTextBoxValueChange;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(12, 27);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City";
            txtCity.Size = new Size(175, 23);
            txtCity.TabIndex = 1;
            txtCity.TextChanged += OnTextBoxValueChange;
            // 
            // lblAddCity
            // 
            lblAddCity.AutoSize = true;
            lblAddCity.Location = new Point(12, 9);
            lblAddCity.Name = "lblAddCity";
            lblAddCity.Size = new Size(53, 15);
            lblAddCity.TabIndex = 7;
            lblAddCity.Text = "Add City";
            // 
            // btnCityCancel
            // 
            btnCityCancel.Location = new Point(111, 85);
            btnCityCancel.Name = "btnCityCancel";
            btnCityCancel.Size = new Size(75, 23);
            btnCityCancel.TabIndex = 4;
            btnCityCancel.Text = "Cancel";
            btnCityCancel.UseVisualStyleBackColor = true;
            // 
            // btnCitySave
            // 
            btnCitySave.Location = new Point(30, 85);
            btnCitySave.Name = "btnCitySave";
            btnCitySave.Size = new Size(75, 23);
            btnCitySave.TabIndex = 3;
            btnCitySave.Text = "Save";
            btnCitySave.UseVisualStyleBackColor = true;
            btnCitySave.Click += btnCitySave_Click;
            // 
            // CityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(198, 119);
            Controls.Add(btnCityCancel);
            Controls.Add(btnCitySave);
            Controls.Add(txtCountry);
            Controls.Add(txtCity);
            Controls.Add(lblAddCity);
            Name = "CityForm";
            Text = "City";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCountry;
        private TextBox txtCity;
        private Label lblAddCity;
        private Button btnCityCancel;
        private Button btnCitySave;
    }
}