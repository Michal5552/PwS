
namespace CashWithdrawal.Views
{
    partial class AdministratorChangeCashDispenserStateResultPanel
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
            this.ExitToAdministratorPanel = new System.Windows.Forms.Button();
            this.ChangeCashDispenserStateResultLabel = new System.Windows.Forms.Label();
            this.BasicUserAddMoneyExecutePanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicUserAddMoneyExecutePanelPanel
            // 
            this.BasicUserAddMoneyExecutePanelPanel.Controls.Add(this.ExitToAdministratorPanel);
            this.BasicUserAddMoneyExecutePanelPanel.Controls.Add(this.ChangeCashDispenserStateResultLabel);
            this.BasicUserAddMoneyExecutePanelPanel.Location = new System.Drawing.Point(109, 44);
            this.BasicUserAddMoneyExecutePanelPanel.Name = "BasicUserAddMoneyExecutePanelPanel";
            this.BasicUserAddMoneyExecutePanelPanel.Size = new System.Drawing.Size(468, 260);
            this.BasicUserAddMoneyExecutePanelPanel.TabIndex = 1;
            // 
            // ExitToAdministratorPanel
            // 
            this.ExitToAdministratorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToAdministratorPanel.Location = new System.Drawing.Point(108, 136);
            this.ExitToAdministratorPanel.Name = "ExitToAdministratorPanel";
            this.ExitToAdministratorPanel.Size = new System.Drawing.Size(250, 104);
            this.ExitToAdministratorPanel.TabIndex = 8;
            this.ExitToAdministratorPanel.Text = "Powrót Do Panelu Zmiany Stanu Bankomatu";
            this.ExitToAdministratorPanel.UseVisualStyleBackColor = true;
            this.ExitToAdministratorPanel.Click += new System.EventHandler(this.ExitToAdministratorPanel_Click);
            // 
            // ChangeCashDispenserStateResultLabel
            // 
            this.ChangeCashDispenserStateResultLabel.AutoSize = true;
            this.ChangeCashDispenserStateResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChangeCashDispenserStateResultLabel.Location = new System.Drawing.Point(71, 36);
            this.ChangeCashDispenserStateResultLabel.Name = "ChangeCashDispenserStateResultLabel";
            this.ChangeCashDispenserStateResultLabel.Size = new System.Drawing.Size(350, 64);
            this.ChangeCashDispenserStateResultLabel.TabIndex = 0;
            this.ChangeCashDispenserStateResultLabel.Text = "Zmiana Stanu Bankomatu \r\nZakończona Pomyślnie";
            this.ChangeCashDispenserStateResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdministratorChangeCashDispenserStateResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 352);
            this.Controls.Add(this.BasicUserAddMoneyExecutePanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorChangeCashDispenserStateResultPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Rezultatu Zmiany Stanu Bankomatu";
            this.BasicUserAddMoneyExecutePanelPanel.ResumeLayout(false);
            this.BasicUserAddMoneyExecutePanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasicUserAddMoneyExecutePanelPanel;
        private System.Windows.Forms.Button ExitToAdministratorPanel;
        private System.Windows.Forms.Label ChangeCashDispenserStateResultLabel;
    }
}