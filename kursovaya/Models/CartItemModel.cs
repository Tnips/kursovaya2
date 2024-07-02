using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya.Models
{
	public class CartItemModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ProductId { get; set; }
		private int _quantity;
		private string _name;
		public int Quantity
		{
			get { return _quantity; }
			set
			{
				if (_quantity != value)
				{
					_quantity = value;
					OnPropertyChanged(nameof(Quantity));
					OnPropertyChanged(nameof(TotalPrice)); // Notify TotalPrice change
				}
			}
		}
		public decimal Price { get; set; }

		// Добавленные свойства для XAML привязки
		public string Foto { get; set; } // предположим, что это строка с URL фото товара
		public string Name 
		{ 
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
				
		} // имя или описание товара
		public decimal TotalPrice => Price * Quantity;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}
