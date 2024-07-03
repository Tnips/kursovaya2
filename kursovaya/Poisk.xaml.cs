using kursovaya.Models;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace kursovaya
{
	public partial class Poisk : Window
	{
		private readonly DataBase dataBase = new DataBase();

		public Poisk()
		{
			InitializeComponent();
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
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

		private void vKorzinu_Click(object sender, RoutedEventArgs e)
		{
			if (CurrentUser.User == null)
			{
				MessageBox.Show("Авторизуйтесь!", "Ошибка!", MessageBoxButton.OK);
				return;
			}

			var button = sender as Button;
			if (button == null)
			{
				MessageBox.Show("Не удалось получить информацию о кнопке.", "Ошибка!", MessageBoxButton.OK);
				return;
			}

			var medication = button.DataContext as MedicationRepository.Medication;
			if (medication == null)
			{
				MessageBox.Show("Не удалось получить информацию о товаре.", "Ошибка!", MessageBoxButton.OK);
				return;
			}

			var userId = CurrentUser.User.Id;

			decimal priceToUse = medication.Akcii ? medication.Twoprice : medication.Price;

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

			if (itemExistsInCart)
			{
				int newQuantity = GetCartItemQuantity(cartItemId) + 1;
				dataBase.UpdateCartItemQuantity(cartItemId, newQuantity);
				MessageBox.Show("Товар добавлен!", "Отлично!", MessageBoxButton.OK);
			}
			else
			{
				string insertQuery = "INSERT INTO korzina (UserId, MedicationID, Quantity, Price, Foto) " +
									 "VALUES (@userId, @medicationId, @quantity, @price, @foto)";
				try
				{
					using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
					{
						SqlCommand command = new SqlCommand(insertQuery, connection);
						command.Parameters.AddWithValue("@userId", userId);
						command.Parameters.AddWithValue("@medicationId", medication.Id);
						command.Parameters.AddWithValue("@quantity", 1);
						command.Parameters.AddWithValue("@price", priceToUse);
						command.Parameters.AddWithValue("@foto", medication.Foto);

						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show("Товар добавлен!", "Отлично!", MessageBoxButton.OK);
						}
						else
						{
							MessageBox.Show("Не удалось добавить товар в корзину.", "Ошибка!", MessageBoxButton.OK);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при добавлении в корзину: {ex.Message}", "Ошибка", MessageBoxButton.OK);
				}
			}
		}

		private int GetCartItemQuantity(int cartItemId)
		{
			string query = "SELECT Quantity FROM korzina WHERE KorzinaID = @cartItemId";
			using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@cartItemId", cartItemId);
				connection.Open();
				return (int)command.ExecuteScalar();
			}
		}
	}
}
