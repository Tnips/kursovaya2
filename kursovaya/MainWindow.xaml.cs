using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;

namespace kursovaya
{
	
	public partial class MainWindow : Window
	{
		private List<string> imagePaths = new List<string>
		{
			"pack://application:,,,/images/banner1.jpg",
			"pack://application:,,,/images/banner2.jpg",
			"pack://application:,,,/images/banner3.jpg"
		};

		private int currentIndex = 0;
		private DispatcherTimer timer = new DispatcherTimer();

		public MainWindow()
		{
			InitializeComponent();
			InitializeTimer();
			DisplayCurrentImage();
		}

		private void InitializeTimer()
		{
			timer.Interval = TimeSpan.FromSeconds(5);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			currentIndex = (currentIndex + 1) % imagePaths.Count;
			DisplayCurrentImage();
		}

		private void DisplayCurrentImage()
		{
			string imagePath = imagePaths[currentIndex];
			BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
			bannerImage.Source = bitmap;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			Close();
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

		private void derma_Click(object sender, RoutedEventArgs e)
		{
			Derma derma = new Derma();
			derma.Show(); 
			Close();	
		}

		private void nasmork_Click(object sender, RoutedEventArgs e)
		{
			Nasmork nasmork = new Nasmork();
			nasmork.Show();
			Close();
		}

		private void zheludok_Click(object sender, RoutedEventArgs e)
		{
			Zheludok zheludok = new Zheludok();
			zheludok.Show();
			Close();
		}

		private void kashel_Click(object sender, RoutedEventArgs e)
		{
			Kashel kashel = new Kashel();
			kashel.Show();
			Close();
		}

		private void zub_Click(object sender, RoutedEventArgs e)
		{
			Zub zub = new Zub();
			zub.Show();
			Close();
		}

		private void larochposay_Click(object sender, RoutedEventArgs e)
		{
			Larochposay larochposay = new Larochposay();
			larochposay.Show();
			Close();

		}

		private void dermae_Click(object sender, RoutedEventArgs e)
		{
			DermaE dermaE = new DermaE();
			dermaE.Show();
			Close();
		}

		private void vitrum_Click(object sender, RoutedEventArgs e)
		{
			Vitrum vitrum = new Vitrum();
			vitrum.Show();
			Close();
		}

		private void isispharma_Click(object sender, RoutedEventArgs e)
		{
			IsisPharma isispharma = new IsisPharma();
			isispharma.Show();
			Close();
		}

		private void vichy_Click(object sender, RoutedEventArgs e)
		{
			Vichy vichy = new Vichy();
			vichy.Show(); 
			Close();
		}

		private void bioderma_Click(object sender, RoutedEventArgs e)
		{
			Bioderma bioderma = new Bioderma();
			bioderma.Show();
			Close();
		}

		private void canpolbabies_Click(object sender, RoutedEventArgs e)
		{
			CanpolBabies canpolbabies = new CanpolBabies();
			canpolbabies.Show();
			Close();
		}

		private void bionorica_Click(object sender, RoutedEventArgs e)
		{
			Bionorica bionorica = new Bionorica();
			bionorica.Show();
			Close();
		}

		private void dermedic_Click(object sender, RoutedEventArgs e)
		{
			Dermedic dermedic = new Dermedic();	
			dermedic.Show(); 
			Close();
		}

		private void cerave_Click(object sender, RoutedEventArgs e)
		{
			CeraVe cerave = new CeraVe();
			cerave.Show(); 
			Close();
		}

		private void sensodyne_Click(object sender, RoutedEventArgs e)
		{
			Sensodyne sensodyne = new Sensodyne();
			sensodyne.Show();
			Close();
		}

		private void parodontax_Click(object sender, RoutedEventArgs e)
		{
			Parodontax parodontax = new Parodontax();
			parodontax.Show(); 
			Close();
		}
		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			RegisterPanel.Visibility = Visibility.Visible;
			LoginPanel.Visibility = Visibility.Collapsed;
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			LoginPanel.Visibility = Visibility.Visible;
			RegisterPanel.Visibility = Visibility.Collapsed;
		}
		
		
	}
}
