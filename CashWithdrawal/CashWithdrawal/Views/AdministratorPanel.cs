using cashDispenserLibrary.Data;
using CashWithdrawal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class AdministratorPanel : Form
    {
        private LoginPanel loginPanel;
        private Administrator administrator;

        public AdministratorPanel(AdministratorPanelVM administratorPanelVM)
        {
            InitializeComponent();

            // Set information about login panel
            loginPanel = administratorPanelVM.loginPanel;

            // Set administrator information
            this.administrator = administratorPanelVM.administrator;

            // Show basic user information
            AdministratorInformationLabel.Text = $"Witaj {administrator._Name._Value } " +
                $"{administrator._Surname._Value}";
        }

        private void AdministratorPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close program
            this.Dispose();
            loginPanel.Close();
        }

        private void ManageBasicUsersButton_Click(object sender, EventArgs e)
        {
            // Redirect to manage basic users panel
            AdministratorManageBasicUsersPanelVM manageBasicUsersPanelVM =
                new AdministratorManageBasicUsersPanelVM
                {
                    loginPanel = this.loginPanel,
                    administratorPanel = this,
                    administrator = this.administrator
                };

            AdministratorManageBasicUsersPanel administratorManageBasicUsersPanel = new
                AdministratorManageBasicUsersPanel(manageBasicUsersPanelVM);

            administratorManageBasicUsersPanel.Show();
            this.Hide();
        }

        private void CashWithdrawalStateButton_Click(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // Safe logout
            this.loginPanel.Show();
            this.Dispose();
        }
    }
}
