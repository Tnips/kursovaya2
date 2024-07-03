
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kursovaya
{
	public class MedicationViewModel : INotifyPropertyChanged
	{
		private readonly DataBase dataBase = new DataBase();

		public ObservableCollection<Medication> Medications { get; set; }
		public ObservableCollection<string> MedicationNames { get; set; }

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged(nameof(SearchText));
				SearchMedications();
			}
		}

		public ICommand SearchCommand { get; set; }

		public MedicationViewModel()
		{
			Medications = new ObservableCollection<Medication>();
			MedicationNames = new ObservableCollection<string>();
			SearchCommand = new RelayCommand(_ => SearchMedications());
			LoadMedications();
		}

		private void LoadMedications()
		{
			// Загрузка медикаментов из базы данных
			string query = "SELECT * FROM tabletkadb";
			using (SqlConnection connection = new SqlConnection(dataBase.getStringConnection()))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					var medication = new Medication
					{
						Id = reader.GetInt32(0).ToString(),
						Name = reader.GetString(1),
						Price = reader.IsDBNull(2) ? 0 : TryGetDecimal(reader.GetValue(2)),
						Twoprice = reader.IsDBNull(3) ? 0 : TryGetDecimal(reader.GetValue(3)),
						Akcii = reader.IsDBNull(4) ? false : TryGetBoolean(reader.GetValue(4)),
						Foto = reader.GetString(5)
					};
					Medications.Add(medication);
					MedicationNames.Add(medication.Name);
				}
			}
		}

		private decimal TryGetDecimal(object value)
		{
			try
			{
				return Convert.ToDecimal(value);
			}
			catch (FormatException)
			{
				return 0;
			}
			catch (InvalidCastException)
			{
				return 0;
			}
		}

		private bool TryGetBoolean(object value)
		{
			try
			{
				return Convert.ToBoolean(value);
			}
			catch (FormatException)
			{
				return false;
			}
			catch (InvalidCastException)
			{
				return false;
			}
		}



		private void SearchMedications()
		{
			var searchResults = Medications.Where(m => m.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
			Medications.Clear();
			foreach (var med in searchResults)
			{
				Medications.Add(med);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public class RelayCommand : ICommand
	{
		private readonly Action<object> execute;
		private readonly Predicate<object> canExecute;

		public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null ? true : canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}

}
