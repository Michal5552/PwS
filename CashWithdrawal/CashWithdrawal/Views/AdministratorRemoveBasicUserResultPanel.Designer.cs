
namespace CashWithdrawal.ViewModels
{
    partial class AdministratorRemoveBasicUserResultPanel
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
            this.AdministratorRemoveBasicUserResultPanelPanel = new System.Windows.Forms.Panel();
            this.AddBasicUserResultLabel = new System.Windows.Forms.Label();
            this.ExitToAdministratorManageBasicUsersButton = new System.Windows.Forms.Button();
            this.AdministratorRemoveBasicUserResultPanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdministratorRemoveBasicUserResultPanelPanel
            // 
            this.AdministratorRemoveBasicUserResultPanelPanel.Controls.Add(this.AddBasicUserResultLabel);
            this.AdministratorRemoveBasicUserResultPanelPanel.Controls.Add(this.ExitToAdministratorManageBasicUsersButton);
            this.AdministratorRemoveBasicUserResultPanelPanel.Location = new System.Drawing.Point(137, 52);
            this.AdministratorRemoveBasicUserResultPanelPanel.Name = "AdministratorRemoveBasicUserResultPanelPanel";
            this.AdministratorRemoveBasicUserResultPanelPanel.Size = new System.Drawing.Size(420, 321);
            this.AdministratorRemoveBasicUserResultPanelPanel.TabIndex = 0;
            // 
            // AddBasicUserResultLabel
            // 
            this.AddBasicUserResultLabel.AutoSize = true;
            this.AddBasicUserResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddBasicUserResultLabel.Location = new System.Drawing.Point(17, 30);
            this.AddBasicUserResultLabel.Name = "AddBasicUserResultLabel";
            this.AddBasicUserResultLabel.Size = new System.Drawing.Size(395, 64);
            this.AddBasicUserResultLabel.TabIndex = 14;
            this.AddBasicUserResultLabel.Text = "Użytkownik Został Usunięty \r\nZ Bazy Danych";
            this.AddBasicUserResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitToAdministratorManageBasicUsersButton
            // 
            this.ExitToAdministratorManageBasicUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToAdministratorManageBasicUsersButton.Location = new System.Drawing.Point(90, 171);
            this.ExitToAdministratorManageBasicUsersButton.Name = "ExitToAdministratorManageBasicUsersButton";
            this.ExitToAdministratorManageBasicUsersButton.Size = new System.Drawing.Size(233, 118);
            this.ExitToAdministratorManageBasicUsersButton.TabIndex = 13;
            this.ExitToAdministratorManageBasicUsersButton.Text = "Powrót Do Panelu Zarządzania Użytkownikami";
            this.ExitToAdministratorManageBasicUsersButton.UseVisualStyleBackColor = true;
            this.ExitToAdministratorManageBasicUsersButton.Click += new System.EventHandler(this.ExitToAdministratorManageBasicUsersButton_Click);
            // 
            // AdministratorRemoveBasicUserResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 441);
            this.Controls.Add(this.AdministratorRemoveBasicUserResultPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorRemoveBasicUserResultPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Rezultatu Usunięcia Użytkownika";
            this.AdministratorRemoveBasicUserResultPanelPanel.ResumeLayout(false);
            this.AdministratorRemoveBasicUserResultPanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdministratorRemoveBasicUserResultPanelPanel;
        private System.Windows.Forms.Label AddBasicUserResultLabel;
        private System.Windows.Forms.Button ExitToAdministratorManageBasicUsersButton;
    }
}