using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
using CashWithdrawal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class AdministratorUpdateBasicUserPanel : Form
    {
        private BasicUser basicUser;

        public AdministratorUpdateBasicUserPanel(
            AdministratorUpdateBasicUserPanelVM administratorUpdateBasicUserPanelVM)
        {
            InitializeComponent();

            // Set basic user information
            this.basicUser = administratorUpdateBasicUserPanelVM.basicUser;

            // Fill basic user's labels
            this.BasicUserNameValueLabel.Text = basicUser._Name._Value;
            this.BasicUserSurnameValueLabel.Text = basicUser._Surname._Value;
            this.BasicUserPinValueLabel.Text = basicUser._Pin._Value;
            this.BasicUserAccountStateValueLabel.Text =
                basicUser._BankAccount.state._Value.ToString(new CultureInfo("en-US"));

            // Fill update basic user's text boxes
            this.NameValueTextBox.Text = basicUser._Name._Value;
            this.SurnameValueTextBox.Text = basicUser._Surname._Value;
            this.PinValueTextBox.Text = basicUser._Pin._Value;
            this.AccountStateValueTextBox.Text =
                basicUser._BankAccount.state._Value.ToString(new CultureInfo("en-US"));

            // Hide error label
            this.ErrorLabel.Visible = false;
        }

        private void ExitToAdministratorManageBasicUsersButton_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }

        private void UpdateBasicUserButton_Click(object sender, EventArgs e)
        {
            // Get basic user's informations to update
            string basicUserName = this.NameValueTextBox.Text;
            string basicUserSurname = this.SurnameValueTextBox.Text;

            string basicUserPin = this.PinValueTextBox.Text;
            decimal basicUserAccountState =
                ((this.AccountStateValueTextBox.Text.Length > 0) ? decimal.Parse(
                this.AccountStateValueTextBox.Text.Replace(',', '.'),
                CultureInfo.InvariantCulture) : 0.0M);

            // Update basic user
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(SystemSettings._PlatformType);

                // Fill basic user's object new informations
                this.basicUser.ChangeName(name: new NameVAL(
                    value: this.NameValueTextBox.Text));

                this.basicUser.ChangeSurname(surname: new SurnameVAL(
                    value: this.SurnameValueTextBox.Text));

                this.basicUser.ChangePin(pin: new PinVAL(
                    value: this.PinValueTextBox.Text));

                this.basicUser._BankAccount.state.ChangeMoney(
                    moneyVAL: new MoneyVAL(value: decimal.Parse(
                        this.AccountStateValueTextBox.Text, CultureInfo.InvariantCulture),
                        currency: Currency.PLN));

                // Update new basic user's record
                mockBasicUsersRepository.Update(basicUser: this.basicUser);

                // Show update new basic user result
                AdministratorUpdateBasicUserResultPanel
                    administratorUpdateBasicUserResultPanel =
                    new AdministratorUpdateBasicUserResultPanel();

                administratorUpdateBasicUserResultPanel.ShowDialog();
                this.Dispose();
            }
            catch (NameVAL_Exception n_e)
            {
                this.ErrorLabel.Text = n_e.What();
                this.ErrorLabel.Show();
            }
            catch (SurnameVAL_Exception s_e)
            {
                this.ErrorLabel.Text = s_e.What();
                this.ErrorLabel.Show();
            }
            catch (PinVAL_Exception p_e)
            {
                this.ErrorLabel.Text = p_e.What();
                this.ErrorLabel.Show();
            }
            catch (BankAccount_Exception b_e)
            {
                this.ErrorLabel.Text = b_e.What();
                this.ErrorLabel.Show();
            }
            catch (MoneyVAL_Exception m_e)
            {
                this.ErrorLabel.Text = m_e.What();
                this.ErrorLabel.Show();
            }
        }
    }
}
