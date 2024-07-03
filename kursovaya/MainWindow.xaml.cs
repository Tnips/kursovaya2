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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using kursovaya.Models;
namespace kursovaya
{
	
	public partial class MainWindow : Window
	{

		DataBase dataBase = new DataBase();

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
			ObnovZagr();
			this.DataContext = new MedicationViewModel();

		}

		private void ObnovZagr()
		{
			if (CurrentUser.User != null)
			{
				user.Visibility = Visibility.Visible;
				korzinaButton.Visibility = Visibility.Visible;
				AvtorizPanel.Visibility = Visibility.Collapsed;

			}
			else
			{
				user.Visibility = Visibility.Collapsed;
				korzinaButton.Visibility = Visibility.Collapsed;
				AvtorizPanel.Visibility = Visibility.Visible;
			}
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


		private void akcii_Click(object sender, RoutedEventArgs e)
		{
			Akcii akcii = new Akcii();
			akcii.Show();
			Hide();
		}

		private void drugs_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Лекарственные препараты");
			Drugs drugs = new Drugs();
			drugs.Show();
			Close();
		}

		private void aptechka_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Аптечка");
			Aptechka aptechka = new Aptechka();
			aptechka.Show();
			Close();
		}

		private void bad_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Витамины и БАДы");
			Bad bad = new Bad();
			bad.Show();
			Close();
		}

		private void medtech_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Медицинская техника");
			MedTech medtech = new MedTech();
			medtech.Show(); Close();
			Close();
		}

		private void optica_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Оптика");
			Optica optica = new Optica();
			optica.Show();
			Close();

		}

		private void kosm_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Гигиена и косметика");
			Kosm kosm = new Kosm();
			kosm.Show();
			Close();

		}

		private void momandbaby_Click(object sender, RoutedEventArgs e)
		{
			UpdateMedications("Мама и малыш");
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
		private void FormRegisterButton_Click(object sender, RoutedEventArgs e)
		{
			RegisterPanel.Visibility = Visibility.Visible;
			LoginPanel.Visibility = Visibility.Collapsed;
		}

		private void FormLoginButton_Click(object sender, RoutedEventArgs e)
		{
			LoginPanel.Visibility = Visibility.Visible;
			RegisterPanel.Visibility = Visibility.Collapsed;
		}

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			var login = RegisterNameUser.Text;
			var password = RegisterPassword.Password;
			var confirmPassword = RegisterConfirmPassword.Password;
			var password1 = RegisterPasswordText.Text;
			var confirmPassword1 = RegisterConfirmPasswordText.Text;

			// Проверка, совпадают ли пароли и достаточно ли символов в пароле
			if (password != confirmPassword || password1 != confirmPassword1)
			{
				CustomMessageBox.ShowMessage("Пароли не совпадают! Пожалуйста, проверьте введенные пароли.", "Ошибка");
				return;
			}

			if (password.Length < 5 || password1.Length < 5)
			{
				CustomMessageBox.ShowMessage("Пароль должен содержать не менее 5 символов.", "Ошибка");
				return;
			}

			// Запрос с возвратом сгенерированного id_user
			string querystring = $"INSERT INTO register(login_user, password_user) OUTPUT INSERTED.id_user VALUES (@login, @password)";

			SqlCommand command = new SqlCommand(querystring, dataBase.getSqlConnection());
			command.Parameters.AddWithValue("@login", login);
			command.Parameters.AddWithValue("@password", password);

			dataBase.openConnection();

			// Выполнение команды и получение сгенерированного id_user
			var idUser = (int?)command.ExecuteScalar();

			if (idUser.HasValue)
			{
				CustomMessageBox.ShowMessage("Аккаунт успешно создан!", "Успех!");

				CurrentUser.User = new kursovaya.Models.User
				{
					Id = idUser.Value, // Добавьте поле Id в модель User
					Login = login,
					Password = password
				};
				Authentific.UserRegister = true;
				ObnovZagr();
				AvtorizPanel.Visibility = Visibility.Collapsed;
				user.Visibility = Visibility.Visible;
				korzinaButton.Visibility = Visibility.Visible;
			}
			else
			{
				CustomMessageBox.ShowMessage("Аккаунт не создан!", "Ошибка");
			}

			dataBase.closeConnection();
		}







		private Boolean checkuser()
		{
			var loginUser = LoginName.Text;
			var passUser = LoginPassword.Password;
			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();
			string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

			SqlCommand command = new SqlCommand(querystring, dataBase.getSqlConnection());

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if(table.Rows.Count > 0)
			{
				System.Windows.MessageBox.Show("Пользователь уже существует!");
				return true;
			}
			else
			{
				return false;
			}
		}

		private void RegisterPanel_Loaded(object sender, RoutedEventArgs e)
		{	
			RegisterNameUser.MaxLength = 50;
			RegisterPassword.MaxLength = 16;
			RegisterConfirmPassword.MaxLength = 16;

		}

		private void Otkrglaz11_Click(object sender, RoutedEventArgs e)
		{
			if (RegisterPassword.Visibility == Visibility.Visible)
			{
				// Переключаемся на TextBox и показываем пароль
				RegisterPasswordText.Text = RegisterPassword.Password;
				RegisterPassword.Visibility = Visibility.Collapsed;
				RegisterPasswordText.Visibility = Visibility.Visible;
				Zakrglaz1.Visibility = Visibility.Collapsed;
				Otkrglaz1.Visibility = Visibility.Visible;

			}
			else
			{
				// Переключаемся обратно на PasswordBox
				RegisterPassword.Password = RegisterPasswordText.Text;
				RegisterPassword.Visibility = Visibility.Visible;
				RegisterPasswordText.Visibility = Visibility.Collapsed;
				Zakrglaz1.Visibility = Visibility.Visible;
				Otkrglaz1.Visibility = Visibility.Collapsed;
			}

		}

		private void Otkrglaz22_Click(object sender, RoutedEventArgs e)
		{
			if (RegisterConfirmPassword.Visibility == Visibility.Visible)
			{
				// Переключаемся на TextBox и показываем пароль
				RegisterConfirmPasswordText.Text = RegisterConfirmPassword.Password;
				RegisterConfirmPassword.Visibility = Visibility.Collapsed;
				RegisterConfirmPasswordText.Visibility = Visibility.Visible;
				Zakrglaz2.Visibility = Visibility.Collapsed;
				Otkrglaz2.Visibility = Visibility.Visible;

			}
			else
			{
				// Переключаемся обратно на PasswordBox
				RegisterConfirmPassword.Password = RegisterConfirmPasswordText.Text;
				RegisterConfirmPassword.Visibility = Visibility.Visible;
				RegisterConfirmPasswordText.Visibility = Visibility.Collapsed;
				Zakrglaz2.Visibility = Visibility.Visible;
				Otkrglaz2.Visibility = Visibility.Collapsed;
			}

		}

		private void Avtoriz_Click(object sender, RoutedEventArgs e)
		{
			var loginUser = LoginName.Text;
			var passUser = LoginPassword.Password;

			// Проверка длины пароля
			if (passUser.Length < 5)
			{
				CustomMessageBox.ShowMessage("Пароль должен содержать не менее 5 символов.", "Ошибка");
				return;
			}

			SqlDataAdapter adapter = new SqlDataAdapter();
			DataTable table = new DataTable();

			string querystring = "SELECT id_user, login_user, password_user FROM register WHERE login_user = @loginUser AND password_user = @passUser";

			SqlCommand command = new SqlCommand(querystring, dataBase.getSqlConnection());
			command.Parameters.AddWithValue("@loginUser", loginUser);
			command.Parameters.AddWithValue("@passUser", passUser);

			adapter.SelectCommand = command;
			adapter.Fill(table);

			if (table.Rows.Count == 1)
			{
				CustomMessageBox.ShowMessage("Вы успешно вошли!", "Успешно!");
				var row = table.Rows[0];

				CurrentUser.User = new kursovaya.Models.User
				{
					Id = (int)row["id_user"],
					Login = (string)row["login_user"],
					Password = (string)row["password_user"]
				};
				Authentific.UserAuthentic = true;
				ObnovZagr();
				AvtorizPanel.Visibility = Visibility.Collapsed;
				user.Visibility = Visibility.Visible;
				korzinaButton.Visibility = Visibility.Visible;
			}
			else
			{
				CustomMessageBox.ShowMessage("Такого аккаунта не существует!", "Ошибка");
			}
		}




		private void Otkrglaz33_Click(object sender, RoutedEventArgs e)
		{
			if (LoginPassword.Visibility == Visibility.Visible)
			{
				// Переключаемся на TextBox и показываем пароль
				LoginPasswordText.Text = LoginPassword.Password;
				LoginPassword.Visibility = Visibility.Collapsed;
				LoginPasswordText.Visibility = Visibility.Visible;
				Zakrglaz3.Visibility = Visibility.Collapsed;
				Otkrglaz3.Visibility = Visibility.Visible;

			}
			else
			{
				// Переключаемся обратно на PasswordBox
				LoginPassword.Password = LoginPasswordText.Text;
				LoginPassword.Visibility = Visibility.Visible;
				LoginPasswordText.Visibility = Visibility.Collapsed;
				Zakrglaz3.Visibility = Visibility.Visible;
				Otkrglaz3.Visibility = Visibility.Collapsed;
			}

		}

		private void LoginPanel_Loaded(object sender, RoutedEventArgs e)
		{
			LoginName.MaxLength = 50;
			LoginPassword.MaxLength = 16;
		}

		private void user_Click(object sender, RoutedEventArgs e)
		{
			User user = new User();
			user.Show();
			Close();
		}

		private void UpdateMedications(string type)
		{
			var repository = DataContext as MedicationRepository;
			if (repository != null)
			{
				repository.Medications1 = repository.GetMedicationsOfType(type);
			}
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
