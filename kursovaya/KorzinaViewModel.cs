using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using kursovaya.Models;

namespace kursovaya
{
	public class KorzinaViewModel : ViewModelBase
	{
		private readonly DataBase _database;
		private readonly int _userId;

		public ObservableCollection<CartItemModel> CartItems { get; set; }

		public ICommand IncreaseQuantityCommand { get; set; }
		public ICommand DecreaseQuantityCommand { get; set; }
		public ICommand DeleteCartItemCommand { get; set; }

		public KorzinaViewModel(DataBase database, int userId)
		{
			_database = database;
			_userId = userId;

			LoadCartItems();

			IncreaseQuantityCommand = new RelayCommand<CartItemModel>(IncreaseQuantity);
			DecreaseQuantityCommand = new RelayCommand<CartItemModel>(DecreaseQuantity);
			DeleteCartItemCommand = new RelayCommand<CartItemModel>(DeleteCartItem);
		}

		private void LoadCartItems()
		{
			var cartItems = _database.GetCartItems(_userId);
			CartItems = new ObservableCollection<CartItemModel>(cartItems);
		}

		private void IncreaseQuantity(CartItemModel item)
		{
			item.Quantity++;
			_database.UpdateCartItemQuantity(item.Id, item.Quantity);
			OnPropertyChanged(nameof(CartItems)); // Уведомляем о изменении всей коллекции
		}

		private void DecreaseQuantity(CartItemModel item)
		{
			if (item.Quantity > 1)
			{
				item.Quantity--;
				_database.UpdateCartItemQuantity(item.Id, item.Quantity);
				OnPropertyChanged(nameof(CartItems)); // Уведомляем о изменении всей коллекции
			}
		}

		private void DeleteCartItem(CartItemModel item)
		{
			_database.DeleteCartItem(item.Id);
			CartItems.Remove(item); // Удаляем элемент из коллекции
			OnPropertyChanged(nameof(CartItems)); // Уведомляем о изменении всей коллекции
		}
	}
}
