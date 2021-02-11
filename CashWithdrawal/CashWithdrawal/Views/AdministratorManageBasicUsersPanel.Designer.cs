
namespace CashWithdrawal.Views
{
    partial class AdministratorManageBasicUsersPanel
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
            this.ManageBasicUsersPanelPanel = new System.Windows.Forms.Panel();
            this.ExitToAdministratorPanelButton = new System.Windows.Forms.Button();
            this.RemoveBasicUserButton = new System.Windows.Forms.Button();
            this.UpdateBasicUserButton = new System.Windows.Forms.Button();
            this.AddBasicUserButton = new System.Windows.Forms.Button();
            this.AdministratorInformationLabel = new System.Windows.Forms.Label();
            this.BasicUsersDataGridView = new System.Windows.Forms.DataGridView();
            this.ManageBasicUsersPanelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BasicUsersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ManageBasicUsersPanelPanel
            // 
            this.ManageBasicUsersPanelPanel.Controls.Add(this.ExitToAdministratorPanelButton);
            this.ManageBasicUsersPanelPanel.Controls.Add(this.RemoveBasicUserButton);
            this.ManageBasicUsersPanelPanel.Controls.Add(this.UpdateBasicUserButton);
            this.ManageBasicUsersPanelPanel.Controls.Add(this.AddBasicUserButton);
            this.ManageBasicUsersPanelPanel.Controls.Add(this.AdministratorInformationLabel);
            this.ManageBasicUsersPanelPanel.Controls.Add(this.BasicUsersDataGridView);
            this.ManageBasicUsersPanelPanel.Location = new System.Drawing.Point(12, 22);
            this.ManageBasicUsersPanelPanel.Name = "ManageBasicUsersPanelPanel";
            this.ManageBasicUsersPanelPanel.Size = new System.Drawing.Size(759, 587);
            this.ManageBasicUsersPanelPanel.TabIndex = 0;
            // 
            // ExitToAdministratorPanelButton
            // 
            this.ExitToAdministratorPanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToAdministratorPanelButton.Location = new System.Drawing.Point(281, 482);
            this.ExitToAdministratorPanelButton.Name = "ExitToAdministratorPanelButton";
            this.ExitToAdministratorPanelButton.Size = new System.Drawing.Size(248, 75);
            this.ExitToAdministratorPanelButton.TabIndex = 5;
            this.ExitToAdministratorPanelButton.Text = "Powrót Do Panelu Administratora";
            this.ExitToAdministratorPanelButton.UseVisualStyleBackColor = true;
            this.ExitToAdministratorPanelButton.Click += new System.EventHandler(this.ExitToAdministratorPanelButton_Click);
            // 
            // RemoveBasicUserButton
            // 
            this.RemoveBasicUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RemoveBasicUserButton.Location = new System.Drawing.Point(559, 349);
            this.RemoveBasicUserButton.Name = "RemoveBasicUserButton";
            this.RemoveBasicUserButton.Size = new System.Drawing.Size(171, 75);
            this.RemoveBasicUserButton.TabIndex = 4;
            this.RemoveBasicUserButton.Text = "Usuń Użytkownika";
            this.RemoveBasicUserButton.UseVisualStyleBackColor = true;
            this.RemoveBasicUserButton.Click += new System.EventHandler(this.RemoveBasicUserButton_Click);
            // 
            // UpdateBasicUserButton
            // 
            this.UpdateBasicUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpdateBasicUserButton.Location = new System.Drawing.Point(317, 349);
            this.UpdateBasicUserButton.Name = "UpdateBasicUserButton";
            this.UpdateBasicUserButton.Size = new System.Drawing.Size(171, 75);
            this.UpdateBasicUserButton.TabIndex = 3;
            this.UpdateBasicUserButton.Text = "Edytuj Użytkownika";
            this.UpdateBasicUserButton.UseVisualStyleBackColor = true;
            this.UpdateBasicUserButton.Click += new System.EventHandler(this.UpdateBasicUserButton_Click);
            // 
            // AddBasicUserButton
            // 
            this.AddBasicUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddBasicUserButton.Location = new System.Drawing.Point(90, 349);
            this.AddBasicUserButton.Name = "AddBasicUserButton";
            this.AddBasicUserButton.Size = new System.Drawing.Size(171, 75);
            this.AddBasicUserButton.TabIndex = 2;
            this.AddBasicUserButton.Text = "Dodaj Użytkownika";
            this.AddBasicUserButton.UseVisualStyleBackColor = true;
            this.AddBasicUserButton.Click += new System.EventHandler(this.AddBasicUserButton_Click);
            // 
            // AdministratorInformationLabel
            // 
            this.AdministratorInformationLabel.AutoSize = true;
            this.AdministratorInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdministratorInformationLabel.Location = new System.Drawing.Point(101, 20);
            this.AdministratorInformationLabel.Name = "AdministratorInformationLabel";
            this.AdministratorInformationLabel.Size = new System.Drawing.Size(232, 29);
            this.AdministratorInformationLabel.TabIndex = 1;
            this.AdministratorInformationLabel.Text = "Zalogowano Jako :";
            // 
            // BasicUsersDataGridView
            // 
            this.BasicUsersDataGridView.AllowUserToAddRows = false;
            this.BasicUsersDataGridView.AllowUserToDeleteRows = false;
            this.BasicUsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.BasicUsersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.BasicUsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BasicUsersDataGridView.Location = new System.Drawing.Point(106, 83);
            this.BasicUsersDataGridView.Name = "BasicUsersDataGridView";
            this.BasicUsersDataGridView.ReadOnly = true;
            this.BasicUsersDataGridView.RowHeadersWidth = 62;
            this.BasicUsersDataGridView.RowTemplate.Height = 28;
            this.BasicUsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BasicUsersDataGridView.Size = new System.Drawing.Size(597, 214);
            this.BasicUsersDataGridView.TabIndex = 0;
            this.BasicUsersDataGridView.Click += new System.EventHandler(this.BasicUsersDataGridView_Click);
            // 
            // AdministratorManageBasicUsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 642);
            this.Controls.Add(this.ManageBasicUsersPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdministratorManageBasicUsersPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Zarządzania Użytkownikami";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageBasicUsersPanel_FormClosing);
            this.ManageBasicUsersPanelPanel.ResumeLayout(false);
            this.ManageBasicUsersPanelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BasicUsersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ManageBasicUsersPanelPanel;
        private System.Windows.Forms.DataGridView BasicUsersDataGridView;
        private System.Windows.Forms.Label AdministratorInformationLabel;
        private System.Windows.Forms.Button RemoveBasicUserButton;
        private System.Windows.Forms.Button UpdateBasicUserButton;
        private System.Windows.Forms.Button AddBasicUserButton;
        private System.Windows.Forms.Button ExitToAdministratorPanelButton;
    }
}