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


namespace CashWithdrawal
{
	public partial class Balance_window : Form
	{
		public Balance_window()
		{
			
			InitializeComponent();
			Balance_amount_label.Text = Basic_user_operation_window.basicUser._BankAccount.state._Value.ToString(new CultureInfo("en-US"));
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void PLN_rb_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void EUR_rb_CheckedChanged(object sender, EventArgs e)
		{
			//Basic_user_operation_window.basicUser._BankAccount.ShowState(Curr())
		}

		private void USD_rb_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void GBP_rb_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
