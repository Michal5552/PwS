using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
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
    public partial class AdministratorRemoveBasicUserPanel : Form
    {
        private BasicUser basicUserToRemove;

        public AdministratorRemoveBasicUserPanel(
            AdministratorRemoveBasicUserPanelVM administratorRemoveBasicUserPanelVM)
        {
            InitializeComponent();

            // Set basic user to remove information
            this.basicUserToRemove =
                administratorRemoveBasicUserPanelVM.basicUserToRemove;

            // Show remove basic user statement
            this.RemoveBasicUserStatementLabel.Text =
                $"Czy Na Pewno Chcesz Usunąć Użytkownika: " +
                $"{this.basicUserToRemove._Pin._Value}";
        }

        private void AcceptRemoveBasicUserButton_Click(object sender, EventArgs e)
        {
            // Remove respectively basic user from database
            try
            {
                // Connect with database
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(
                        platformType: SystemSettings._PlatformType);

                mockBasicUsersRepository.Remove(basicUserId: this.basicUserToRemove._Id);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
            }

            // Redirect to administrator remove basic user result panel
            AdministratorRemoveBasicUserResultPanel
                administratorRemoveBasicUserResultPanel =
                new AdministratorRemoveBasicUserResultPanel();

            administratorRemoveBasicUserResultPanel.ShowDialog();

            this.Close();
        }

        private void DropRemoveBasicUserButton_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }
    }
}
