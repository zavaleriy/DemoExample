using System;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using DemoExample.Helpers;
using DemoExample.Models;
using DemoExample.ViewModels;

namespace DemoExample.Views;

public partial class EditorWindow : Window
{
    private EditorWindowViewModel _viewModel;
    private int productId;
    public EditorWindow(int prId)
    {
        InitializeComponent();
        productId = prId;
        DeleteBtn.IsVisible = true;
        _viewModel = new EditorWindowViewModel(prId);
        DataContext = _viewModel;
    }

    public EditorWindow()
    {
        InitializeComponent();
        _viewModel = new EditorWindowViewModel();
        DataContext = _viewModel;
        BoxID.IsVisible = false;
        BlockID.IsVisible = false;
    }

    private void Back(object? sender, RoutedEventArgs e)
    {
        new ProductsWindow().Show();
        Close();
    }

    private void Delete(object? sender, RoutedEventArgs e)
    {
        Product prod = LocalDB.Products.Single(s => s.Id == productId);
        if (Session.Cart.Contains(prod.Id)) return;
        
        LocalDB.Products.Remove(prod);
        new ProductsWindow().Show();
        Close();
    }

    private async void PickImage(object? sender, RoutedEventArgs e)
    {
        var file = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Выберите изображение",
            AllowMultiple = false,
            FileTypeFilter = new []{ FilePickerFileTypes.ImageAll }
        });

        if (file.Count == 0) return;

        try
        {
            Bitmap img = new Bitmap(file[0].Path.AbsolutePath);
            if (img.Size.Width > 300 || img.Size.Height > 200)
            {
                ImageLog.Text = "Максимальное разрешение изображения 300x200";
                return;
            }
            ProductImage.Source = img;
            _viewModel.Product.Image = img;
        }
        catch (System.IO.FileNotFoundException)
        {
            ImageLog.Text = "Невозможно найти файл: " + file[0].Path.AbsolutePath;
        }
        

    }
}