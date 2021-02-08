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

        public AdministratorPanel()
        {
            InitializeComponent();
        }

        public AdministratorPanel(AdministratorPanelVM administratorPanelVM)
        {
            InitializeComponent();

            // Set information about login panel
            loginPanel = administratorPanelVM.loginPanel;

            // Set administrator data
            this.administrator = administratorPanelVM.administrator;

            // Show basic user information
            AdministratorInformationLabel.Text =
                (administrator._Name._Value + administrator._Surname._Value);
        }
    }
}
