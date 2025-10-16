using System.Windows;
using System.Windows.Controls;
using HernadVed.ViewModels;

namespace HernadVed.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel && sender is PasswordBox passwordBox)
            {
                viewModel.Password = passwordBox.Password;
            }
        }
    }
}
