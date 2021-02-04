
namespace CashWithdrawal
{
	partial class Login_window
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
			this.error_label = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.clear_button = new System.Windows.Forms.Button();
			this.accept_button = new System.Windows.Forms.Button();
			this.pin_text = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.error_label);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.clear_button);
			this.panel1.Controls.Add(this.accept_button);
			this.panel1.Controls.Add(this.pin_text);
			this.panel1.Controls.Add(this.label2);
			this.panel1.ForeColor = System.Drawing.Color.Black;
			this.panel1.Location = new System.Drawing.Point(100, 100);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 250);
			this.panel1.TabIndex = 5;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// error_label
			// 
			this.error_label.AutoSize = true;
			this.error_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.error_label.ForeColor = System.Drawing.Color.Red;
			this.error_label.Location = new System.Drawing.Point(236, 206);
			this.error_label.Name = "error_label";
			this.error_label.Size = new System.Drawing.Size(120, 20);
			this.error_label.TabIndex = 7;
			this.error_label.Text = "Wrong pincode!";
			this.error_label.Click += new System.EventHandler(this.error_label_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(258, 206);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 6;
			// 
			// clear_button
			// 
			this.clear_button.Location = new System.Drawing.Point(141, 164);
			this.clear_button.Name = "clear_button";
			this.clear_button.Size = new System.Drawing.Size(75, 23);
			this.clear_button.TabIndex = 6;
			this.clear_button.Text = "Clear";
			this.clear_button.UseVisualStyleBackColor = true;
			// 
			// accept_button
			// 
			this.accept_button.Location = new System.Drawing.Point(365, 164);
			this.accept_button.Name = "accept_button";
			this.accept_button.Size = new System.Drawing.Size(75, 23);
			this.accept_button.TabIndex = 5;
			this.accept_button.Text = "Accept";
			this.accept_button.UseVisualStyleBackColor = true;
			this.accept_button.Click += new System.EventHandler(this.button2_Click);
			// 
			// pin_text
			// 
			this.pin_text.Location = new System.Drawing.Point(240, 112);
			this.pin_text.MaxLength = 6;
			this.pin_text.Name = "pin_text";
			this.pin_text.PasswordChar = '*';
			this.pin_text.Size = new System.Drawing.Size(100, 20);
			this.pin_text.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(247, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pin code";
			// 
			// Login_window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Name = "Login_window";
			this.Text = "Login credentials";
			this.Load += new System.EventHandler(this.Login_window_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button clear_button;
		private System.Windows.Forms.Button accept_button;
		private System.Windows.Forms.TextBox pin_text;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label error_label;
	}
}