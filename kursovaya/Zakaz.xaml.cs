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

namespace kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
		public Zakaz(string nameDrug)
		{
			InitializeComponent();

			
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
			string card = CardNumberTextBox.Text;
			string mes = MonthTextBox.Text;
			string day = DayTextBox.Text;
			string cvc = CvcTextBox.Text;
			string number = PhoneNumberTextBox.Text;

			if (card.Length == 16 && mes.Length == 2 && day.Length == 2 &&
				cvc.Length == 3 && number.Length == 19)
			{
				MessageBox.Show("Ваш заказ оформлен! Вам придет уведомление о доставке!", "Вам придет уведомление о доставке!", MessageBoxButton.OK);
				Close();
			}
			else
			{
				MessageBox.Show("Заполните все поля корректно перед оформлением заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
