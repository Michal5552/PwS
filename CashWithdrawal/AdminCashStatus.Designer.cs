
namespace CashWithdrawal
{
	partial class admin_cash_status
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
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.currencyBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nominal,
            this.amount});
			this.dataGridView1.Location = new System.Drawing.Point(424, 125);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(240, 150);
			this.dataGridView1.TabIndex = 0;
			// 
			// nominal
			// 
			this.nominal.HeaderText = "Nominal";
			this.nominal.Name = "nominal";
			// 
			// amount
			// 
			this.amount.HeaderText = "Amount";
			this.amount.Name = "amount";
			// 
			// currencyBox
			// 
			this.currencyBox.FormattingEnabled = true;
			this.currencyBox.Items.AddRange(new object[] {
            "PLN",
            "USD",
            "GBP",
            "EUR"});
			this.currencyBox.Location = new System.Drawing.Point(122, 157);
			this.currencyBox.Name = "currencyBox";
			this.currencyBox.Size = new System.Drawing.Size(121, 21);
			this.currencyBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(109, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Choose currency";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(443, 302);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Withdraw";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(565, 302);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Deposit";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// admin_cash_status
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.currencyBox);
			this.Controls.Add(this.dataGridView1);
			this.Name = "admin_cash_status";
			this.Text = "Cash Status";
			this.Load += new System.EventHandler(this.Form8_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
		private System.Windows.Forms.DataGridViewTextBoxColumn amount;
		private System.Windows.Forms.ComboBox currencyBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}