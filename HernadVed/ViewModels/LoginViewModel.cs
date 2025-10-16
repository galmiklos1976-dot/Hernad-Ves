using System.Windows;
using System.Windows.Input;
using HernadVed.Models;
using HernadVed.Services;
using HernadVed.Views;

namespace HernadVed.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isLoading;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _apiService = new ApiService();
            LoginCommand = new RelayCommand(async _ => await LoginAsync(), _ => CanLogin());
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && 
                   !string.IsNullOrWhiteSpace(Password) && 
                   !IsLoading;
        }

        private async Task LoginAsync()
        {
            ErrorMessage = string.Empty;
            IsLoading = true;

            try
            {
                var user = await _apiService.AuthenticateUserAsync(Email, Password);

                if (user != null)
                {
                    // Check if user is admin
                    if (user.IsAdmin)
                    {
                        user.Role = "Admin";
                    }
                    else
                    {
                        user.Role = "Dispatcher";
                    }

                    // Navigate to main window
                    var mainWindow = new MainWindow(user);
                    mainWindow.Show();

                    // Close login window
                    Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
                }
                else
                {
                    ErrorMessage = "Helytelen email vagy jelszó!";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Hiba történt a bejelentkezés során: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
