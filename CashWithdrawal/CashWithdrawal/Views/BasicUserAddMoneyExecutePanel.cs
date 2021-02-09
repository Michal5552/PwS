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
    public partial class BasicUserAddMoneyExecutePanel : Form
    {
        public BasicUserAddMoneyExecutePanel()
        {
            InitializeComponent();

            // Set add money result information
            this.AddMoneyResultLabel.Text = "Transakcja Przeprowadzona Pomyślnie";
        }

        private void ExitToBasicUserAddMoneyPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
