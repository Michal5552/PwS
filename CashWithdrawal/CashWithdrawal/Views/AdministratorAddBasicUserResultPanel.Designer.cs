
namespace CashWithdrawal.Views
{
    partial class AdministratorAddBasicUserResultPanel
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
            this.AdministratorAddBasicUserResultPanelPanel = new System.Windows.Forms.Panel();
            this.AddBasicUserResultLabel = new System.Windows.Forms.Label();
            this.ExitToAdministratorManageBasicUsersButton = new System.Windows.Forms.Button();
            this.AdministratorAddBasicUserResultPanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdministratorAddBasicUserResultPanelPanel
            // 
            this.AdministratorAddBasicUserResultPanelPanel.Controls.Add(this.AddBasicUserResultLabel);
            this.AdministratorAddBasicUserResultPanelPanel.Controls.Add(this.ExitToAdministratorManageBasicUsersButton);
            this.AdministratorAddBasicUserResultPanelPanel.Location = new System.Drawing.Point(100, 47);
            this.AdministratorAddBasicUserResultPanelPanel.Name = "AdministratorAddBasicUserResultPanelPanel";
            this.AdministratorAddBasicUserResultPanelPanel.Size = new System.Drawing.Size(449, 332);
            this.AdministratorAddBasicUserResultPanelPanel.TabIndex = 0;
            // 
            // AddBasicUserResultLabel
            // 
            this.AddBasicUserResultLabel.AutoSize = true;
            this.AddBasicUserResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddBasicUserResultLabel.Location = new System.Drawing.Point(49, 29);
            this.AddBasicUserResultLabel.Name = "AddBasicUserResultLabel";
            this.AddBasicUserResultLabel.Size = new System.Drawing.Size(372, 64);
            this.AddBasicUserResultLabel.TabIndex = 12;
            this.AddBasicUserResultLabel.Text = "Użytkownik Został Dodany\r\n Do Bazy Danych";
            this.AddBasicUserResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitToAdministratorManageBasicUsersButton
            // 
            this.ExitToAdministratorManageBasicUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToAdministratorManageBasicUsersButton.Location = new System.Drawing.Point(119, 189);
            this.ExitToAdministratorManageBasicUsersButton.Name = "ExitToAdministratorManageBasicUsersButton";
            this.ExitToAdministratorManageBasicUsersButton.Size = new System.Drawing.Size(233, 118);
            this.ExitToAdministratorManageBasicUsersButton.TabIndex = 11;
            this.ExitToAdministratorManageBasicUsersButton.Text = "Powrót Do Panelu Zarządzania Użytkownikami";
            this.ExitToAdministratorManageBasicUsersButton.UseVisualStyleBackColor = true;
            this.ExitToAdministratorManageBasicUsersButton.Click += new System.EventHandler(this.ExitToAdministratorManageBasicUsersButton_Click);
            // 
            // AdministratorAddBasicUserResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 453);
            this.Controls.Add(this.AdministratorAddBasicUserResultPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorAddBasicUserResultPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Rezultatu Dodania Użytkownika";
            this.AdministratorAddBasicUserResultPanelPanel.ResumeLayout(false);
            this.AdministratorAddBasicUserResultPanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdministratorAddBasicUserResultPanelPanel;
        private System.Windows.Forms.Label AddBasicUserResultLabel;
        private System.Windows.Forms.Button ExitToAdministratorManageBasicUsersButton;
    }
}