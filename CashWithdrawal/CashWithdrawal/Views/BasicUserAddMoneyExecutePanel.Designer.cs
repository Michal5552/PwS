
namespace CashWithdrawal.Views
{
    partial class BasicUserAddMoneyExecutePanel
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
            this.BasicUserAddMoneyExecutePanelPanel = new System.Windows.Forms.Panel();
            this.ExitToBasicUserAddMoneyPanel = new System.Windows.Forms.Button();
            this.AddMoneyResultLabel = new System.Windows.Forms.Label();
            this.BasicUserAddMoneyExecutePanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicUserAddMoneyExecutePanelPanel
            // 
            this.BasicUserAddMoneyExecutePanelPanel.Controls.Add(this.ExitToBasicUserAddMoneyPanel);
            this.BasicUserAddMoneyExecutePanelPanel.Controls.Add(this.AddMoneyResultLabel);
            this.BasicUserAddMoneyExecutePanelPanel.Location = new System.Drawing.Point(34, 25);
            this.BasicUserAddMoneyExecutePanelPanel.Name = "BasicUserAddMoneyExecutePanelPanel";
            this.BasicUserAddMoneyExecutePanelPanel.Size = new System.Drawing.Size(468, 260);
            this.BasicUserAddMoneyExecutePanelPanel.TabIndex = 0;
            // 
            // ExitToBasicUserAddMoneyPanel
            // 
            this.ExitToBasicUserAddMoneyPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToBasicUserAddMoneyPanel.Location = new System.Drawing.Point(135, 153);
            this.ExitToBasicUserAddMoneyPanel.Name = "ExitToBasicUserAddMoneyPanel";
            this.ExitToBasicUserAddMoneyPanel.Size = new System.Drawing.Size(220, 81);
            this.ExitToBasicUserAddMoneyPanel.TabIndex = 8;
            this.ExitToBasicUserAddMoneyPanel.Text = "Powrót Do \r\nPanelu Wpłaty";
            this.ExitToBasicUserAddMoneyPanel.UseVisualStyleBackColor = true;
            this.ExitToBasicUserAddMoneyPanel.Click += new System.EventHandler(this.ExitToBasicUserAddMoneyPanel_Click);
            // 
            // AddMoneyResultLabel
            // 
            this.AddMoneyResultLabel.AutoSize = true;
            this.AddMoneyResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddMoneyResultLabel.Location = new System.Drawing.Point(62, 31);
            this.AddMoneyResultLabel.Name = "AddMoneyResultLabel";
            this.AddMoneyResultLabel.Size = new System.Drawing.Size(229, 32);
            this.AddMoneyResultLabel.TabIndex = 0;
            this.AddMoneyResultLabel.Text = "Wynik Transakcji";
            this.AddMoneyResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BasicUserAddMoneyExecutePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 313);
            this.Controls.Add(this.BasicUserAddMoneyExecutePanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BasicUserAddMoneyExecutePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Potwierdzenia Transakcji";
            this.BasicUserAddMoneyExecutePanelPanel.ResumeLayout(false);
            this.BasicUserAddMoneyExecutePanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasicUserAddMoneyExecutePanelPanel;
        private System.Windows.Forms.Label AddMoneyResultLabel;
        private System.Windows.Forms.Button ExitToBasicUserAddMoneyPanel;
    }
}