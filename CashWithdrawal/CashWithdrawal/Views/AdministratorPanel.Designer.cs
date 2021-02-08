
namespace CashWithdrawal.Views
{
    partial class AdministratorPanel
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
            this.ManageBasicUsersButton = new System.Windows.Forms.Button();
            this.CashWithdrawalStateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AdministratorInformationLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManageBasicUsersButton
            // 
            this.ManageBasicUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ManageBasicUsersButton.Location = new System.Drawing.Point(37, 97);
            this.ManageBasicUsersButton.Name = "ManageBasicUsersButton";
            this.ManageBasicUsersButton.Size = new System.Drawing.Size(184, 75);
            this.ManageBasicUsersButton.TabIndex = 0;
            this.ManageBasicUsersButton.Text = "Przegląd Użytkowników";
            this.ManageBasicUsersButton.UseVisualStyleBackColor = true;
            // 
            // CashWithdrawalStateButton
            // 
            this.CashWithdrawalStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CashWithdrawalStateButton.Location = new System.Drawing.Point(291, 97);
            this.CashWithdrawalStateButton.Name = "CashWithdrawalStateButton";
            this.CashWithdrawalStateButton.Size = new System.Drawing.Size(184, 75);
            this.CashWithdrawalStateButton.TabIndex = 1;
            this.CashWithdrawalStateButton.Text = "Stan Bankomatu";
            this.CashWithdrawalStateButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AdministratorInformationLabel);
            this.panel1.Controls.Add(this.CashWithdrawalStateButton);
            this.panel1.Controls.Add(this.ManageBasicUsersButton);
            this.panel1.Location = new System.Drawing.Point(150, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 202);
            this.panel1.TabIndex = 2;
            // 
            // AdministratorInformationLabel
            // 
            this.AdministratorInformationLabel.AutoSize = true;
            this.AdministratorInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdministratorInformationLabel.Location = new System.Drawing.Point(134, 30);
            this.AdministratorInformationLabel.Name = "AdministratorInformationLabel";
            this.AdministratorInformationLabel.Size = new System.Drawing.Size(261, 32);
            this.AdministratorInformationLabel.TabIndex = 5;
            this.AdministratorInformationLabel.Text = "Witaj <Użytkownik>";
            // 
            // AdministratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministratorPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Administratora";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ManageBasicUsersButton;
        private System.Windows.Forms.Button CashWithdrawalStateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AdministratorInformationLabel;
    }
}