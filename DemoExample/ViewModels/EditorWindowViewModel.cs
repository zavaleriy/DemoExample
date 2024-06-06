using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DemoExample.Models;
using DynamicData;
using ReactiveUI;

namespace DemoExample.ViewModels;

public class EditorWindowViewModel : ViewModelBase
{
    public Product Product { get; set; }

    public List<string> Manufacturers { get; set; } = LocalDB.Manufacturers.Select(m => m.Name).ToList();

    private string _selectedManufacturer;
    public string SelectedManufacturer 
    {
        get => _selectedManufacturer;
        set => this.RaiseAndSetIfChanged(ref _selectedManufacturer, value);
    }

    private string _info = "";
    public string Info
    {
        get => _info;
        set => this.RaiseAndSetIfChanged(ref _info, value);
    }
    
    public ICommand SaveCommand { get; set; }
    
    // Edit
    public EditorWindowViewModel(int prId)
    {
        Product productOriginal = LocalDB.Products.Single(p => p.Id == prId);
        Product = productOriginal.Clone();

        SelectedManufacturer = Product.Manufacturer.Name;
        
        SaveCommand = ReactiveCommand.Create(() =>
        {
            Product.Manufacturer = LocalDB.Manufacturers.First(m => m.Name == SelectedManufacturer);
            LocalDB.Products.Replace(productOriginal, Product);
            Info = "Изменения внесены";
        });
    }

    // Create
    public EditorWindowViewModel()
    {
        Product = LocalDB.Products.Count == 0 
            ? new Product { Id = 1 } 
            : new Product { Id = LocalDB.Products.Last().Id + 1 };

        SaveCommand = ReactiveCommand.Create(() =>
        {
            Product.Manufacturer = LocalDB.Manufacturers.First(m => m.Name == SelectedManufacturer);
            LocalDB.Products!.Add(Product);
            Info = "Продукт добавлен";
        });
    }
    
}