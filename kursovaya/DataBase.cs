using kursovaya.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace kursovaya
{
    public class DataBase
    {
        private string connectionString = @"Data Source=DESKTOP-AOF7V3Q;Initial Catalog=MedDB;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-AOF7V3Q;Initial Catalog=MedDB;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getSqlConnection()
        {
            return sqlConnection;
        }

        public string getStringConnection()
        {
            return connectionString;
        }

		// Method to get cart items from the database
		public List<CartItemModel> GetCartItems(int userId)
		{
			List<CartItemModel> cartItems = new List<CartItemModel>();

			string query = @"
        SELECT k.KorzinaID, k.UserId, k.MedicationID, k.Quantity, k.Price, k.Foto, t.Name
        FROM korzina k
        INNER JOIN tabletkadb t ON k.MedicationID = t.id
        WHERE k.UserId = @UserId";

			SqlCommand command = new SqlCommand(query, sqlConnection);
			command.Parameters.AddWithValue("@UserId", userId);

			openConnection();
			SqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				CartItemModel item = new CartItemModel
				{
					Id = (int)reader["KorzinaID"],
					UserId = (int)reader["UserId"],
					ProductId = (int)reader["MedicationID"],
					Quantity = (int)reader["Quantity"],
					Price = (decimal)reader["Price"],
					Foto = reader["Foto"].ToString(),
					Name = (string)reader["Name"]
				};

				cartItems.Add(item);
			}

			reader.Close(); // Закрываем reader после использования
			closeConnection();

			return cartItems;
		}



		// Method to update cart item quantity
		public void UpdateCartItemQuantity(int itemId, int quantity)
        {
            string query = "UPDATE korzina SET Quantity = @Quantity WHERE KorzinaID = @KorzinaID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@KorzinaID", itemId);

            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        // Method to delete cart item
        public void DeleteCartItem(int itemId)
        {
            string query = "DELETE FROM korzina WHERE KorzinaID = @KorzinaID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@KorzinaID", itemId);

            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

		private static readonly List<string> Medications = new List<string>
		{
			"Aspirin", "Paracetamol", "Ibuprofen", "Amoxicillin", "Metformin", "Amlodipine", "Omeprazole"
		};

		public static IEnumerable<string> SearchMedications(string searchText)
		{
			if (string.IsNullOrEmpty(searchText))
				return Medications;

			return Medications.Where(m => m.Contains(searchText, StringComparison.OrdinalIgnoreCase));
		}
	}
}
