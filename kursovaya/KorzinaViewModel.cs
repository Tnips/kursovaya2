using System.Collections.ObjectModel;
using System.Windows.Input;
using kursovaya.Models;

namespace kursovaya
{
	public class KorzinaViewModel : ViewModelBase
	{
		private readonly DataBase _database;
		private readonly int _userId;

		// Коллекция для хранения товаров в корзине
		public ObservableCollection<CartItemModel> CartItems { get; set; }

		// Команды для увеличения, уменьшения количества и удаления товаров из корзины
		public ICommand IncreaseQuantityCommand { get; set; }
		public ICommand DecreaseQuantityCommand { get; set; }
		public ICommand DeleteCartItemCommand { get; set; }
		public ICommand OrderItemCommand { get; set; }

		// Конструктор для инициализации базы данных и команд
		public KorzinaViewModel(DataBase database, int userId)
		{
			_database = database;
			_userId = userId;

			// Загрузка товаров в корзину
			LoadCartItems();

			// Инициализация команд
			IncreaseQuantityCommand = new RelayCommand<CartItemModel>(IncreaseQuantity);
			DecreaseQuantityCommand = new RelayCommand<CartItemModel>(DecreaseQuantity);
			DeleteCartItemCommand = new RelayCommand<CartItemModel>(DeleteCartItem);
			OrderItemCommand = new RelayCommand<CartItemModel>(OrderItem);
		}

		// Метод для загрузки товаров из базы данных
		private void LoadCartItems()
		{
			var cartItems = _database.GetCartItems(_userId);
			CartItems = new ObservableCollection<CartItemModel>(cartItems);
		}

		// Метод для увеличения количества товара
		private void IncreaseQuantity(CartItemModel item)
		{
			item.Quantity++;
			_database.UpdateCartItemQuantity(item.Id, item.Quantity);
			OnPropertyChanged(nameof(CartItems)); // Уведомление об изменении коллекции
		}

		// Метод для уменьшения количества товара
		private void DecreaseQuantity(CartItemModel item)
		{
			if (item.Quantity > 1)
			{
				item.Quantity--;
				_database.UpdateCartItemQuantity(item.Id, item.Quantity);
				OnPropertyChanged(nameof(CartItems)); // Уведомление об изменении коллекции
			}
		}

		// Метод для удаления товара из корзины
		private void DeleteCartItem(CartItemModel item)
		{
			_database.DeleteCartItem(item.Id);
			CartItems.Remove(item); // Удаление товара из коллекции
			OnPropertyChanged(nameof(CartItems)); // Уведомление об изменении коллекции
		}

		private void OrderItem(CartItemModel cartItem)
		{
			if (cartItem != null)
			{
				Zakaz zakaz = new Zakaz(cartItem.Name);
				zakaz.ShowDialog();
			}
		}
	}
}
