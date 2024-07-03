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

		private ObservableCollection<Medication> medications1;
		public ObservableCollection<Medication> Medications1
		{
			get { return medications1; }
			set
			{
				medications1 = value;
				OnPropertyChanged(nameof(Medications1));
			}
		}

		private ObservableCollection<Medication> medications2;
		public ObservableCollection<Medication> Medications2
		{
			get { return medications2; }
			set
			{
				medications2 = value;
				OnPropertyChanged(nameof(Medications2));
			}
		}

		private ObservableCollection<Medication> medications3;
		public ObservableCollection<Medication> Medications3
		{
			get { return medications3; }
			set
			{
				medications3 = value;
				OnPropertyChanged(nameof(Medications3));
			}
		}

		private ObservableCollection<Medication> medications4;
		public ObservableCollection<Medication> Medications4
		{
			get { return medications4; }
			set
			{
				medications4 = value;
				OnPropertyChanged(nameof(Medications4));
			}
		}
		private ObservableCollection<Medication> medications5;
		public ObservableCollection<Medication> Medications5
		{
			get { return medications5; }
			set
			{
				medications5 = value;
				OnPropertyChanged(nameof(Medications5));
			}
		}

		private ObservableCollection<Medication> medications6;
		public ObservableCollection<Medication> Medications6
		{
			get { return medications6; }
			set
			{
				medications6 = value;
				OnPropertyChanged(nameof(Medications6));
			}
		}
		private ObservableCollection<Medication> medications7;
		public ObservableCollection<Medication> Medications7
		{
			get { return medications7; }
			set
			{
				medications7 = value;
				OnPropertyChanged(nameof(Medications7));
			}
		}
		private ObservableCollection<Medication> medications8;
		public ObservableCollection<Medication> Medications8
		{
			get { return medications8; }
			set
			{
				medications8 = value;
				OnPropertyChanged(nameof(Medications8));
			}
		}

		private ObservableCollection<Medication> medications9;
		public ObservableCollection<Medication> Medications9
		{
			get { return medications9; }
			set
			{
				medications9 = value;
				OnPropertyChanged(nameof(Medications9));
			}
		}

		private ObservableCollection<Medication> medications10;
		public ObservableCollection<Medication> Medications10
		{
			get { return medications10; }
			set
			{
				medications10 = value;
				OnPropertyChanged(nameof(Medications10));
			}
		}
		private ObservableCollection<Medication> medications11;
		public ObservableCollection<Medication> Medications11
		{
			get { return medications11; }
			set
			{
				medications11 = value;
				OnPropertyChanged(nameof(Medications11));
			}
		}

		private ObservableCollection<Medication> medications12;
		public ObservableCollection<Medication> Medications12
		{
			get { return medications12; }
			set
			{
				medications12 = value;
				OnPropertyChanged(nameof(Medications12));
			}
		}
		private ObservableCollection<Medication> medications13;
		public ObservableCollection<Medication> Medications13
		{
			get { return medications13; }
			set
			{
				medications13 = value;
				OnPropertyChanged(nameof(Medications13));
			}
		}

		private ObservableCollection<Medication> medications14;
		public ObservableCollection<Medication> Medications14
		{
			get { return medications14; }
			set
			{
				medications14 = value;
				OnPropertyChanged(nameof(Medications14));
			}
		}
		private ObservableCollection<Medication> medications15;
		public ObservableCollection<Medication> Medications15
		{
			get { return medications15; }
			set
			{
				medications15 = value;
				OnPropertyChanged(nameof(Medications15));
			}
		}
		private ObservableCollection<Medication> medications16;
		public ObservableCollection<Medication> Medications16
		{
			get { return medications16; }
			set
			{
				medications16 = value;
				OnPropertyChanged(nameof(Medications16));
			}
		}

		private ObservableCollection<Medication> medications17;
		public ObservableCollection<Medication> Medications17
		{
			get { return medications17; }
			set
			{
				medications17 = value;
				OnPropertyChanged(nameof(Medications17));
			}
		}

		private ObservableCollection<Medication> medications18;
		public ObservableCollection<Medication> Medications18
		{
			get { return medications18; }
			set
			{
				medications18 = value;
				OnPropertyChanged(nameof(Medications18));
			}
		}

		private ObservableCollection<Medication> medications19;
		public ObservableCollection<Medication> Medications19
		{
			get { return medications19; }
			set
			{
				medications19 = value;
				OnPropertyChanged(nameof(Medications19));
			}
		}

		private ObservableCollection<Medication> medications20;
		public ObservableCollection<Medication> Medications20
		{
			get { return medications20; }
			set
			{
				medications20 = value;
				OnPropertyChanged(nameof(Medications20));
			}
		}

		private ObservableCollection<Medication> medications21;
		public ObservableCollection<Medication> Medications21
		{
			get { return medications21; }
			set
			{
				medications21 = value;
				OnPropertyChanged(nameof(Medications21));
			}
		}

		private ObservableCollection<Medication> medications22;
		public ObservableCollection<Medication> Medications22
		{
			get { return medications22; }
			set
			{
				medications22 = value;
				OnPropertyChanged(nameof(Medications22));
			}
		}


		private ObservableCollection<Medication> medications23;
		public ObservableCollection<Medication> Medications23
		{
			get { return medications23; }
			set
			{
				medications23 = value;
				OnPropertyChanged(nameof(Medications23));
			}
		}

		private ObservableCollection<Medication> medications24;
		public ObservableCollection<Medication> Medications24
		{
			get { return medications24; }
			set
			{
				medications24 = value;
				OnPropertyChanged(nameof(Medications24));
			}
		}


		private string connectionString = @"Data Source=DESKTOP-AOF7V3Q;Initial Catalog=MedDB;Integrated Security=True";

		public MedicationRepository()
		{
			Medications = GetMedications("Лекарственные препараты");
			Medications1 = GetMedicationsOfType("Аптечка");
			Medications2 = GetMedicationsOfType("Бады");
			Medications3 = GetMedicationsOfType("Техника");
			Medications4 = GetMedicationsOfType("Оптика");
			Medications5 = GetMedicationsOfType("Косметика");
			Medications6 = GetMedicationsOfType("Мама");
			Medications7 = GetMedicationsOfType("Кожа");
			Medications8 = GetMedicationsOfType("Насморк");
			Medications9 = GetMedicationsOfType("Желудок");
			Medications10 = GetMedicationsOfType("Кашель");
			Medications11 = GetMedicationsOfType("Зубы");
			Medications12 = GetMedicationsOfType("La Roche-Posay");
			Medications13 = GetMedicationsOfType("A-Derma");
			Medications14 = GetMedicationsOfType("ВИТРУМ");
			Medications15 = GetMedicationsOfType("ISISPHARMA");
			Medications16 = GetMedicationsOfType("VICHY");
			Medications17 = GetMedicationsOfType("Bioderma");
			Medications18 = GetMedicationsOfType("CANPOL");
			Medications19 = GetMedicationsOfType("Bionorica");
			Medications20 = GetMedicationsOfType("Dermedic");
			Medications21 = GetMedicationsOfType("CeraVe");
			Medications22 = GetMedicationsOfType("Sensodyne");
			Medications23 = GetMedicationsOfType("PARODONTAX");
			Medications24 = GetMedicationsForAkcii();

		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ObservableCollection<Medication> GetMedications(string type)
		{
			ObservableCollection<Medication> medications = new ObservableCollection<Medication>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = $"SELECT id, name, price, for_what, twoprice, akcii, opisanie, foto FROM tabletkadb WHERE type_of = '{type}'";
					SqlCommand command = new SqlCommand(query, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Medication medication = new Medication
						{
							Id = reader["id"].ToString(),
							Name = reader["name"].ToString(),
							Price = Convert.ToDecimal(reader["price"]),
							ForWhat = reader["for_what"].ToString(),
							Foto = reader["foto"].ToString(),
							Opisanie = reader["opisanie"].ToString(),
							Twoprice = Convert.ToDecimal(reader["twoprice"]),
							Akcii = Convert.ToBoolean(reader["akcii"])
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

		public ObservableCollection<Medication> GetMedicationsOfType(string type)
		{
			ObservableCollection<Medication> medications1 = new ObservableCollection<Medication>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = $"SELECT id, name, price, for_what, twoprice, akcii, opisanie, foto FROM tabletkadb WHERE for_what = '{type}'";
					SqlCommand command = new SqlCommand(query, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Medication medications = new Medication
						{
							Id = reader["id"].ToString(),
							Name = reader["name"].ToString(),
							Price = Convert.ToDecimal(reader["price"]),
							ForWhat = reader["for_what"].ToString(),
							Foto = reader["foto"].ToString(),
							Opisanie = reader["opisanie"].ToString(),
							Twoprice = Convert.ToDecimal(reader["twoprice"]),
							Akcii = Convert.ToBoolean(reader["akcii"])
						};

						medications1.Add(medications);
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}

			return medications1;
		}

		public ObservableCollection<Medication> GetMedicationsForAkcii()
		{
			ObservableCollection<Medication> medications23 = new ObservableCollection<Medication>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = $"SELECT id, name, price, for_what, twoprice, akcii, opisanie, foto FROM tabletkadb WHERE akcii = '1'";
					SqlCommand command = new SqlCommand(query, connection);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Medication medications = new Medication
						{
							Id = reader["id"].ToString(),
							Name = reader["name"].ToString(),
							Price = Convert.ToDecimal(reader["price"]),
							ForWhat = reader["for_what"].ToString(),
							Foto = reader["foto"].ToString(),
							Opisanie = reader["opisanie"].ToString(),
							Twoprice = Convert.ToDecimal(reader["twoprice"]),
							Akcii = Convert.ToBoolean(reader["akcii"])
						};

						medications23.Add(medications);
					}

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}

			return medications23;
		}

		public class Medication : INotifyPropertyChanged
		{
			private decimal price;
			private decimal twoprice;
			private bool akcii;

			public string Id { get; set; }
			public string Name { get; set; }
			public string ForWhat { get; set; }
			public string Foto { get; set; }
			public string Opisanie { get; set; }
			public int KorzinaID { get; set; }
			public int UserID { get; set; }
			public int MedicationID { get; set; }
			public int Quantity { get; set; }

			public decimal Price
			{
				get => price;
				set
				{
					price = value;
					OnPropertyChanged(nameof(Price));
					OnPropertyChanged(nameof(FormattedPrice));
					OnPropertyChanged(nameof(FormattedOriginalPrice));
				}
			}

			public decimal Twoprice
			{
				get => twoprice;
				set
				{
					twoprice = value;
					OnPropertyChanged(nameof(Twoprice));
					OnPropertyChanged(nameof(FormattedPrice));
				}
			}

			public bool Akcii
			{
				get => akcii;
				set
				{
					akcii = value;
					OnPropertyChanged(nameof(Akcii));
					OnPropertyChanged(nameof(FormattedPrice));
					OnPropertyChanged(nameof(FormattedOriginalPrice));
				}
			}

			public string FormattedPrice => Akcii ? $"{Twoprice} руб." : $"{Price} руб.";
			public string FormattedOriginalPrice => Akcii ? $"{Price} руб." : string.Empty;

			public event PropertyChangedEventHandler PropertyChanged;

			protected void OnPropertyChanged(string propertyName)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
