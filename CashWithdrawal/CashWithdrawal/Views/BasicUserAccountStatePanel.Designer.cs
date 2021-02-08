
namespace CashWithdrawal.Views
{
    partial class BasicUserAccountStatePanel
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
            this.CurrencyGroupBox = new System.Windows.Forms.GroupBox();
            this.PLN_CurrencyRadioButton = new System.Windows.Forms.RadioButton();
            this.USD_CurrencyRadioButton = new System.Windows.Forms.RadioButton();
            this.EUR_CurrencyRadioButton = new System.Windows.Forms.RadioButton();
            this.GBP_CurrencyRadioButton = new System.Windows.Forms.RadioButton();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.CurrencyPanel = new System.Windows.Forms.Panel();
            this.AccountStateLabel = new System.Windows.Forms.Label();
            this.AccountStateValueLabel = new System.Windows.Forms.Label();
            this.ExitToBasicUserPanelButton = new System.Windows.Forms.Button();
            this.PrintReportButton = new System.Windows.Forms.Button();
            this.BasicUserAccountStatePanelPanel = new System.Windows.Forms.Panel();
            this.CurrencyRatesPanel = new System.Windows.Forms.Panel();
            this.ExchangeRatesLabel = new System.Windows.Forms.Label();
            this.PLN_ExchangeRateLabel = new System.Windows.Forms.Label();
            this.PLN_ExchangeRateValueLabel = new System.Windows.Forms.Label();
            this.USD_ExchangeRateLabel = new System.Windows.Forms.Label();
            this.USD_ExchangeRateValueLabel = new System.Windows.Forms.Label();
            this.EUR_ExchangeRateValueLabel = new System.Windows.Forms.Label();
            this.EUR_ExchangeRateLabel = new System.Windows.Forms.Label();
            this.GBP_ExchangeRateValueLabel = new System.Windows.Forms.Label();
            this.GBP_ExchangeRateLabel = new System.Windows.Forms.Label();
            this.CurrencyGroupBox.SuspendLayout();
            this.CurrencyPanel.SuspendLayout();
            this.BasicUserAccountStatePanelPanel.SuspendLayout();
            this.CurrencyRatesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrencyGroupBox
            // 
            this.CurrencyGroupBox.Controls.Add(this.GBP_CurrencyRadioButton);
            this.CurrencyGroupBox.Controls.Add(this.PLN_CurrencyRadioButton);
            this.CurrencyGroupBox.Controls.Add(this.EUR_CurrencyRadioButton);
            this.CurrencyGroupBox.Controls.Add(this.USD_CurrencyRadioButton);
            this.CurrencyGroupBox.Location = new System.Drawing.Point(8, 60);
            this.CurrencyGroupBox.Name = "CurrencyGroupBox";
            this.CurrencyGroupBox.Size = new System.Drawing.Size(177, 153);
            this.CurrencyGroupBox.TabIndex = 0;
            this.CurrencyGroupBox.TabStop = false;
            // 
            // PLN_CurrencyRadioButton
            // 
            this.PLN_CurrencyRadioButton.AutoSize = true;
            this.PLN_CurrencyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PLN_CurrencyRadioButton.Location = new System.Drawing.Point(0, -2);
            this.PLN_CurrencyRadioButton.Name = "PLN_CurrencyRadioButton";
            this.PLN_CurrencyRadioButton.Size = new System.Drawing.Size(164, 33);
            this.PLN_CurrencyRadioButton.TabIndex = 0;
            this.PLN_CurrencyRadioButton.TabStop = true;
            this.PLN_CurrencyRadioButton.Text = "Polski Złoty";
            this.PLN_CurrencyRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PLN_CurrencyRadioButton.UseVisualStyleBackColor = true;
            this.PLN_CurrencyRadioButton.CheckedChanged += new System.EventHandler(this.PLN_ExchangeRadioButton_CheckedChanged);
            // 
            // USD_CurrencyRadioButton
            // 
            this.USD_CurrencyRadioButton.AutoSize = true;
            this.USD_CurrencyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.USD_CurrencyRadioButton.Location = new System.Drawing.Point(0, 37);
            this.USD_CurrencyRadioButton.Name = "USD_CurrencyRadioButton";
            this.USD_CurrencyRadioButton.Size = new System.Drawing.Size(96, 33);
            this.USD_CurrencyRadioButton.TabIndex = 1;
            this.USD_CurrencyRadioButton.TabStop = true;
            this.USD_CurrencyRadioButton.Text = "Dolar";
            this.USD_CurrencyRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.USD_CurrencyRadioButton.UseVisualStyleBackColor = true;
            this.USD_CurrencyRadioButton.CheckedChanged += new System.EventHandler(this.USD_ExchangeRadioButton_CheckedChanged);
            // 
            // EUR_CurrencyRadioButton
            // 
            this.EUR_CurrencyRadioButton.AutoSize = true;
            this.EUR_CurrencyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EUR_CurrencyRadioButton.Location = new System.Drawing.Point(0, 76);
            this.EUR_CurrencyRadioButton.Name = "EUR_CurrencyRadioButton";
            this.EUR_CurrencyRadioButton.Size = new System.Drawing.Size(89, 33);
            this.EUR_CurrencyRadioButton.TabIndex = 2;
            this.EUR_CurrencyRadioButton.TabStop = true;
            this.EUR_CurrencyRadioButton.Text = "Euro";
            this.EUR_CurrencyRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EUR_CurrencyRadioButton.UseVisualStyleBackColor = true;
            this.EUR_CurrencyRadioButton.CheckedChanged += new System.EventHandler(this.EUR_ExchangeRadioButton_CheckedChanged);
            // 
            // GBP_CurrencyRadioButton
            // 
            this.GBP_CurrencyRadioButton.AutoSize = true;
            this.GBP_CurrencyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBP_CurrencyRadioButton.Location = new System.Drawing.Point(0, 115);
            this.GBP_CurrencyRadioButton.Name = "GBP_CurrencyRadioButton";
            this.GBP_CurrencyRadioButton.Size = new System.Drawing.Size(179, 33);
            this.GBP_CurrencyRadioButton.TabIndex = 3;
            this.GBP_CurrencyRadioButton.TabStop = true;
            this.GBP_CurrencyRadioButton.Text = "Funt Brytyjski";
            this.GBP_CurrencyRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GBP_CurrencyRadioButton.UseVisualStyleBackColor = true;
            this.GBP_CurrencyRadioButton.CheckedChanged += new System.EventHandler(this.GBP_ExchangeRadioButton_CheckedChanged);
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.AutoSize = true;
            this.CurrencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CurrencyLabel.Location = new System.Drawing.Point(42, 10);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(110, 32);
            this.CurrencyLabel.TabIndex = 1;
            this.CurrencyLabel.Text = "Waluta";
            // 
            // CurrencyPanel
            // 
            this.CurrencyPanel.Controls.Add(this.CurrencyLabel);
            this.CurrencyPanel.Controls.Add(this.CurrencyGroupBox);
            this.CurrencyPanel.Location = new System.Drawing.Point(402, 22);
            this.CurrencyPanel.Name = "CurrencyPanel";
            this.CurrencyPanel.Size = new System.Drawing.Size(195, 227);
            this.CurrencyPanel.TabIndex = 2;
            // 
            // AccountStateLabel
            // 
            this.AccountStateLabel.AutoSize = true;
            this.AccountStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AccountStateLabel.Location = new System.Drawing.Point(83, 315);
            this.AccountStateLabel.Name = "AccountStateLabel";
            this.AccountStateLabel.Size = new System.Drawing.Size(171, 32);
            this.AccountStateLabel.TabIndex = 3;
            this.AccountStateLabel.Text = "Stan Konta :";
            // 
            // AccountStateValueLabel
            // 
            this.AccountStateValueLabel.AutoSize = true;
            this.AccountStateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AccountStateValueLabel.Location = new System.Drawing.Point(260, 315);
            this.AccountStateValueLabel.Name = "AccountStateValueLabel";
            this.AccountStateValueLabel.Size = new System.Drawing.Size(282, 32);
            this.AccountStateValueLabel.TabIndex = 4;
            this.AccountStateValueLabel.Text = "Wartość Stanu Konta";
            // 
            // ExitToBasicUserPanelButton
            // 
            this.ExitToBasicUserPanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitToBasicUserPanelButton.Location = new System.Drawing.Point(44, 418);
            this.ExitToBasicUserPanelButton.Name = "ExitToBasicUserPanelButton";
            this.ExitToBasicUserPanelButton.Size = new System.Drawing.Size(220, 81);
            this.ExitToBasicUserPanelButton.TabIndex = 6;
            this.ExitToBasicUserPanelButton.Text = "Powrót Do Panelu Głównego";
            this.ExitToBasicUserPanelButton.UseVisualStyleBackColor = true;
            // 
            // PrintReportButton
            // 
            this.PrintReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrintReportButton.Location = new System.Drawing.Point(359, 418);
            this.PrintReportButton.Name = "PrintReportButton";
            this.PrintReportButton.Size = new System.Drawing.Size(220, 81);
            this.PrintReportButton.TabIndex = 7;
            this.PrintReportButton.Text = "Wydrukowanie Raportu";
            this.PrintReportButton.UseVisualStyleBackColor = true;
            // 
            // BasicUserAccountStatePanelPanel
            // 
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.CurrencyRatesPanel);
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.CurrencyPanel);
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.PrintReportButton);
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.AccountStateValueLabel);
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.ExitToBasicUserPanelButton);
            this.BasicUserAccountStatePanelPanel.Controls.Add(this.AccountStateLabel);
            this.BasicUserAccountStatePanelPanel.Location = new System.Drawing.Point(127, 40);
            this.BasicUserAccountStatePanelPanel.Name = "BasicUserAccountStatePanelPanel";
            this.BasicUserAccountStatePanelPanel.Size = new System.Drawing.Size(613, 530);
            this.BasicUserAccountStatePanelPanel.TabIndex = 8;
            // 
            // CurrencyRatesPanel
            // 
            this.CurrencyRatesPanel.Controls.Add(this.GBP_ExchangeRateValueLabel);
            this.CurrencyRatesPanel.Controls.Add(this.EUR_ExchangeRateValueLabel);
            this.CurrencyRatesPanel.Controls.Add(this.GBP_ExchangeRateLabel);
            this.CurrencyRatesPanel.Controls.Add(this.EUR_ExchangeRateLabel);
            this.CurrencyRatesPanel.Controls.Add(this.USD_ExchangeRateValueLabel);
            this.CurrencyRatesPanel.Controls.Add(this.USD_ExchangeRateLabel);
            this.CurrencyRatesPanel.Controls.Add(this.PLN_ExchangeRateValueLabel);
            this.CurrencyRatesPanel.Controls.Add(this.PLN_ExchangeRateLabel);
            this.CurrencyRatesPanel.Controls.Add(this.ExchangeRatesLabel);
            this.CurrencyRatesPanel.Location = new System.Drawing.Point(20, 22);
            this.CurrencyRatesPanel.Name = "CurrencyRatesPanel";
            this.CurrencyRatesPanel.Size = new System.Drawing.Size(321, 272);
            this.CurrencyRatesPanel.TabIndex = 8;
            // 
            // ExchangeRatesLabel
            // 
            this.ExchangeRatesLabel.AutoSize = true;
            this.ExchangeRatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExchangeRatesLabel.Location = new System.Drawing.Point(64, 10);
            this.ExchangeRatesLabel.Name = "ExchangeRatesLabel";
            this.ExchangeRatesLabel.Size = new System.Drawing.Size(209, 64);
            this.ExchangeRatesLabel.TabIndex = 2;
            this.ExchangeRatesLabel.Text = "Współczynniki\r\n    Walutowe";
            // 
            // PLN_ExchangeRateLabel
            // 
            this.PLN_ExchangeRateLabel.AutoSize = true;
            this.PLN_ExchangeRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PLN_ExchangeRateLabel.Location = new System.Drawing.Point(37, 99);
            this.PLN_ExchangeRateLabel.Name = "PLN_ExchangeRateLabel";
            this.PLN_ExchangeRateLabel.Size = new System.Drawing.Size(151, 29);
            this.PLN_ExchangeRateLabel.TabIndex = 3;
            this.PLN_ExchangeRateLabel.Text = "Polski Złoty :";
            // 
            // PLN_ExchangeRateValueLabel
            // 
            this.PLN_ExchangeRateValueLabel.AutoSize = true;
            this.PLN_ExchangeRateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PLN_ExchangeRateValueLabel.Location = new System.Drawing.Point(199, 99);
            this.PLN_ExchangeRateValueLabel.Name = "PLN_ExchangeRateValueLabel";
            this.PLN_ExchangeRateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.PLN_ExchangeRateValueLabel.TabIndex = 4;
            this.PLN_ExchangeRateValueLabel.Text = "Wartość";
            // 
            // USD_ExchangeRateLabel
            // 
            this.USD_ExchangeRateLabel.AutoSize = true;
            this.USD_ExchangeRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.USD_ExchangeRateLabel.Location = new System.Drawing.Point(105, 138);
            this.USD_ExchangeRateLabel.Name = "USD_ExchangeRateLabel";
            this.USD_ExchangeRateLabel.Size = new System.Drawing.Size(83, 29);
            this.USD_ExchangeRateLabel.TabIndex = 5;
            this.USD_ExchangeRateLabel.Text = "Dolar :";
            // 
            // USD_ExchangeRateValueLabel
            // 
            this.USD_ExchangeRateValueLabel.AutoSize = true;
            this.USD_ExchangeRateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.USD_ExchangeRateValueLabel.Location = new System.Drawing.Point(199, 140);
            this.USD_ExchangeRateValueLabel.Name = "USD_ExchangeRateValueLabel";
            this.USD_ExchangeRateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.USD_ExchangeRateValueLabel.TabIndex = 6;
            this.USD_ExchangeRateValueLabel.Text = "Wartość";
            // 
            // EUR_ExchangeRateValueLabel
            // 
            this.EUR_ExchangeRateValueLabel.AutoSize = true;
            this.EUR_ExchangeRateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EUR_ExchangeRateValueLabel.Location = new System.Drawing.Point(199, 179);
            this.EUR_ExchangeRateValueLabel.Name = "EUR_ExchangeRateValueLabel";
            this.EUR_ExchangeRateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.EUR_ExchangeRateValueLabel.TabIndex = 8;
            this.EUR_ExchangeRateValueLabel.Text = "Wartość";
            // 
            // EUR_ExchangeRateLabel
            // 
            this.EUR_ExchangeRateLabel.AutoSize = true;
            this.EUR_ExchangeRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EUR_ExchangeRateLabel.Location = new System.Drawing.Point(112, 177);
            this.EUR_ExchangeRateLabel.Name = "EUR_ExchangeRateLabel";
            this.EUR_ExchangeRateLabel.Size = new System.Drawing.Size(76, 29);
            this.EUR_ExchangeRateLabel.TabIndex = 7;
            this.EUR_ExchangeRateLabel.Text = "Euro :";
            // 
            // GBP_ExchangeRateValueLabel
            // 
            this.GBP_ExchangeRateValueLabel.AutoSize = true;
            this.GBP_ExchangeRateValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBP_ExchangeRateValueLabel.Location = new System.Drawing.Point(199, 220);
            this.GBP_ExchangeRateValueLabel.Name = "GBP_ExchangeRateValueLabel";
            this.GBP_ExchangeRateValueLabel.Size = new System.Drawing.Size(100, 29);
            this.GBP_ExchangeRateValueLabel.TabIndex = 10;
            this.GBP_ExchangeRateValueLabel.Text = "Wartość";
            // 
            // GBP_ExchangeRateLabel
            // 
            this.GBP_ExchangeRateLabel.AutoSize = true;
            this.GBP_ExchangeRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GBP_ExchangeRateLabel.Location = new System.Drawing.Point(22, 220);
            this.GBP_ExchangeRateLabel.Name = "GBP_ExchangeRateLabel";
            this.GBP_ExchangeRateLabel.Size = new System.Drawing.Size(166, 29);
            this.GBP_ExchangeRateLabel.TabIndex = 9;
            this.GBP_ExchangeRateLabel.Text = "Funt Brytyjski :";
            // 
            // BasicUserAccountStatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 612);
            this.Controls.Add(this.BasicUserAccountStatePanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BasicUserAccountStatePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Stanu Konta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasicUserAccountStatePanel_FormClosing);
            this.CurrencyGroupBox.ResumeLayout(false);
            this.CurrencyGroupBox.PerformLayout();
            this.CurrencyPanel.ResumeLayout(false);
            this.CurrencyPanel.PerformLayout();
            this.BasicUserAccountStatePanelPanel.ResumeLayout(false);
            this.BasicUserAccountStatePanelPanel.PerformLayout();
            this.CurrencyRatesPanel.ResumeLayout(false);
            this.CurrencyRatesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CurrencyGroupBox;
        private System.Windows.Forms.RadioButton GBP_CurrencyRadioButton;
        private System.Windows.Forms.RadioButton PLN_CurrencyRadioButton;
        private System.Windows.Forms.RadioButton EUR_CurrencyRadioButton;
        private System.Windows.Forms.RadioButton USD_CurrencyRadioButton;
        private System.Windows.Forms.Label CurrencyLabel;
        private System.Windows.Forms.Panel CurrencyPanel;
        private System.Windows.Forms.Label AccountStateLabel;
        private System.Windows.Forms.Label AccountStateValueLabel;
        private System.Windows.Forms.Button ExitToBasicUserPanelButton;
        private System.Windows.Forms.Button PrintReportButton;
        private System.Windows.Forms.Panel BasicUserAccountStatePanelPanel;
        private System.Windows.Forms.Panel CurrencyRatesPanel;
        private System.Windows.Forms.Label GBP_ExchangeRateValueLabel;
        private System.Windows.Forms.Label EUR_ExchangeRateValueLabel;
        private System.Windows.Forms.Label GBP_ExchangeRateLabel;
        private System.Windows.Forms.Label EUR_ExchangeRateLabel;
        private System.Windows.Forms.Label USD_ExchangeRateValueLabel;
        private System.Windows.Forms.Label USD_ExchangeRateLabel;
        private System.Windows.Forms.Label PLN_ExchangeRateValueLabel;
        private System.Windows.Forms.Label PLN_ExchangeRateLabel;
        private System.Windows.Forms.Label ExchangeRatesLabel;
    }
}