using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
	public class CartItem : INotifyPropertyChanged
	{
		private int korzinaID;
		public int KorzinaID
		{
			get { return korzinaID; }
			set
			{
				korzinaID = value;
				OnPropertyChanged(nameof(KorzinaID));
			}
		}

		private int idUser;
		public int IdUser
		{
			get { return idUser; }
			set
			{
				idUser = value;
				OnPropertyChanged(nameof(IdUser));
			}
		}

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private int userID;
		public int UserID
		{
			get { return userID; }
			set
			{
				userID = value;
				OnPropertyChanged(nameof(UserID));
			}
		}

		private int medicationID;
		public int MedicationID
		{
			get { return medicationID; }
			set
			{
				medicationID = value;
				OnPropertyChanged(nameof(MedicationID));
			}
		}

		private decimal price;
		public decimal Price
		{
			get { return price; }
			set
			{
				price = value;
				OnPropertyChanged(nameof(Price));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		private int quantity;
		public int Quantity
		{
			get { return quantity; }
			set
			{
				quantity = value;
				OnPropertyChanged(nameof(Quantity));
				OnPropertyChanged(nameof(TotalPrice));
			}
		}

		public decimal TotalPrice => Price * Quantity;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void IncreaseQuantity()
		{
			Quantity++;
			OnPropertyChanged(nameof(Quantity));
		}

		public void DecreaseQuantity()
		{
			if (Quantity > 1)
			{
				Quantity--;
				OnPropertyChanged(nameof(Quantity));
			}
		}
		private bool _isOrdered;
		public bool IsOrdered
		{
			get { return _isOrdered; }
			set
			{
				_isOrdered = value;
				OnPropertyChanged(nameof(IsOrdered));
			}
		}
	}
}
