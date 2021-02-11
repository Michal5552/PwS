
namespace CashWithdrawal.Views
{
    partial class AdministratorRemoveBasicUserPanel
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
            this.AdministratorRemoveBasicUserPanelPanel = new System.Windows.Forms.Panel();
            this.DropRemoveBasicUserButton = new System.Windows.Forms.Button();
            this.AcceptRemoveBasicUserButton = new System.Windows.Forms.Button();
            this.RemoveBasicUserStatementLabel = new System.Windows.Forms.Label();
            this.AdministratorRemoveBasicUserPanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdministratorRemoveBasicUserPanelPanel
            // 
            this.AdministratorRemoveBasicUserPanelPanel.Controls.Add(this.DropRemoveBasicUserButton);
            this.AdministratorRemoveBasicUserPanelPanel.Controls.Add(this.AcceptRemoveBasicUserButton);
            this.AdministratorRemoveBasicUserPanelPanel.Controls.Add(this.RemoveBasicUserStatementLabel);
            this.AdministratorRemoveBasicUserPanelPanel.Location = new System.Drawing.Point(40, 37);
            this.AdministratorRemoveBasicUserPanelPanel.Name = "AdministratorRemoveBasicUserPanelPanel";
            this.AdministratorRemoveBasicUserPanelPanel.Size = new System.Drawing.Size(594, 265);
            this.AdministratorRemoveBasicUserPanelPanel.TabIndex = 0;
            // 
            // DropRemoveBasicUserButton
            // 
            this.DropRemoveBasicUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DropRemoveBasicUserButton.Location = new System.Drawing.Point(144, 133);
            this.DropRemoveBasicUserButton.Name = "DropRemoveBasicUserButton";
            this.DropRemoveBasicUserButton.Size = new System.Drawing.Size(107, 46);
            this.DropRemoveBasicUserButton.TabIndex = 2;
            this.DropRemoveBasicUserButton.Text = "Nie";
            this.DropRemoveBasicUserButton.UseVisualStyleBackColor = true;
            this.DropRemoveBasicUserButton.Click += new System.EventHandler(this.DropRemoveBasicUserButton_Click);
            // 
            // AcceptRemoveBasicUserButton
            // 
            this.AcceptRemoveBasicUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptRemoveBasicUserButton.Location = new System.Drawing.Point(318, 133);
            this.AcceptRemoveBasicUserButton.Name = "AcceptRemoveBasicUserButton";
            this.AcceptRemoveBasicUserButton.Size = new System.Drawing.Size(107, 46);
            this.AcceptRemoveBasicUserButton.TabIndex = 1;
            this.AcceptRemoveBasicUserButton.Text = "Tak";
            this.AcceptRemoveBasicUserButton.UseVisualStyleBackColor = true;
            this.AcceptRemoveBasicUserButton.Click += new System.EventHandler(this.AcceptRemoveBasicUserButton_Click);
            // 
            // RemoveBasicUserStatementLabel
            // 
            this.RemoveBasicUserStatementLabel.AutoSize = true;
            this.RemoveBasicUserStatementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RemoveBasicUserStatementLabel.Location = new System.Drawing.Point(48, 50);
            this.RemoveBasicUserStatementLabel.Name = "RemoveBasicUserStatementLabel";
            this.RemoveBasicUserStatementLabel.Size = new System.Drawing.Size(492, 29);
            this.RemoveBasicUserStatementLabel.TabIndex = 0;
            this.RemoveBasicUserStatementLabel.Text = "Czy Na Pewno Chcesz Usunąć Użytkownika: ";
            this.RemoveBasicUserStatementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdministratorRemoveBasicUserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 353);
            this.Controls.Add(this.AdministratorRemoveBasicUserPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorRemoveBasicUserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Komunikatu Usunięcia Użytkownika";
            this.AdministratorRemoveBasicUserPanelPanel.ResumeLayout(false);
            this.AdministratorRemoveBasicUserPanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdministratorRemoveBasicUserPanelPanel;
        private System.Windows.Forms.Button DropRemoveBasicUserButton;
        private System.Windows.Forms.Button AcceptRemoveBasicUserButton;
        private System.Windows.Forms.Label RemoveBasicUserStatementLabel;
    }
}