
namespace CashWithdrawal
{
	partial class Basic_user_operation_window
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
			this.label1 = new System.Windows.Forms.Label();
			this.Withdraw_button = new System.Windows.Forms.Button();
			this.Deposit_button = new System.Windows.Forms.Button();
			this.Account_balance_button = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(286, 126);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose operation";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// Withdraw_button
			// 
			this.Withdraw_button.Location = new System.Drawing.Point(477, 238);
			this.Withdraw_button.Name = "Withdraw_button";
			this.Withdraw_button.Size = new System.Drawing.Size(75, 23);
			this.Withdraw_button.TabIndex = 1;
			this.Withdraw_button.Text = "Withdraw";
			this.Withdraw_button.UseVisualStyleBackColor = true;
			this.Withdraw_button.Click += new System.EventHandler(this.Withdraw_button_Click);
			// 
			// Deposit_button
			// 
			this.Deposit_button.Location = new System.Drawing.Point(211, 238);
			this.Deposit_button.Name = "Deposit_button";
			this.Deposit_button.Size = new System.Drawing.Size(75, 23);
			this.Deposit_button.TabIndex = 2;
			this.Deposit_button.Text = "Deposit";
			this.Deposit_button.UseVisualStyleBackColor = true;
			this.Deposit_button.Click += new System.EventHandler(this.Deposit_button_Click);
			// 
			// Account_balance_button
			// 
			this.Account_balance_button.Location = new System.Drawing.Point(329, 238);
			this.Account_balance_button.Name = "Account_balance_button";
			this.Account_balance_button.Size = new System.Drawing.Size(110, 23);
			this.Account_balance_button.TabIndex = 3;
			this.Account_balance_button.Text = "Account balance";
			this.Account_balance_button.UseVisualStyleBackColor = true;
			this.Account_balance_button.Click += new System.EventHandler(this.Account_balance_button_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(329, 280);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(110, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Log out";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// Basic_user_operation_window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.Account_balance_button);
			this.Controls.Add(this.Deposit_button);
			this.Controls.Add(this.Withdraw_button);
			this.Controls.Add(this.label1);
			this.Name = "Basic_user_operation_window";
			this.Text = "Welcome screen";
			this.Load += new System.EventHandler(this.operation_window_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Withdraw_button;
		private System.Windows.Forms.Button Deposit_button;
		private System.Windows.Forms.Button Account_balance_button;
		private System.Windows.Forms.Button button4;
	}
}

