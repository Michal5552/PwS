
namespace CashWithdrawal.Views
{
    partial class AdministratorUpdateBasicUserResultPanel
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
            this.UpdateBasicUserResultLabel = new System.Windows.Forms.Label();
            this.ExitToAdministratorManageBasicUsersButton = new System.Windows.Forms.Button();
            this.AdministratorAddBasicUserResultPanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdministratorAddBasicUserResultPanelPanel
            // 
            this.AdministratorAddBasicUserResultPanelPanel.Controls.Add(this.UpdateBasicUserResultLabel);
            this.AdministratorAddBasicUserResultPanelPanel.Controls.Add(this.ExitToAdministratorManageBasicUsersButton);
            this.AdministratorAddBasicUserResultPanelPanel.Location = new System.Drawing.Point(80, 41);
            this.AdministratorAddBasicUserResultPanelPanel.Name = "AdministratorAddBasicUserResultPanelPanel";
            this.AdministratorAddBasicUserResultPanelPanel.Size = new System.Drawing.Size(449, 332);
            this.AdministratorAddBasicUserResultPanelPanel.TabIndex = 1;
            // 
            // UpdateBasicUserResultLabel
            // 
            this.UpdateBasicUserResultLabel.AutoSize = true;
            this.UpdateBasicUserResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpdateBasicUserResultLabel.Location = new System.Drawing.Point(49, 29);
            this.UpdateBasicUserResultLabel.Name = "UpdateBasicUserResultLabel";
            this.UpdateBasicUserResultLabel.Size = new System.Drawing.Size(373, 64);
            this.UpdateBasicUserResultLabel.TabIndex = 12;
            this.UpdateBasicUserResultLabel.Text = "Dane użytkownika zostały \r\nzaktualizowane pomyślnie";
            this.UpdateBasicUserResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitToAdministratorManageBasicUsersButton
            // 
            this.ExitToAdministratorManageBasicUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToAdministratorManageBasicUsersButton.Location = new System.Drawing.Point(119, 189);
            this.ExitToAdministratorManageBasicUsersButton.Name = "ExitToAdministratorManageBasicUsersButton";
            this.ExitToAdministratorManageBasicUsersButton.Size = new System.Drawing.Size(233, 118);
            this.ExitToAdministratorManageBasicUsersButton.TabIndex = 11;
            this.ExitToAdministratorManageBasicUsersButton.Text = "Powrót do panelu zarządzania użytkownikami";
            this.ExitToAdministratorManageBasicUsersButton.UseVisualStyleBackColor = true;
            this.ExitToAdministratorManageBasicUsersButton.Click += new System.EventHandler(this.ExitToAdministratorManageBasicUsersButton_Click);
            // 
            // AdministratorUpdateBasicUserResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 450);
            this.Controls.Add(this.AdministratorAddBasicUserResultPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministratorUpdateBasicUserResultPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel rezultatu aktualizacji użytkownika";
            this.AdministratorAddBasicUserResultPanelPanel.ResumeLayout(false);
            this.AdministratorAddBasicUserResultPanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdministratorAddBasicUserResultPanelPanel;
        private System.Windows.Forms.Label UpdateBasicUserResultLabel;
        private System.Windows.Forms.Button ExitToAdministratorManageBasicUsersButton;
    }
}