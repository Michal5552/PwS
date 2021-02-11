
namespace CashWithdrawal.Views
{
    partial class BasicUserAccountStateReportPanel
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
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateValueLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AccountStateReportLabel = new System.Windows.Forms.Label();
            this.ExitToBasicUserAccountStatePanel = new System.Windows.Forms.Button();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.CurrencyValueLabel = new System.Windows.Forms.Label();
            this.AccountStateLabel = new System.Windows.Forms.Label();
            this.AccountStateValueLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateLabel.Location = new System.Drawing.Point(28, 99);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(165, 29);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Data Raportu :";
            // 
            // DateValueLabel
            // 
            this.DateValueLabel.AutoSize = true;
            this.DateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateValueLabel.Location = new System.Drawing.Point(199, 99);
            this.DateValueLabel.Name = "DateValueLabel";
            this.DateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.DateValueLabel.TabIndex = 1;
            this.DateValueLabel.Text = "Wartość";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AccountStateReportLabel);
            this.panel1.Controls.Add(this.ExitToBasicUserAccountStatePanel);
            this.panel1.Controls.Add(this.CurrencyLabel);
            this.panel1.Controls.Add(this.CurrencyValueLabel);
            this.panel1.Controls.Add(this.AccountStateLabel);
            this.panel1.Controls.Add(this.AccountStateValueLabel);
            this.panel1.Controls.Add(this.DateLabel);
            this.panel1.Controls.Add(this.DateValueLabel);
            this.panel1.Location = new System.Drawing.Point(242, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 410);
            this.panel1.TabIndex = 2;
            // 
            // AccountStateReportLabel
            // 
            this.AccountStateReportLabel.AutoSize = true;
            this.AccountStateReportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AccountStateReportLabel.Location = new System.Drawing.Point(26, 30);
            this.AccountStateReportLabel.Name = "AccountStateReportLabel";
            this.AccountStateReportLabel.Size = new System.Drawing.Size(317, 37);
            this.AccountStateReportLabel.TabIndex = 8;
            this.AccountStateReportLabel.Text = "Raport Stanu Konta";
            // 
            // ExitToBasicUserAccountStatePanel
            // 
            this.ExitToBasicUserAccountStatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToBasicUserAccountStatePanel.Location = new System.Drawing.Point(79, 310);
            this.ExitToBasicUserAccountStatePanel.Name = "ExitToBasicUserAccountStatePanel";
            this.ExitToBasicUserAccountStatePanel.Size = new System.Drawing.Size(220, 81);
            this.ExitToBasicUserAccountStatePanel.TabIndex = 7;
            this.ExitToBasicUserAccountStatePanel.Text = "Powrót Do Panelu Stanu Konta";
            this.ExitToBasicUserAccountStatePanel.UseVisualStyleBackColor = true;
            this.ExitToBasicUserAccountStatePanel.Click += new System.EventHandler(this.ExitToBasicUserAccountStatePanel_Click);
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.AutoSize = true;
            this.CurrencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CurrencyLabel.Location = new System.Drawing.Point(99, 137);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(98, 29);
            this.CurrencyLabel.TabIndex = 4;
            this.CurrencyLabel.Text = "Waluta :";
            // 
            // CurrencyValueLabel
            // 
            this.CurrencyValueLabel.AutoSize = true;
            this.CurrencyValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CurrencyValueLabel.Location = new System.Drawing.Point(199, 137);
            this.CurrencyValueLabel.Name = "CurrencyValueLabel";
            this.CurrencyValueLabel.Size = new System.Drawing.Size(100, 29);
            this.CurrencyValueLabel.TabIndex = 5;
            this.CurrencyValueLabel.Text = "Wartość";
            // 
            // AccountStateLabel
            // 
            this.AccountStateLabel.AutoSize = true;
            this.AccountStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AccountStateLabel.Location = new System.Drawing.Point(54, 178);
            this.AccountStateLabel.Name = "AccountStateLabel";
            this.AccountStateLabel.Size = new System.Drawing.Size(141, 29);
            this.AccountStateLabel.TabIndex = 2;
            this.AccountStateLabel.Text = "Stan Konta :";
            // 
            // AccountStateValueLabel
            // 
            this.AccountStateValueLabel.AutoSize = true;
            this.AccountStateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AccountStateValueLabel.Location = new System.Drawing.Point(199, 178);
            this.AccountStateValueLabel.Name = "AccountStateValueLabel";
            this.AccountStateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.AccountStateValueLabel.TabIndex = 3;
            this.AccountStateValueLabel.Text = "Wartość";
            // 
            // BasicUserAccountStateReportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BasicUserAccountStateReportPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Raportu Stanu Konta";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label DateValueLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CurrencyLabel;
        private System.Windows.Forms.Label CurrencyValueLabel;
        private System.Windows.Forms.Label AccountStateLabel;
        private System.Windows.Forms.Label AccountStateValueLabel;
        private System.Windows.Forms.Button ExitToBasicUserAccountStatePanel;
        private System.Windows.Forms.Label AccountStateReportLabel;
    }
}