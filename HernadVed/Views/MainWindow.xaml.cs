using System.Windows;
using HernadVed.Models;

namespace HernadVed.Views
{
    public partial class MainWindow : Window
    {
        private readonly User _currentUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            InitializeUserInterface();
        }

        private void InitializeUserInterface()
        {
            // Set user information
            UserNameTextBlock.Text = !string.IsNullOrEmpty(_currentUser.Name) 
                ? _currentUser.Name 
                : _currentUser.Email;
            UserRoleTextBlock.Text = $"Szerepkör: {_currentUser.Role}";

            // Set welcome message
            if (_currentUser.IsAdmin)
            {
                WelcomeMessageTextBlock.Text = 
                    "Ön adminisztrátorként jelentkezett be. Teljes hozzáféréssel rendelkezik a rendszer összes funkciójához.";
                AdminPanel.Visibility = Visibility.Visible;
                DispatcherPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                WelcomeMessageTextBlock.Text = 
                    "Ön diszpécserként jelentkezett be. Hozzáférése van a diszpécser funkciókhoz.";
                AdminPanel.Visibility = Visibility.Collapsed;
                DispatcherPanel.Visibility = Visibility.Visible;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Show login window
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            // Close current window
            this.Close();
        }
    }
}
