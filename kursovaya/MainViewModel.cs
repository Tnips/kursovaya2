using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace kursovaya
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private string _searchText;
		private ObservableCollection<string> _medicationNames;

		public MainViewModel()
		{
			SearchCommand = new RelayCommand(Search);
			MedicationNames = new ObservableCollection<string>();
		}

		public string SearchText
		{
			get => _searchText;
			set
			{
				if (_searchText != value)
				{
					_searchText = value;
					OnPropertyChanged(nameof(SearchText));
					PerformSearch();
				}
			}
		}

		public ObservableCollection<string> MedicationNames
		{
			get => _medicationNames;
			set
			{
				if (_medicationNames != value)
				{
					_medicationNames = value;
					OnPropertyChanged(nameof(MedicationNames));
				}
			}
		}

		public ICommand SearchCommand { get; }

		private void Search(object parameter)
		{
			PerformSearch();
		}

		private void PerformSearch()
		{
			// Replace this with actual database search logic
			var results = DataBase.SearchMedications(SearchText);
			MedicationNames = new ObservableCollection<string>(results);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
