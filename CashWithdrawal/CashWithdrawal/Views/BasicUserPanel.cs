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
    public partial class BasicUserPanel : Form
    {
        private LoginPanel loginPanel;
        private BasicUser basicUser;

        public BasicUserPanel(BasicUserPanelVM basicUserPanelVM)
        {
            InitializeComponent();

            // Set information about login panel
            loginPanel = basicUserPanelVM.loginPanel;

            // Set basic user data
            this.basicUser = basicUserPanelVM.basicUser;

            // Show basic user information
            BasicUserInformationLabel.Text = $"Witaj {basicUser._Name._Value } " +
                $"{basicUser._Surname._Value}";
        }
        private void BasicUserPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close program
            loginPanel.Close();
        }

        private void AddMoneyButton_Click(object sender, EventArgs e)
        {
            // Redirect to add money panel
            BasicUserAddMoneyPanelVM basicUserAddMoneyPanelVM =
                new BasicUserAddMoneyPanelVM
                {
                    loginPanel = loginPanel,
                    basicUserPanel = this,
                    basicUser = basicUser
                };
            BasicUserAddMoneyPanel basicUserAddMoneyPanel =
                new BasicUserAddMoneyPanel(basicUserAddMoneyPanelVM);

            basicUserAddMoneyPanel.Show();
            this.Hide();
        }
        private void BasicUserAccountStateButton_Click(object sender, EventArgs e)
        {
            // Redirect to basic user account state panel
            BasicUserAccountStatePanelVM basicUserAccountStatePanelVM =
                new BasicUserAccountStatePanelVM
                {
                    loginPanel = loginPanel,
                    basicUserPanel = this,
                    basicUser = basicUser
                };

            BasicUserAccountStatePanel basicUserAccountStatePanel =
                new BasicUserAccountStatePanel(basicUserAccountStatePanelVM);

            basicUserAccountStatePanel.Show();
            this.Hide();
        }
        private void TakeOutMoneyButton_Click(object sender, EventArgs e)
        {
            // Redirect to take out money panel
            BasicUserTakeOutMoneyPanelVM basicUserTakeOutMoneyPanelVM =
                new BasicUserTakeOutMoneyPanelVM
                {
                    loginPanel = this.loginPanel,
                    basicUserPanel = this,
                    basicUser = this.basicUser
                };

            BasicUserTakeOutMoneyPanel basicUserTakeOutMoneyPanel =
                new BasicUserTakeOutMoneyPanel(basicUserTakeOutMoneyPanelVM);

            basicUserTakeOutMoneyPanel.Show();
            this.Hide();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {

        }
    }
}
