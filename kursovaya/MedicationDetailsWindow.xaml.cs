using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovaya
{
	/// <summary>
	/// Логика взаимодействия для MedicationDetailsWindow.xaml
	/// </summary>
	public partial class MedicationDetailsWindow : Window
	{
		public MedicationDetailsWindow(string opisanie)
		{
			InitializeComponent();
			OpisanieImage.Source = new BitmapImage(new Uri(opisanie, UriKind.RelativeOrAbsolute));
		}
		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
		}

	}
}
