using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using cashDispenserLibrary.Model.MockAdministratorsRepository;
using cashDispenserLibrary.Model.MockAdministratorsRepository.Exceptions;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;




namespace CashWithdrawal
{
	public partial class Login_window : Form
	{

		private Basic_user_operation_window basic_user_operation_windows;
		public Login_window()
		{

			InitializeComponent();
			error_label.Hide();


		}

		private void Login_window_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			MockBasicUsersRepository mockBasicUsersRepository = null;
			MockAdministratorsRepository mockAdministratorsRepository = null;
			try
			{
				mockBasicUsersRepository = new MockBasicUsersRepository(PlatformType.Windows);
				mockAdministratorsRepository = new MockAdministratorsRepository(PlatformType.Windows);
			}
			catch (MockBasicUsersRepository_Exception ex)
			{

			}
			catch (MockAdministratorsRepository_Exception ex)
			{

			}

			if (pin_text.TextLength == 4)
			{
				BasicUser basicUser = null;
				try
				{

					basicUser = mockBasicUsersRepository.GetAll().FirstOrDefault((singleBasicUser) => singleBasicUser._Pin._Value == pin_text.Text);

				}
				catch (MockBasicUsersRepository_Exception ex)
				{
					int number = 0;
				}
				if (basicUser == null)
				{
					error_label.Text = "User does not exist!";
					error_label.Show();
				}
				else
				{
					
					Basic_user_operation_window.basicUser = basicUser;
					Hide();
					basic_user_operation_windows = new Basic_user_operation_window();
					basic_user_operation_windows.Show();
					
				}


			}
			else if (pin_text.TextLength == 6)
			{
				Administrator administrator = null;
				try
				{

					administrator = mockAdministratorsRepository.GetAll().FirstOrDefault((adminUser) => adminUser._Pin._Value == pin_text.Text);

				}
				catch (MockBasicUsersRepository_Exception ex)
				{
					int number = 0;
				}
				if (administrator == null)
				{
					error_label.Text = "User does not exist!";
					error_label.Show();
				}
				else
				{

					Admin_window.administrator = administrator;
					Hide();
					Admin_window adminWindow = new Admin_window();
					adminWindow.Show();

				}

			}
			else
			{
				error_label.Text = "Wrong pincode!";
				error_label.Show();
			}


		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void error_label_Click(object sender, EventArgs e)
		{

		}
	}
}
