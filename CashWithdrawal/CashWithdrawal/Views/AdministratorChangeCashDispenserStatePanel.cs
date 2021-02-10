using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;
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
    public partial class AdministratorChangeCashDispenserStatePanel : Form
    {
        private LoginPanel loginPanel;
        private AdministratorPanel administratorPanel;
        private AdministratorCashDispenserStatePanel administratorCashDispenserStatePanel;
        private decimal cashDispenserStateInPln;

        public AdministratorChangeCashDispenserStatePanel(
            AdministratorChangeCashDispenserStatePanelVM
            administratorChangeCashDispenserStatePanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = administratorChangeCashDispenserStatePanelVM.loginPanel;

            // Set administrator panel information
            this.administratorPanel =
                administratorChangeCashDispenserStatePanelVM.AdministratorPanel;

            // Set administrator cash dispenser state panel
            this.administratorCashDispenserStatePanel =
                administratorChangeCashDispenserStatePanelVM.administratorCashDispenserStatePanel;

            // Set cash dispenser state in Pln currency
            this.cashDispenserStateInPln =
                administratorChangeCashDispenserStatePanelVM
                .cashDispenserStateInPlnCurrency;

            // Show cash dispenser state
            this.CashDispenserStateValueLabel.Text =
                (String.Format("{0:0.00}", this.cashDispenserStateInPln));

            // Hide error label
            this.ErrorLabel.Visible = false;
        }
        private void AdministratorChangeCashDispenserStatePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close
            this.Dispose();
            this.administratorCashDispenserStatePanel.Dispose();
            this.administratorPanel.Dispose();
            this.loginPanel.Close();
        }
        private void ExitToChangeCashDispenserPanelButton_Click(object sender, EventArgs e)
        {
            // Redirect to administrator change cash dispenser panel

            this.administratorCashDispenserStatePanel.Show();
            this.Dispose();
        }
        private void ChangeCashDispenserStateButton_Click(object sender, EventArgs e)
        {
            // Connect with database
            try
            {
                MockPhysicalMoneyRepository mockPhysicalMoneyRepository = new
                    MockPhysicalMoneyRepository(SystemSettings._PlatformType);

                // Update cash dispenser state
                mockPhysicalMoneyRepository.UpdateInCurrency(
                    currencyRate: CashWithdrawalProperties.exchangeRates.PLN_exchangeRate,
                    physicalMoneyVAL: new PhysicalMoneyVAL(
                        value: decimal.Parse(this.ChangeCashDispenserValueValueTextBox.Text,
                        CultureInfo.InvariantCulture), currency: Currency.PLN));

                // Redirect to administrator change cash dispenser state result panel
                AdministratorChangeCashDispenserStateResultPanel
                    administratorChangeCashDispenserStateResultPanel = new
                    AdministratorChangeCashDispenserStateResultPanel();

                administratorChangeCashDispenserStateResultPanel.ShowDialog();

                // Update local cash dispenser state
                this.cashDispenserStateInPln =
                    mockPhysicalMoneyRepository.GetInCurrency(
                        currencyRate: CashWithdrawalProperties
                        .exchangeRates.PLN_exchangeRate, currency: Currency.PLN)._Value;

                // Show cash dispenser state after change
                this.CashDispenserStateValueLabel.Text =
                    (String.Format("{0:0.00}", this.cashDispenserStateInPln));
            }
            catch (MockPhysicalMoneyRepository_Exception mpmr_e)
            {
                this.ErrorLabel.Text = mpmr_e.What();
                this.ErrorLabel.Show();
            }
            catch (PhysicalMoneyVAL_Exception pm_e)
            {
                this.ErrorLabel.Text = pm_e.What();
                this.ErrorLabel.Show();
            }
        }
    }
}
