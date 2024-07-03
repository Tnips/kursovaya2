using System;
using kursovaya.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace kursovaya
{
	/// <summary>
	/// Логика взаимодействия для Zakaz.xaml
	/// </summary>
	public partial class Zakaz : Window
	{
		public static DataBase dataBase = new DataBase();
		private CartItemModel _cartItem;
		private KorzinaViewModel korzina = new KorzinaViewModel(dataBase, CurrentUser.User.Id);
		public Zakaz(CartItemModel cardItem)
		{
			InitializeComponent();
			_cartItem = cardItem;
			DataContext = new ZakazViewModel();
			tovarName.Text = "Заказ товара - " + cardItem.Name;

		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			// Allow only digits and ignore other characters
			if (!char.IsDigit(e.Text[0]))
			{
				e.Handled = true;
				return;
			}
		}

		private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;

			// Remove non-numeric characters from the text
			string input = Regex.Replace(textBox.Text, "[^0-9]", "");

			// Format the phone number with spaces or dashes as desired
			StringBuilder formattedNumber = new StringBuilder();

			// Ensure the initial "+375" remains at the beginning
			if (input.Length >= 3)
			{
				formattedNumber.Append("+375 ");
			}

			if (input.Length > 3)
			{
				formattedNumber.Append("(");
				formattedNumber.Append(input.Substring(3, Math.Min(2, input.Length - 3)));
				formattedNumber.Append(") ");
			}
			if (input.Length > 5)
			{
				formattedNumber.Append(input.Substring(5, Math.Min(3, input.Length - 5)));
				formattedNumber.Append("-");
			}
			if (input.Length > 8)
			{
				formattedNumber.Append(input.Substring(8, Math.Min(2, input.Length - 8)));
				formattedNumber.Append("-");
			}
			if (input.Length > 10)
			{
				formattedNumber.Append(input.Substring(10, Math.Min(2, input.Length - 10)));
			}

			// Update the TextBox text
			textBox.Text = formattedNumber.ToString();
			textBox.CaretIndex = textBox.Text.Length; // Move cursor to end
		}


		private void CardNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;

			// Удаляем все нецифровые символы из текста
			string input = Regex.Replace(textBox.Text, "[^0-9]", "");

			// Форматируем номер карты как XXXX XXXX XXXX XXXX
			StringBuilder formattedNumber = new StringBuilder();

			int chunkSize = 4;
			int index = 0;

			while (index < input.Length)
			{
				int remainingLength = input.Length - index;

				// Добавляем пробел после каждых четырех цифр, если это возможно
				if (remainingLength >= chunkSize)
				{
					formattedNumber.Append(input.Substring(index, chunkSize));
					formattedNumber.Append(" ");
				}
				else
				{
					// Добавляем оставшиеся цифры
					formattedNumber.Append(input.Substring(index, remainingLength));
				}

				index += chunkSize;
			}

			// Обновляем текст в TextBox
			textBox.Text = formattedNumber.ToString().Trim();
			textBox.CaretIndex = textBox.Text.Length; // Перемещаем курсор в конец текста
		}

		private void CardNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			// Разрешаем только ввод цифр и пробелов
			if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != " ")
			{
				e.Handled = true;
			}
		}

		private void LastThreeDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			// Проверяем, является ли вводимый символ цифрой
			if (!char.IsDigit(e.Text, e.Text.Length - 1))
			{
				e.Handled = true; // Предотвращаем ввод символа, если это не цифра
			}
		}

		private void OrderButton_Click(object sender, RoutedEventArgs e)
		{
			// Получение данных из текстовых полей и комбобоксов
			string card = CardNumberTextBox.Text;
			string mes = MonthTextBox.Text;
			string year = DayTextBox.Text; // Предполагается, что YearTextBox содержит последние две цифры года
			string cvc = CvcTextBox.Text;
			string number = PhoneNumberTextBox.Text;
			string ul = UlComboBox.Text;

			// Валидация всех полей перед продолжением
			if (card.Length == 19 && mes.Length == 2 && year.Length == 2 &&
				cvc.Length == 3 && number.Length == 19 && ul.Length != 0)
			{
				// Показать сообщение об успешном заказе
				CustomMessageBox.ShowMessage("Вам придет уведомление о доставке!", "Вам придет уведомление о доставке!");

				// Закрыть текущее окно
				Close();

				// Вставка данных из 'korzina' в таблицу 'zakaz'
				string query = "INSERT INTO zakaz (KorzinaID, UserID, MedicationID, Quantity, Price) " +
							   "SELECT KorzinaID, UserID, MedicationID, Quantity, Price FROM korzina";

				SqlCommand command = new SqlCommand(query, dataBase.getSqlConnection());

				try
				{
					korzina.DeleteCartItem(_cartItem);
					dataBase.openConnection();
					int rowsAffected = command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					CustomMessageBox.ShowMessage($"Ошибка при добавлении данных в таблицу zakaz: {ex.Message}", "Ошибка");
				}
				finally
				{
					dataBase.closeConnection();
				}
			}
			else
			{
				// Показать сообщение об ошибке, если валидация не прошла
				CustomMessageBox.ShowMessage("Заполните все поля корректно перед оформлением заказа.", "Ошибка");
			}
		}





		private void MonthTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text, 0))  // Проверка, что введен символ является цифрой
			{
				e.Handled = true;
				return;
			}

			TextBox textBox = sender as TextBox;
			string currentText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

			// Проверяем, что текущая строка имеет правильный формат месяца (две цифры)
			if (currentText.Length > 2 || (currentText.Length == 2 && (!int.TryParse(currentText, out int month) || month < 1 || month > 12)))
			{
				e.Handled = true;
				return;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

