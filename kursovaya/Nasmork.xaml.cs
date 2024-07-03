using kursovaya.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Nasmork.xaml
    /// </summary>
    public partial class Nasmork : Window
    {
		DataBase dataBase = new DataBase();
		public Nasmork()
        {
            InitializeComponent();
			ObnovZagr();
		}
		private void ObnovZagr()
		{
			if (CurrentUser.User != null)
			{
				user.Visibility = Visibility.Visible;
				korzinaButton.Visibility = Visibility.Visible;

			}
			else
			{
				user.Visibility = Visibility.Collapsed;
				korzinaButton.Visibility = Visibility.Collapsed;
			}
		}


		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MinimizeWindow(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MaximizeWindow(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
				WindowState = WindowState.Normal;
			else
				WindowState = WindowState.Maximized;
		}

		private void home_Click(object sender, RoutedEventArgs e)
		{
			MainWindow home = new MainWindow();
			home.Show();
			Close();
		}
		private void korzinaButton_Click(object sender, RoutedEventArgs e)
		{
			Korzina korzina = new Korzina();
			korzina.Show();
			Close();
		}


		private void akcii_Click(object sender, RoutedEventArgs e)
		{
			Akcii akcii = new Akcii();
			akcii.Show();
			Close();
		}

		private void drugs_Click(object sender, RoutedEventArgs e)
		{
			Drugs drugs = new Drugs();
			drugs.Show();
			Close();
		}

		private void aptechka_Click(object sender, RoutedEventArgs e)
		{
			Aptechka aptechka = new Aptechka();
			aptechka.Show();
			Close();
		}

		private void bad_Click(object sender, RoutedEventArgs e)
		{
			Bad bad = new Bad();
			bad.Show();
			Close();
		}

		private void medtech_Click(object sender, RoutedEventArgs e)
		{
			MedTech medtech = new MedTech();
			medtech.Show(); Close();
			Close();
		}

		private void optica_Click(object sender, RoutedEventArgs e)
		{
			Optica optica = new Optica();
			optica.Show();
			Close();

		}

		private void kosm_Click(object sender, RoutedEventArgs e)
		{
			Kosm kosm = new Kosm();
			kosm.Show();
			Close();

		}

		private void momandbaby_Click(object sender, RoutedEventArgs e)
		{
			MomandBaby momandBaby = new MomandBaby();
			momandBaby.Show();
			Close();
		}
		private void user_Click(object sender, RoutedEventArgs e)
		{
			User user = new User();
			user.Show();
			Close();
		}
		private void vKorzinu_Click(object sender, RoutedEventArgs e)
		{
			if (CurrentUser.User == null)
			{
				CustomMessageBox.ShowMessage("Авторизуйтесь!", "Ошибка!");
				return;
			}

			var button = sender as Button;
			if (button == null)
			{
				CustomMessageBox.ShowMessage("Не удалось получить информацию о кнопке.", "Ошибка!");
				return;
			}

			var medication = button.DataContext as MedicationRepository.Medication;
			if (medication == null)
			{
				CustomMessageBox.ShowMessage("Не удалось получить информацию о товаре.", "Ошибка!");
				return;
			}

			var userId = CurrentUser.User.Id;

			// Определяем, какую цену использовать
			decimal priceToUse = medication.Akcii ? medication.Twoprice : medication.Price;

			// Проверка, существует ли товар в корзине для данного пользователя
			bool itemExistsInCart = false;
			int cartItemId = 0;
			string checkQuery = "SELECT KorzinaID, Quantity FROM korzina WHERE UserId = @userId AND MedicationID = @medicationId";
			using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
			{
				SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
				checkCommand.Parameters.AddWithValue("@userId", userId);
				checkCommand.Parameters.AddWithValue("@medicationId", medication.Id);
				connection.Open();
				SqlDataReader reader = checkCommand.ExecuteReader();
				if (reader.Read())
				{
					itemExistsInCart = true;
					cartItemId = (int)reader["KorzinaID"];
				}
				reader.Close();
			}

			// Если товар существует, обновляем количество; иначе, вставляем новую запись
			if (itemExistsInCart)
			{
				// Обновляем количество в базе данных
				int newQuantity = GetCartItemQuantity(cartItemId) + 1;
				dataBase.UpdateCartItemQuantity(cartItemId, newQuantity);
				CustomMessageBox.ShowMessage("Товар добавлен!", "Отлично!");
			}
			else
			{
				// Вставляем новый товар в корзину
				string insertQuery = "INSERT INTO korzina (UserId, MedicationID, Quantity, Price, Foto) " +
									 "VALUES (@userId, @medicationId, @quantity, @price, @foto)";
				try
				{
					using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
					{
						SqlCommand command = new SqlCommand(insertQuery, connection);
						command.Parameters.AddWithValue("@userId", userId);
						command.Parameters.AddWithValue("@medicationId", medication.Id);
						command.Parameters.AddWithValue("@quantity", 1); // Начальное количество равно 1
						command.Parameters.AddWithValue("@price", priceToUse);
						command.Parameters.AddWithValue("@foto", medication.Foto);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							CustomMessageBox.ShowMessage("Товар добавлен!", "Отлично!");
						}
						else
						{
							CustomMessageBox.ShowMessage("Не удалось добавить товар в корзину.", "Ошибка!");
						}
					}
				}
				catch (Exception ex)
				{
					CustomMessageBox.ShowMessage($"Ошибка при добавлении в корзину: {ex.Message}", "Ошибка");
				}
			}
		}

		private int GetCartItemQuantity(int cartItemId)
		{
			// Метод для получения количества товара в корзине по идентификатору товара
			string query = "SELECT Quantity FROM korzina WHERE KorzinaID = @cartItemId";
			using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@cartItemId", cartItemId);
				connection.Open();
				return (int)command.ExecuteScalar();
			}
		}




		private void detailsButton_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				MedicationRepository.Medication medication = button.DataContext as MedicationRepository.Medication;
				if (medication != null)
				{
					MedicationDetailsWindow detailsWindow = new MedicationDetailsWindow(medication.Opisanie);
					detailsWindow.ShowDialog();
				}
			}
		}
	}
}
