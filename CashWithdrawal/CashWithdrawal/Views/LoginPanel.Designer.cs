
namespace CashWithdrawal
{
    partial class LoginPanel
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.LoginPanelPanel = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.PinCodeLabel = new System.Windows.Forms.Label();
            this.PinCodeTextBox = new System.Windows.Forms.TextBox();
            this.LoginPanelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanelPanel
            // 
            this.LoginPanelPanel.Controls.Add(this.ClearButton);
            this.LoginPanelPanel.Controls.Add(this.AcceptButton);
            this.LoginPanelPanel.Controls.Add(this.ErrorLabel);
            this.LoginPanelPanel.Controls.Add(this.PinCodeLabel);
            this.LoginPanelPanel.Controls.Add(this.PinCodeTextBox);
            this.LoginPanelPanel.Location = new System.Drawing.Point(156, 94);
            this.LoginPanelPanel.Name = "LoginPanelPanel";
            this.LoginPanelPanel.Size = new System.Drawing.Size(551, 266);
            this.LoginPanelPanel.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClearButton.Location = new System.Drawing.Point(43, 139);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(111, 44);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Wyczyść";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptButton.Location = new System.Drawing.Point(384, 139);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(111, 44);
            this.AcceptButton.TabIndex = 4;
            this.AcceptButton.Text = "OK";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(49, 210);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(127, 29);
            this.ErrorLabel.TabIndex = 3;
            this.ErrorLabel.Text = "ErrorLabel";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PinCodeLabel
            // 
            this.PinCodeLabel.AutoSize = true;
            this.PinCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PinCodeLabel.Location = new System.Drawing.Point(253, 33);
            this.PinCodeLabel.Name = "PinCodeLabel";
            this.PinCodeLabel.Size = new System.Drawing.Size(57, 32);
            this.PinCodeLabel.TabIndex = 2;
            this.PinCodeLabel.Text = "Pin";
            // 
            // PinCodeTextBox
            // 
            this.PinCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PinCodeTextBox.Location = new System.Drawing.Point(207, 79);
            this.PinCodeTextBox.MaxLength = 6;
            this.PinCodeTextBox.Name = "PinCodeTextBox";
            this.PinCodeTextBox.Size = new System.Drawing.Size(148, 39);
            this.PinCodeTextBox.TabIndex = 1;
            this.PinCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginPanelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Panel";
            this.LoginPanelPanel.ResumeLayout(false);
            this.LoginPanelPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel LoginPanelPanel;
        private System.Windows.Forms.Label PinCodeLabel;
        private System.Windows.Forms.TextBox PinCodeTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AcceptButton;
    }
}

