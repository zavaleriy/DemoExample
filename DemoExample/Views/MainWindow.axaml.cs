using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DemoExample.Models;

namespace DemoExample.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Login(object? sender, RoutedEventArgs e)
    {
        if (LoginBox.Text == "" || PasswordBox.Text == null)
        {
            WarnBox.Text = "Введите логин и/или пароль";
            await Task.Delay(3000);
            WarnBox.Text = null;
            return;
        }

        bool existUser = LocalDB.Users.Any(u => u.Login == LoginBox.Text && u.Password == PasswordBox.Text);

        if (!existUser)
        {
            WarnBox.Text = "Неправильный логин и/или пароль";
            await Task.Delay(3000);
            WarnBox.Text = null;
        }
        else
        {
            Session.User = LocalDB.Users.Single(u => u.Login == LoginBox.Text && u.Password == PasswordBox.Text);
            new ProductsWindow().Show();
            Close();
        }
        
    }
    
    private void EnterAsGuest(object? sender, RoutedEventArgs e)
    {
        Session.User = new User { Login = "Guest", Role = Roles.Guest };
        new ProductsWindow().Show();
        Close();
    }
    
}