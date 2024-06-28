using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;


namespace kursovaya
{
	public class MedicationRepository : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<Medication> medications;
		public ObservableCollection<Medication> Medications
		{
			get { return medications; }
			set
			{
				medications = value;
				OnPropertyChanged(nameof(Medications));
			}
		}

		private string connectionString = @"Data Source=DESKTOP-AOF7V3Q;Initial Catalog=MedDB;Integrated Security=True";

		public MedicationRepository()
		{
			Medications = GetMedications();
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ObservableCollection<Medication> GetMedications()
		{
			ObservableCollection<Medication> medications = new ObservableCollection<Medication>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Измененный SQL запрос, чтобы выбрать 'name' вместо 'type_of'
					string query = "SELECT name, price, for_what, opisanie, foto FROM tabletkadb WHERE type_of = 'Лекарственные препараты'";
					SqlCommand command = new SqlCommand(query, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Medication medication = new Medication
						{
							// Используем 'name' вместо 'type_of'
							Name = reader["name"].ToString(),
							Price = Convert.ToDecimal(reader["price"]),
							ForWhat = reader["for_what"].ToString(),
							Foto = reader["foto"].ToString(),
							Opisanie = reader["opisanie"].ToString()

						};

						medications.Add(medication);
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}

			return medications;
		}
	}
}
