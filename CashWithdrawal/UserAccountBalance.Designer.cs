
namespace CashWithdrawal
{
	partial class Balance_window
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PLN_rb = new System.Windows.Forms.RadioButton();
			this.GBP_rb = new System.Windows.Forms.RadioButton();
			this.EUR_rb = new System.Windows.Forms.RadioButton();
			this.USD_rb = new System.Windows.Forms.RadioButton();
			this.Balance_amount_label = new System.Windows.Forms.Label();
			this.balance_label = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Print_balance_button = new System.Windows.Forms.Button();
			this.Back_button = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.Balance_amount_label);
			this.panel1.Controls.Add(this.balance_label);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Print_balance_button);
			this.panel1.Controls.Add(this.Back_button);
			this.panel1.Location = new System.Drawing.Point(100, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 400);
			this.panel1.TabIndex = 8;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PLN_rb);
			this.groupBox1.Controls.Add(this.GBP_rb);
			this.groupBox1.Controls.Add(this.EUR_rb);
			this.groupBox1.Controls.Add(this.USD_rb);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(193, 46);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 48);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			// 
			// PLN_rb
			// 
			this.PLN_rb.AutoSize = true;
			this.PLN_rb.Location = new System.Drawing.Point(6, 19);
			this.PLN_rb.Name = "PLN_rb";
			this.PLN_rb.Size = new System.Drawing.Size(46, 17);
			this.PLN_rb.TabIndex = 9;
			this.PLN_rb.TabStop = true;
			this.PLN_rb.Text = "PLN";
			this.PLN_rb.UseVisualStyleBackColor = true;
			this.PLN_rb.CheckedChanged += new System.EventHandler(this.PLN_rb_CheckedChanged);
			// 
			// GBP_rb
			// 
			this.GBP_rb.AutoSize = true;
			this.GBP_rb.Location = new System.Drawing.Point(153, 19);
			this.GBP_rb.Name = "GBP_rb";
			this.GBP_rb.Size = new System.Drawing.Size(47, 17);
			this.GBP_rb.TabIndex = 12;
			this.GBP_rb.TabStop = true;
			this.GBP_rb.Text = "GBP";
			this.GBP_rb.UseVisualStyleBackColor = true;
			this.GBP_rb.CheckedChanged += new System.EventHandler(this.GBP_rb_CheckedChanged);
			// 
			// EUR_rb
			// 
			this.EUR_rb.AutoSize = true;
			this.EUR_rb.Location = new System.Drawing.Point(53, 19);
			this.EUR_rb.Name = "EUR_rb";
			this.EUR_rb.Size = new System.Drawing.Size(48, 17);
			this.EUR_rb.TabIndex = 10;
			this.EUR_rb.TabStop = true;
			this.EUR_rb.Text = "EUR";
			this.EUR_rb.UseVisualStyleBackColor = true;
			this.EUR_rb.CheckedChanged += new System.EventHandler(this.EUR_rb_CheckedChanged);
			// 
			// USD_rb
			// 
			this.USD_rb.AutoSize = true;
			this.USD_rb.Location = new System.Drawing.Point(107, 19);
			this.USD_rb.Name = "USD_rb";
			this.USD_rb.Size = new System.Drawing.Size(48, 17);
			this.USD_rb.TabIndex = 11;
			this.USD_rb.TabStop = true;
			this.USD_rb.Text = "USD";
			this.USD_rb.UseVisualStyleBackColor = true;
			this.USD_rb.CheckedChanged += new System.EventHandler(this.USD_rb_CheckedChanged);
			// 
			// Balance_amount_label
			// 
			this.Balance_amount_label.AutoSize = true;
			this.Balance_amount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Balance_amount_label.Location = new System.Drawing.Point(355, 190);
			this.Balance_amount_label.Name = "Balance_amount_label";
			this.Balance_amount_label.Size = new System.Drawing.Size(117, 33);
			this.Balance_amount_label.TabIndex = 8;
			this.Balance_amount_label.Text = "50 PLN";
			// 
			// balance_label
			// 
			this.balance_label.AutoSize = true;
			this.balance_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.balance_label.Location = new System.Drawing.Point(84, 190);
			this.balance_label.Name = "balance_label";
			this.balance_label.Size = new System.Drawing.Size(230, 33);
			this.balance_label.TabIndex = 7;
			this.balance_label.Text = "Account balance";
			this.balance_label.Click += new System.EventHandler(this.label3_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(259, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Currency";
			// 
			// Print_balance_button
			// 
			this.Print_balance_button.Location = new System.Drawing.Point(350, 332);
			this.Print_balance_button.Name = "Print_balance_button";
			this.Print_balance_button.Size = new System.Drawing.Size(100, 23);
			this.Print_balance_button.TabIndex = 5;
			this.Print_balance_button.Text = "Print balance";
			this.Print_balance_button.UseVisualStyleBackColor = true;
			// 
			// Back_button
			// 
			this.Back_button.Location = new System.Drawing.Point(150, 332);
			this.Back_button.Name = "Back_button";
			this.Back_button.Size = new System.Drawing.Size(100, 23);
			this.Back_button.TabIndex = 4;
			this.Back_button.Text = "Back";
			this.Back_button.UseVisualStyleBackColor = true;
			// 
			// Balance_window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Name = "Balance_window";
			this.Text = "Account balance";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label Balance_amount_label;
		private System.Windows.Forms.Label balance_label;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Print_balance_button;
		private System.Windows.Forms.Button Back_button;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton PLN_rb;
		private System.Windows.Forms.RadioButton GBP_rb;
		private System.Windows.Forms.RadioButton EUR_rb;
		private System.Windows.Forms.RadioButton USD_rb;
	}
}