using System;
using System.Data.SqlClient;
using System.Windows;

namespace kursovaya
{
	public class CartRepository
	{
		private string connectionString = @"Data Source=DESKTOP-AOF7V3Q;Initial Catalog=MedDB;Integrated Security=True";

		public void AddToCart(Medication medication, int userId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = "INSERT INTO korzina (id_user, name, price, quantity) VALUES (@id_user, @name, @price, @quantity)";
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@id_user", userId);
					command.Parameters.AddWithValue("@name", medication.Name);
					command.Parameters.AddWithValue("@price", medication.Price);
					command.Parameters.AddWithValue("@quantity", 1); // Пример начального количества

					connection.Open();
					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при добавлении в корзину: {ex.Message}");
			}
		}

		// Другие методы для работы с корзиной могут быть добавлены здесь (удаление, изменение количества и т.д.)
	}
}
