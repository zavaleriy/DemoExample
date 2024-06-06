using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DemoExample.Models;
using DemoExample.ViewModels;

namespace DemoExample.Views;

public partial class ProductsWindow : Window
{
    private ProductsWindowViewModel _viewModel;
    public ProductsWindow()
    {
        InitializeComponent();
        DataContext = new ProductsWindowViewModel();
        _viewModel = (DataContext as ProductsWindowViewModel)!;
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        UserLoginBox.Text = "%NAME%";
        
        if (Session.User is not null)
        {
            UserLoginBox.Text = Session.User.Login;
            AdminPanel.IsVisible = Session.User!.Role == Roles.Admin;
        }
    }

    private void Exit(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    private void EditProduct_Tapped(object? sender, TappedEventArgs e)
    {
        if (Session.User.Role != Roles.Admin) return;
        int id = (int)(sender as Grid)!.Tag!;
        new EditorWindow(id).Show();
        Close();
    }

    private void CreateProduct(object? sender, RoutedEventArgs e)
    {
        new EditorWindow().Show();
        Close();
    }

    private void CartShow_OnClick(object? sender, RoutedEventArgs e)
    {
        new CartWindow{ DataContext = new CartWindowViewModel() }.Show();
    }

    private void AddCart_OnClick(object? sender, RoutedEventArgs e)
    {
        if (ProductsList.SelectedItem is not null) Session.Cart.Add((ProductsList.SelectedItem as Product)!.Id);
    }
}