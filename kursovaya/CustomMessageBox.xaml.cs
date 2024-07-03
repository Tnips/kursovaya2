using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovaya
{
	/// <summary>
	/// Логика взаимодействия для CustomMessageBox.xaml
	/// </summary>
	public partial class CustomMessageBox : Window
	{
		public CustomMessageBox(string message, string title)
		{
			InitializeComponent();
			MessageTextBlock.Text = message;
			TitleTextBlock.Text = title;
		}

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
			this.Close();
		}

		public static void ShowMessage(string message, string title)
		{
			var customMessageBox = new CustomMessageBox(message, title);
			customMessageBox.ShowDialog();
		}
	}

}

