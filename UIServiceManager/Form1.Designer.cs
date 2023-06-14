namespace UIServiceManager
{
    partial class Form1
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
            this.carModelInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.surnameInput = new System.Windows.Forms.TextBox();
            this.carMarkInput = new System.Windows.Forms.TextBox();
            this.AddClientbt = new System.Windows.Forms.Button();
            this.showAllBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Searchbt = new System.Windows.Forms.Button();
            this.OdometerInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.searchSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // carModelInput
            // 
            this.carModelInput.Location = new System.Drawing.Point(166, 120);
            this.carModelInput.Name = "carModelInput";
            this.carModelInput.Size = new System.Drawing.Size(123, 20);
            this.carModelInput.TabIndex = 1;
            this.carModelInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(12, 57);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(121, 20);
            this.nameInput.TabIndex = 2;
            this.nameInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // surnameInput
            // 
            this.surnameInput.Location = new System.Drawing.Point(166, 57);
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.Size = new System.Drawing.Size(124, 20);
            this.surnameInput.TabIndex = 3;
            this.surnameInput.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // carMarkInput
            // 
            this.carMarkInput.Location = new System.Drawing.Point(12, 120);
            this.carMarkInput.Name = "carMarkInput";
            this.carMarkInput.Size = new System.Drawing.Size(122, 20);
            this.carMarkInput.TabIndex = 4;
            this.carMarkInput.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // AddClientbt
            // 
            this.AddClientbt.Location = new System.Drawing.Point(12, 233);
            this.AddClientbt.Name = "AddClientbt";
            this.AddClientbt.Size = new System.Drawing.Size(119, 26);
            this.AddClientbt.TabIndex = 5;
            this.AddClientbt.Text = "Add Client";
            this.AddClientbt.UseVisualStyleBackColor = true;
            this.AddClientbt.Click += new System.EventHandler(this.button1_Click);
            // 
            // showAllBt
            // 
            this.showAllBt.Location = new System.Drawing.Point(12, 397);
            this.showAllBt.Name = "showAllBt";
            this.showAllBt.Size = new System.Drawing.Size(119, 26);
            this.showAllBt.TabIndex = 6;
            this.showAllBt.Text = "Show All";
            this.showAllBt.UseVisualStyleBackColor = true;
            this.showAllBt.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Client Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGreen;
            this.label2.Location = new System.Drawing.Point(168, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Car Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleGreen;
            this.label4.Location = new System.Drawing.Point(168, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Client Surname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGreen;
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Car Mark";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleGreen;
            this.label6.Location = new System.Drawing.Point(13, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Search By";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Searchbt
            // 
            this.Searchbt.Location = new System.Drawing.Point(12, 340);
            this.Searchbt.Name = "Searchbt";
            this.Searchbt.Size = new System.Drawing.Size(119, 26);
            this.Searchbt.TabIndex = 20;
            this.Searchbt.Text = "Search";
            this.Searchbt.UseVisualStyleBackColor = true;
            this.Searchbt.Click += new System.EventHandler(this.button3_Click);
            // 
            // OdometerInput
            // 
            this.OdometerInput.Location = new System.Drawing.Point(12, 185);
            this.OdometerInput.Name = "OdometerInput";
            this.OdometerInput.Size = new System.Drawing.Size(121, 20);
            this.OdometerInput.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.PaleGreen;
            this.label10.Location = new System.Drawing.Point(9, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Car Odometer";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(205, 302);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 12;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // searchSelect
            // 
            this.searchSelect.DisplayMember = "Search by Name";
            this.searchSelect.FormattingEnabled = true;
            this.searchSelect.Items.AddRange(new object[] {
            "Name",
            "Surname",
            "Mark",
            "Model"});
            this.searchSelect.Location = new System.Drawing.Point(75, 301);
            this.searchSelect.MaxDropDownItems = 4;
            this.searchSelect.Name = "searchSelect";
            this.searchSelect.Size = new System.Drawing.Size(124, 21);
            this.searchSelect.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 542);
            this.Controls.Add(this.searchSelect);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.OdometerInput);
            this.Controls.Add(this.Searchbt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showAllBt);
            this.Controls.Add(this.AddClientbt);
            this.Controls.Add(this.carMarkInput);
            this.Controls.Add(this.surnameInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.carModelInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox carModelInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox surnameInput;
        private System.Windows.Forms.TextBox carMarkInput;
        private System.Windows.Forms.Button AddClientbt;
        private System.Windows.Forms.Button showAllBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Searchbt;
        private System.Windows.Forms.TextBox OdometerInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox searchSelect;
    }
}

