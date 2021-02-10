using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
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
    public partial class AdministratorAddBasicUserPanel : Form
    {
        public AdministratorAddBasicUserPanel()
        {
            InitializeComponent();

            // Init error label
            this.ErrorLabel.Hide();
        }
        private void ExitToAdministratorManageBasicUsersButton_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }

        private void AddBasicUserButton_Click(object sender, EventArgs e)
        {
            // Get new basic user's informations
            string basicUserName = this.NameValueTextBox.Text;
            string basicUserSurname = this.SurnameValueTextBox.Text;

            string basicUserPin = this.PinValueTextBox.Text;
            decimal basicUserAccountState =
                ((this.AccountStateValueTextBox.Text.Length > 0) ? decimal.Parse(
                this.AccountStateValueTextBox.Text.Replace(',', '.'),
                CultureInfo.InvariantCulture) : 0.0M);

            // Add new basic user
            try
            {
                BasicUser basicUser = new BasicUser(
                    id: -1, name: new NameVAL(value: basicUserName),
                    pin: new PinVAL(value: basicUserPin),
                    surname: new SurnameVAL(value: basicUserSurname),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(value: basicUserAccountState,
                        currency: Currency.PLN)));

                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(SystemSettings._PlatformType);

                // Add new basic user's record
                mockBasicUsersRepository.Add(basicUser: basicUser);

                // Show add new basic user result
                AdministratorAddBasicUserResultPanel
                    administratorAddBasicUserResultPanel =
                    new AdministratorAddBasicUserResultPanel();

                administratorAddBasicUserResultPanel.ShowDialog();
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
