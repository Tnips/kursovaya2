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
		public int KorzinaID { get; set; }
		public int IdUser { get; set; } // Добавьте поле для хранения id пользователя
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice => Price * Quantity;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPrice)));
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
	}


}
