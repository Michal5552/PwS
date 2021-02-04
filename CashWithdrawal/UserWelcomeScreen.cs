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

namespace CashWithdrawal
{
	public partial class Basic_user_operation_window : Form
	{
		public static BasicUser basicUser = null;
		public Basic_user_operation_window()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void Account_balance_button_Click(object sender, EventArgs e)
		{
			Hide();
			Balance_window balance_Window = new Balance_window();
			balance_Window.Show();

		}

		private void operation_window_Load(object sender, EventArgs e)
		{

		}

		private void Withdraw_button_Click(object sender, EventArgs e)
		{

		}

		private void Deposit_button_Click(object sender, EventArgs e)
		{

		}
	}
}
