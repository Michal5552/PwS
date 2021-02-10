using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using CashWithdrawal.Data;
using CashWithdrawal.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class AdministratorManageBasicUsersPanel : Form
    {
        private LoginPanel loginPanel;
        private AdministratorPanel administratorPanel;
        private Administrator administrator;

        private BasicUser selectedBasicUsersDataGridViewRow;

        public AdministratorManageBasicUsersPanel(
            AdministratorManageBasicUsersPanelVM administratorManageBasicUsersPanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = administratorManageBasicUsersPanelVM.loginPanel;

            // Set administrator panel information
            this.administratorPanel = administratorManageBasicUsersPanelVM.administratorPanel;

            // Set administrator information
            this.administrator = administratorManageBasicUsersPanelVM.administrator;

            // Set selected basic users data grid view row
            try
            {
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(SystemSettings._PlatformType);

                this.selectedBasicUsersDataGridViewRow =
                    mockBasicUsersRepository.GetAll().First();
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
            }

            // Set grid view information
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository = new
                MockBasicUsersRepository(SystemSettings._PlatformType);

                // Get basic users
                var basicUsersDataGridViewModels =
                    mockBasicUsersRepository.GetAll().Select((singleBasicUser) =>
                    {
                        return new BasicUsersDataGridViewModel
                        {
                            BasicUserId = singleBasicUser._Id,
                            accountState = singleBasicUser._BankAccount.state._Value,
                            pin = singleBasicUser._Pin._Value,
                            name = singleBasicUser._Name._Value,
                            surname = singleBasicUser._Surname._Value
                        };
                    }).ToList();

                this.BasicUsersDataGridView.DataSource = basicUsersDataGridViewModels;
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {

            }

            // Set column headers names
            this.BasicUsersDataGridView.Columns[0].HeaderText = "Id";
            this.BasicUsersDataGridView.Columns[0].Visible = false;
            this.BasicUsersDataGridView.Columns[1].HeaderText = "Stan konta";
            this.BasicUsersDataGridView.Columns[2].HeaderText = "Pin";
            this.BasicUsersDataGridView.Columns[3].HeaderText = "Imię";
            this.BasicUsersDataGridView.Columns[4].HeaderText = "Nazwisko";

            // Show administration information
            this.AdministratorInformationLabel.Text = ("Zalogowano jako :"
                + $"{this.administrator._Name._Value} {this.administrator._Surname._Value}");

            // Center basic user data grid view columns headers
            foreach (DataGridViewColumn basicUsersDataGridViewColumn in
                this.BasicUsersDataGridView.Columns)
            {
                basicUsersDataGridViewColumn.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void ManageBasicUsersPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close
            this.Dispose();
            this.administratorPanel.Dispose();
            this.loginPanel.Close();
        }
        private void BasicUsersDataGridView_Click(object sender, System.EventArgs e)
        {
            int selectedBasicUserRow = 0;

            Int32 selectedRowCount =
                this.BasicUsersDataGridView.Rows.GetRowCount(
                    DataGridViewElementStates.Selected);

            // TODO Get selected basic User id
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; ++i)
                {
                    selectedBasicUserRow =
                        (this.BasicUsersDataGridView.SelectedRows[i].Index);
                }
            }

            // get selected basic user's informations
            this.selectedBasicUsersDataGridViewRow = new BasicUser(
                id: int.Parse(
                this.BasicUsersDataGridView
                    .Rows[selectedBasicUserRow].Cells[0].Value.ToString()),
                pin: new PinVAL(value: this.BasicUsersDataGridView
                .Rows[selectedBasicUserRow].Cells[2].Value.ToString()),
                name: new NameVAL(value: this.BasicUsersDataGridView
            .Rows[selectedBasicUserRow].Cells[3].Value.ToString()),
                surname: new SurnameVAL(value: this.BasicUsersDataGridView
            .Rows[selectedBasicUserRow].Cells[4].Value.ToString()),
                bankAccount: new BankAccount(state: new MoneyVAL(
                    value: decimal.Parse(this.BasicUsersDataGridView
                    .Rows[selectedBasicUserRow].Cells[1].Value.ToString(),
                    CultureInfo.InvariantCulture), currency: Currency.PLN)));
        }

        private void AddBasicUserButton_Click(object sender, System.EventArgs e)
        {
            // Redirect to add basic user panel
            AdministratorAddBasicUserPanel administratorAddBasicUserPanel =
                new AdministratorAddBasicUserPanel();

            administratorAddBasicUserPanel.ShowDialog();

            // Update grid view information
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository = new
                MockBasicUsersRepository(SystemSettings._PlatformType);

                // Get basic users
                var basicUsersDataGridViewModels =
                    mockBasicUsersRepository.GetAll().Select((singleBasicUser) =>
                    {
                        return new BasicUsersDataGridViewModel
                        {
                            BasicUserId = singleBasicUser._Id,
                            accountState = singleBasicUser._BankAccount.state._Value,
                            pin = singleBasicUser._Pin._Value,
                            name = singleBasicUser._Name._Value,
                            surname = singleBasicUser._Surname._Value
                        };
                    }).ToList();

                this.BasicUsersDataGridView.DataSource = basicUsersDataGridViewModels;
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {

            }
        }

        private void UpdateBasicUserButton_Click(object sender, System.EventArgs e)
        {
            // Get checked basic user
            DataGridViewRow basicUsersDataGridViewRow = this.BasicUsersDataGridView.CurrentRow;

            // Redirect to change basic user panel
            AdministratorUpdateBasicUserPanelVM administratorUpdateBasicUserPanelVM =
                new AdministratorUpdateBasicUserPanelVM
                {
                    basicUser = this.selectedBasicUsersDataGridViewRow
                };

            AdministratorUpdateBasicUserPanel administratorUpdateBasicUserPanel =
                new AdministratorUpdateBasicUserPanel(
                    administratorUpdateBasicUserPanelVM);

            administratorUpdateBasicUserPanel.ShowDialog();

            // Update grid view information
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository = new
                MockBasicUsersRepository(SystemSettings._PlatformType);

                // Get basic users
                var basicUsersDataGridViewModels =
                    mockBasicUsersRepository.GetAll().Select((singleBasicUser) =>
                    {
                        return new BasicUsersDataGridViewModel
                        {
                            BasicUserId = singleBasicUser._Id,
                            accountState = singleBasicUser._BankAccount.state._Value,
                            pin = singleBasicUser._Pin._Value,
                            name = singleBasicUser._Name._Value,
                            surname = singleBasicUser._Surname._Value
                        };
                    }).ToList();

                this.BasicUsersDataGridView.DataSource = basicUsersDataGridViewModels;
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {

            }
        }

        private void RemoveBasicUserButton_Click(object sender, System.EventArgs e)
        {
            AdministratorRemoveBasicUserPanelVM administratorRemoveBasicUserPanelVM =
                new AdministratorRemoveBasicUserPanelVM
                {
                    basicUserToRemove = this.selectedBasicUsersDataGridViewRow
                };

            // Redirect to remove basic user panel
            AdministratorRemoveBasicUserPanel administratorRemoveBasicUserPanel =
                new AdministratorRemoveBasicUserPanel(administratorRemoveBasicUserPanelVM);

            administratorRemoveBasicUserPanel.ShowDialog();

            // Get checked basic user
            DataGridViewRow basicUsersDataGridViewRow = this.BasicUsersDataGridView.CurrentRow;

            // Redirect to change basic user panel
            AdministratorUpdateBasicUserPanelVM administratorUpdateBasicUserPanelVM =
                new AdministratorUpdateBasicUserPanelVM
                {
                    basicUser = this.selectedBasicUsersDataGridViewRow
                };

            // Update grid view information
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository = new
                MockBasicUsersRepository(SystemSettings._PlatformType);

                // Get basic users
                var basicUsersDataGridViewModels =
                    mockBasicUsersRepository.GetAll().Select((singleBasicUser) =>
                    {
                        return new BasicUsersDataGridViewModel
                        {
                            BasicUserId = singleBasicUser._Id,
                            accountState = singleBasicUser._BankAccount.state._Value,
                            pin = singleBasicUser._Pin._Value,
                            name = singleBasicUser._Name._Value,
                            surname = singleBasicUser._Surname._Value
                        };
                    }).ToList();

                this.BasicUsersDataGridView.DataSource = basicUsersDataGridViewModels;
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {

            }
        }

        private void ExitToAdministratorPanelButton_Click(object sender, System.EventArgs e)
        {
            // Safe close
            this.administratorPanel.Show();
            this.Dispose();
        }
    }
}
