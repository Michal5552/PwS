
namespace CashWithdrawal.Views
{
    partial class BasicUserTakeOutMoneyExecutePanel
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
            this.BasicUserTakeOutMoneyExecutePanelPanel = new System.Windows.Forms.Panel();
            this.ExitToBasicUserTakeOutMoneyPanel = new System.Windows.Forms.Button();
            this.TakeOutMoneyResultLabel = new System.Windows.Forms.Label();
            this.BasicUserTakeOutMoneyExecutePanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicUserTakeOutMoneyExecutePanelPanel
            // 
            this.BasicUserTakeOutMoneyExecutePanelPanel.Controls.Add(this.ExitToBasicUserTakeOutMoneyPanel);
            this.BasicUserTakeOutMoneyExecutePanelPanel.Controls.Add(this.TakeOutMoneyResultLabel);
            this.BasicUserTakeOutMoneyExecutePanelPanel.Location = new System.Drawing.Point(30, 95);
            this.BasicUserTakeOutMoneyExecutePanelPanel.Name = "BasicUserTakeOutMoneyExecutePanelPanel";
            this.BasicUserTakeOutMoneyExecutePanelPanel.Size = new System.Drawing.Size(758, 260);
            this.BasicUserTakeOutMoneyExecutePanelPanel.TabIndex = 1;
            // 
            // ExitToBasicUserTakeOutMoneyPanel
            // 
            this.ExitToBasicUserTakeOutMoneyPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToBasicUserTakeOutMoneyPanel.Location = new System.Drawing.Point(280, 150);
            this.ExitToBasicUserTakeOutMoneyPanel.Name = "ExitToBasicUserTakeOutMoneyPanel";
            this.ExitToBasicUserTakeOutMoneyPanel.Size = new System.Drawing.Size(220, 81);
            this.ExitToBasicUserTakeOutMoneyPanel.TabIndex = 8;
            this.ExitToBasicUserTakeOutMoneyPanel.Text = "Powrót Do \r\nPanelu Wypłaty";
            this.ExitToBasicUserTakeOutMoneyPanel.UseVisualStyleBackColor = true;
            this.ExitToBasicUserTakeOutMoneyPanel.Click += new System.EventHandler(this.ExitToBasicUserAddMoneyPanel_Click);
            // 
            // TakeOutMoneyResultLabel
            // 
            this.TakeOutMoneyResultLabel.AutoSize = true;
            this.TakeOutMoneyResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakeOutMoneyResultLabel.Location = new System.Drawing.Point(62, 31);
            this.TakeOutMoneyResultLabel.Name = "TakeOutMoneyResultLabel";
            this.TakeOutMoneyResultLabel.Size = new System.Drawing.Size(229, 32);
            this.TakeOutMoneyResultLabel.TabIndex = 0;
            this.TakeOutMoneyResultLabel.Text = "Wynik Transakcji";
            this.TakeOutMoneyResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BasicUserTakeOutMoneyExecutePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 391);
            this.Controls.Add(this.BasicUserTakeOutMoneyExecutePanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BasicUserTakeOutMoneyExecutePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Potwierdzenia Transakcji";
            this.BasicUserTakeOutMoneyExecutePanelPanel.ResumeLayout(false);
            this.BasicUserTakeOutMoneyExecutePanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasicUserTakeOutMoneyExecutePanelPanel;
        private System.Windows.Forms.Button ExitToBasicUserTakeOutMoneyPanel;
        private System.Windows.Forms.Label TakeOutMoneyResultLabel;
    }
}