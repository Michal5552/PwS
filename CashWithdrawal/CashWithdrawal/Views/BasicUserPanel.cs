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

        public BasicUserPanel()
        {
            InitializeComponent();
        }

        public BasicUserPanel(BasicUserPanelVM basicUserPanelVM)
        {
            InitializeComponent();

            // Set information about login panel
            loginPanel = basicUserPanelVM.loginPanel;

            // Set basic user data
            this.basicUser = basicUserPanelVM.basicUser;

            // Show basic user information
            BasicUserInformationLabel.Text =
                (basicUser._Name._Value + basicUser._Surname._Value);
        }
    }
}
