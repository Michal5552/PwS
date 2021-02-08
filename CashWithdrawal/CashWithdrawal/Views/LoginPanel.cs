using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;

using cashDispenserLibrary.Model.MockAdministratorsRepository;
using cashDispenserLibrary.Model.MockAdministratorsRepository.Exceptions;

using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;

using CashWithdrawal.ViewModels;
using CashWithdrawal.Views;

namespace CashWithdrawal
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();

            // Set System Settings
            SystemSettings._PlatformType = PlatformType.Windows;

            // Set Pin Code TextBox
            this.PinCodeTextBox.PasswordChar = '*';

            // Set Error Label
            this.ErrorLabel.Hide();
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.PinCodeTextBox.Clear();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            // Pin Code
            PinVAL pinCode = null;

            // Validate Pin Code
            try
            {
                pinCode = new PinVAL(PinCodeTextBox.Text);
            }
            catch (PinVAL_Exception p_e)
            {
                ErrorLabel.Show();
                ErrorLabel.Text = p_e.What();
            }

            // Login basic user
            if (pinCode._Value.Length == 4)
            {
                try
                {
                    // Connect with basic users database
                    MockBasicUsersRepository mockBasicUsersRepository =
                        new MockBasicUsersRepository(SystemSettings._PlatformType);

                    // Get information about basic user with respectively pin code
                    // from database
                    BasicUserPanelVM basicUserPanelVM = new BasicUserPanelVM
                    {
                        basicUser = mockBasicUsersRepository.GetAll().FirstOrDefault(
                            (singleBasicUser) => singleBasicUser._Pin._Value == pinCode._Value)
                    };

                    // Redirect to Basic User Panel
                    basicUserPanelVM.loginPanel = this;

                    BasicUserPanel basicUserPanel = new BasicUserPanel(basicUserPanelVM);
                    
                    basicUserPanel.Show();
                    this.Hide();
                }
                catch (MockBasicUsersRepository_Exception mbur_e)
                {
                    ErrorLabel.Text = mbur_e.What();
                }
            }
            // Login administrator
            else if (pinCode._Value.Length == 6)
            {
                try
                {
                    // Connect with administrators database
                    MockAdministratorsRepository mockAdministratorsRepository =
                        new MockAdministratorsRepository(SystemSettings._PlatformType);

                    // Get information about administrator with respectively pin code
                    // from database
                    AdministratorPanelVM administratorPanelVM = new AdministratorPanelVM
                    {
                        administrator = mockAdministratorsRepository.GetAll().
                        FirstOrDefault((singleAdministrator) =>
                        singleAdministrator._Pin._Value == pinCode._Value)
                    };

                    // Redirect to administrator panel
                    administratorPanelVM.loginPanel = this;

                    AdministratorPanel administratorPanel =
                        new AdministratorPanel(administratorPanelVM);
                    
                    administratorPanel.Show();
                    this.Hide();
                }
                catch (MockAdministratorsRepository_Exception mar_e)
                {
                    ErrorLabel.Text = mar_e.What();
                }

            }
        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }
    }
}