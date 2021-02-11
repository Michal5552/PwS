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

            // Set autoincrement value
            try
            {
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(SystemSettings._PlatformType);

                User._Id_counter = (mockBasicUsersRepository.GetAll().Last()._Id + 1);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
            }

            // Set Pin Code TextBox
            this.PinCodeTextBox.PasswordChar = '*';

            // Set Error Label
            this.ErrorLabel.Hide();
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
                ErrorLabel.Text = p_e.What();
                ErrorLabel.Show();
            }

            if (pinCode != null)
            {
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

                        // Check basic user's find result
                        if (basicUserPanelVM.basicUser != null)
                        {
                            // Redirect to Basic User Panel
                            basicUserPanelVM.loginPanel = this;

                            BasicUserPanel basicUserPanel = new BasicUserPanel(basicUserPanelVM);

                            this.PinCodeTextBox.Clear();
                            this.ErrorLabel.Hide();
                            basicUserPanel.Show();
                            this.Hide();
                        }
                        else
                        {
                            ErrorLabel.Text = "!!! Użytkownik O Podanym Pinie Nie Istnieje !!!";
                            ErrorLabel.Show();
                        }
                    }
                    catch (MockBasicUsersRepository_Exception mbur_e)
                    {
                        ErrorLabel.Text = mbur_e.What();
                        ErrorLabel.Show();
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

                        // Check administrator's find result
                        if (administratorPanelVM.administrator != null)
                        {
                            // Redirect to administrator panel
                            administratorPanelVM.loginPanel = this;

                            AdministratorPanel administratorPanel =
                                new AdministratorPanel(administratorPanelVM);

                            this.PinCodeTextBox.Clear();
                            this.ErrorLabel.Hide();
                            administratorPanel.Show();
                            this.Hide();
                        }
                        else
                        {
                            ErrorLabel.Text = "!!! Użytkownik O Podanym Pinie Nie Istnieje !!!";
                            ErrorLabel.Show();
                        }
                    }
                    catch (MockAdministratorsRepository_Exception mar_e)
                    {
                        ErrorLabel.Text = mar_e.What();
                        ErrorLabel.Show();
                    }

                }
            }
        }
    }
}