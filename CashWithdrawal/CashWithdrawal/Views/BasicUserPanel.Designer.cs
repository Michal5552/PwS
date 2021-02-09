
namespace CashWithdrawal.Views
{
    partial class BasicUserPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BasicUserInformationLabel = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.TakeOutMoneyButton = new System.Windows.Forms.Button();
            this.BasicUserAccountStateButton = new System.Windows.Forms.Button();
            this.AddMoneyButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BasicUserInformationLabel);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.TakeOutMoneyButton);
            this.panel1.Controls.Add(this.BasicUserAccountStateButton);
            this.panel1.Controls.Add(this.AddMoneyButton);
            this.panel1.Location = new System.Drawing.Point(139, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 250);
            this.panel1.TabIndex = 0;
            // 
            // BasicUserInformationLabel
            // 
            this.BasicUserInformationLabel.AutoSize = true;
            this.BasicUserInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BasicUserInformationLabel.Location = new System.Drawing.Point(129, 17);
            this.BasicUserInformationLabel.Name = "BasicUserInformationLabel";
            this.BasicUserInformationLabel.Size = new System.Drawing.Size(261, 32);
            this.BasicUserInformationLabel.TabIndex = 4;
            this.BasicUserInformationLabel.Text = "Witaj <Użytkownik>";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogoutButton.Location = new System.Drawing.Point(171, 180);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(173, 44);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Wylogowanie";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // TakeOutMoneyButton
            // 
            this.TakeOutMoneyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakeOutMoneyButton.Location = new System.Drawing.Point(369, 89);
            this.TakeOutMoneyButton.Name = "TakeOutMoneyButton";
            this.TakeOutMoneyButton.Size = new System.Drawing.Size(119, 44);
            this.TakeOutMoneyButton.TabIndex = 2;
            this.TakeOutMoneyButton.Text = "Wypłata";
            this.TakeOutMoneyButton.UseVisualStyleBackColor = true;
            this.TakeOutMoneyButton.Click += new System.EventHandler(this.TakeOutMoneyButton_Click);
            // 
            // BasicUserAccountStateButton
            // 
            this.BasicUserAccountStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BasicUserAccountStateButton.Location = new System.Drawing.Point(171, 89);
            this.BasicUserAccountStateButton.Name = "BasicUserAccountStateButton";
            this.BasicUserAccountStateButton.Size = new System.Drawing.Size(173, 44);
            this.BasicUserAccountStateButton.TabIndex = 1;
            this.BasicUserAccountStateButton.Text = "Stan Konta";
            this.BasicUserAccountStateButton.UseVisualStyleBackColor = true;
            this.BasicUserAccountStateButton.Click += new System.EventHandler(this.BasicUserAccountStateButton_Click);
            // 
            // AddMoneyButton
            // 
            this.AddMoneyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddMoneyButton.Location = new System.Drawing.Point(35, 89);
            this.AddMoneyButton.Name = "AddMoneyButton";
            this.AddMoneyButton.Size = new System.Drawing.Size(119, 44);
            this.AddMoneyButton.TabIndex = 0;
            this.AddMoneyButton.Text = "Wpłata";
            this.AddMoneyButton.UseVisualStyleBackColor = true;
            this.AddMoneyButton.Click += new System.EventHandler(this.AddMoneyButton_Click);
            // 
            // BasicUserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BasicUserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Uytkownika";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicUserPanel_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button TakeOutMoneyButton;
        private System.Windows.Forms.Button BasicUserAccountStateButton;
        private System.Windows.Forms.Button AddMoneyButton;
        private System.Windows.Forms.Label BasicUserInformationLabel;
    }
}