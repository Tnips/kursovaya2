using System;
using System.Linq;
using System.Windows;
using kursovaya.Models;

namespace kursovaya
{
	/// <summary>
	/// Логика взаимодействия для AdminPanel.xaml
	/// </summary>
	public partial class AdminPanel : Window
	{
		private DataBase dataBase;

		public AdminPanel()
		{
			InitializeComponent();
			dataBase = new DataBase();
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MinimizeWindow(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			if (!ValidateFields())
			{
				return;
			}

			string typeOf = TypeOfComboBox.Text;
			decimal price = decimal.Parse(PriceTextBox.Text);
			string forWhat = ForWhatComboBox.Text;
			string opisanie = OpisanieTextBox.Text;
			string foto = FotoTextBox.Text;
			string name = NameTextBox.Text;
			decimal twoPrice = decimal.Parse(TwoPriceTextBox.Text);
			string akcii = AkciiComboBox.Text;

			dataBase.AddItem(typeOf, price, forWhat, opisanie, foto, name, twoPrice, akcii);
			CustomMessageBox.ShowMessage("Товар добавлен успешно!", "Успех");
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			string name = DeleteNameTextBox.Text;
			dataBase.DeleteItem(name);
			CustomMessageBox.ShowMessage("Товар удалён успешно!", "Успех");
		}

		private void Logout_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

		private bool ValidateFields()
		{
			if (string.IsNullOrWhiteSpace(TypeOfComboBox.Text) || string.IsNullOrWhiteSpace(ForWhatComboBox.Text) || string.IsNullOrWhiteSpace(AkciiComboBox.Text))
			{
				CustomMessageBox.ShowMessage("Выберите параметры для всех полей.", "Ошибка валидации");
				return false;
			}

			if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0 || price >= 10000)
			{
				CustomMessageBox.ShowMessage("Цена должна быть положительнойр(=<4)", "Ошибка валидации");
				return false;
			}

			if (!decimal.TryParse(TwoPriceTextBox.Text, out decimal twoPrice) || (AkciiComboBox.SelectedIndex == 1 && (twoPrice <= 0 || twoPrice >= 10000)))
			{
				CustomMessageBox.ShowMessage("Цена должна быть положительной(=<4)", "Ошибка валидации");
				return false;
			}

			if (string.IsNullOrWhiteSpace(OpisanieTextBox.Text) || string.IsNullOrWhiteSpace(FotoTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text))
			{
				CustomMessageBox.ShowMessage("Заполните все текстовые поля.", "Ошибка валидации");
				return false;
			}

			return true;
		}

		private void AddItemButton_Click(object sender, RoutedEventArgs e)
		{
			// Show Add/Edit panel, hide Delete panel
			AddEditPanel.Visibility = Visibility.Visible;
			DeletePanel.Visibility = Visibility.Collapsed;
			AddButton.Content = "Добавить"; // Set button text
		}

		private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
		{
			// Show Delete panel, hide Add/Edit panel
			DeletePanel.Visibility = Visibility.Visible;
			AddEditPanel.Visibility = Visibility.Collapsed;
			DeleteButton.Content = "Удалить"; // Set button text
		}
	}
}
