using kursovaya.Models;
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
    /// Логика взаимодействия для CanpolBabies.xaml
    /// </summary>
    public partial class CanpolBabies : Window
    {
        public CanpolBabies()
        {
            InitializeComponent();
			ObnovZagr();
		}

		private void ObnovZagr()
		{
			if (CurrentUser.User != null)
			{
				user.Visibility = Visibility.Visible;
				korzinaButton.Visibility = Visibility.Visible;

			}
			else
			{
				user.Visibility = Visibility.Collapsed;
				korzinaButton.Visibility = Visibility.Collapsed;
			}
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void MinimizeWindow(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void MaximizeWindow(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
				WindowState = WindowState.Normal;
			else
				WindowState = WindowState.Maximized;
		}

		private void home_Click(object sender, RoutedEventArgs e)
		{
			MainWindow home = new MainWindow();
			home.Show();
			Close();
		}
		private void korzinaButton_Click(object sender, RoutedEventArgs e)
		{
			Korzina korzina = new Korzina();
			korzina.Show();
			Close();
		}

		private void geo_Click(object sender, RoutedEventArgs e)
		{
			Geo geo = new Geo();
			geo.Show();
			Close();
		}

		private void akcii_Click(object sender, RoutedEventArgs e)
		{
			Akcii akcii = new Akcii();
			akcii.Show();
			Close();
		}

		private void drugs_Click(object sender, RoutedEventArgs e)
		{
			Drugs drugs = new Drugs();
			drugs.Show();
			Close();
		}

		private void aptechka_Click(object sender, RoutedEventArgs e)
		{
			Aptechka aptechka = new Aptechka();
			aptechka.Show();
			Close();
		}

		private void bad_Click(object sender, RoutedEventArgs e)
		{
			Bad bad = new Bad();
			bad.Show();
			Close();
		}

		private void medtech_Click(object sender, RoutedEventArgs e)
		{
			MedTech medtech = new MedTech();
			medtech.Show(); Close();
			Close();
		}

		private void optica_Click(object sender, RoutedEventArgs e)
		{
			Optica optica = new Optica();
			optica.Show();
			Close();

		}

		private void kosm_Click(object sender, RoutedEventArgs e)
		{
			Kosm kosm = new Kosm();
			kosm.Show();
			Close();

		}

		private void momandbaby_Click(object sender, RoutedEventArgs e)
		{
			MomandBaby momandBaby = new MomandBaby();
			momandBaby.Show();
			Close();
		}
		private void user_Click(object sender, RoutedEventArgs e)
		{
			User user = new User();
			user.Show();
			Close();
		}
	}
}

