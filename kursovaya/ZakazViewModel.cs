using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;

namespace kursovaya
{
	class ZakazViewModel : INotifyPropertyChanged
	{

		private ObservableCollection<Pharmacy> pharmacies;
		public ObservableCollection<Pharmacy> Pharmacies
		{
			get { return pharmacies; }
			set
			{
				pharmacies = value;
				OnPropertyChanged(nameof(Pharmacies));
			}
		}

		// Конструктор класса MainViewModel
		public ZakazViewModel()
		{
			Pharmacies = new ObservableCollection<Pharmacy>();

			// Пример добавления аптек в коллекцию
			Pharmacies.Add(new Pharmacy { Id = 1, Name = "г.Гродно ул. Курчатова 4", Address = "Аптека №1" });
			Pharmacies.Add(new Pharmacy { Id = 2, Name = "г.Гродно ул. Советская 9", Address = "Аптека №2" });
			Pharmacies.Add(new Pharmacy { Id = 3, Name = "г. Гродно ул. Горького 5", Address = "Аптека №3" });

		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
