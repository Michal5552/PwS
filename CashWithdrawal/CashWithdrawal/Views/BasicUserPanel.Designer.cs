
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
            this.AddMoneyButton = new System.Windows.Forms.Button();
            this.BankAccountStateButton = new System.Windows.Forms.Button();
            this.TakeOutMoneyButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BasicUserInformationLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BasicUserInformationLabel);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.TakeOutMoneyButton);
            this.panel1.Controls.Add(this.BankAccountStateButton);
            this.panel1.Controls.Add(this.AddMoneyButton);
            this.panel1.Location = new System.Drawing.Point(148, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 250);
            this.panel1.TabIndex = 0;
            // 
            // AddMoneyButton
            // 
            this.AddMoneyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddMoneyButton.Location = new System.Drawing.Point(26, 89);
            this.AddMoneyButton.Name = "AddMoneyButton";
            this.AddMoneyButton.Size = new System.Drawing.Size(111, 44);
            this.AddMoneyButton.TabIndex = 0;
            this.AddMoneyButton.Text = "Wpłata";
            this.AddMoneyButton.UseVisualStyleBackColor = true;
            // 
            // BankAccountStateButton
            // 
            this.BankAccountStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankAccountStateButton.Location = new System.Drawing.Point(171, 89);
            this.BankAccountStateButton.Name = "BankAccountStateButton";
            this.BankAccountStateButton.Size = new System.Drawing.Size(157, 44);
            this.BankAccountStateButton.TabIndex = 1;
            this.BankAccountStateButton.Text = "Stan Konta";
            this.BankAccountStateButton.UseVisualStyleBackColor = true;
            // 
            // TakeOutMoneyButton
            // 
            this.TakeOutMoneyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakeOutMoneyButton.Location = new System.Drawing.Point(361, 89);
            this.TakeOutMoneyButton.Name = "TakeOutMoneyButton";
            this.TakeOutMoneyButton.Size = new System.Drawing.Size(111, 44);
            this.TakeOutMoneyButton.TabIndex = 2;
            this.TakeOutMoneyButton.Text = "Wypłata";
            this.TakeOutMoneyButton.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(171, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "Wylogowanie";
            this.button4.UseVisualStyleBackColor = true;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button TakeOutMoneyButton;
        private System.Windows.Forms.Button BankAccountStateButton;
        private System.Windows.Forms.Button AddMoneyButton;
        private System.Windows.Forms.Label BasicUserInformationLabel;
    }
}