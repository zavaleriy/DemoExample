using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DemoExample.Models;
using ReactiveUI;

namespace DemoExample.ViewModels;

public class ProductsWindowViewModel : ViewModelBase
{

    private string _searchText;
    
    public string SearchText
    {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }
    
    private ObservableCollection<Product> _listProducts = new(LocalDB.Products);

    public ObservableCollection<Product> ListProducts
    {
        get => _listProducts;
        set => this.RaiseAndSetIfChanged(ref _listProducts, value);
    }
    
    public List<string> Sorting { get; set; } = new()
    {
        "Релевантность",
        "Подешевле",
        "Подороже"
    };

    private string _selectedSort = "Релевантность";

    public string SelectedSort
    {
        get => _selectedSort;
        set => this.RaiseAndSetIfChanged(ref _selectedSort, value);
    }
    
    public List<string> Manufacturers { get; set; } = new()
    {
        "Все производители"
    };

    private string _selectedManufacturer = "Все производители";

    public string SelectedManufacturer
    {
        get => _selectedManufacturer;
        set => this.RaiseAndSetIfChanged(ref _selectedManufacturer, value);
    }

    public ProductsWindowViewModel()
    {
        Manufacturers.AddRange(LocalDB.Manufacturers.Select(m => m.Name)!);

        this.WhenAnyValue(
                x => x.SearchText,
                x => x.SelectedSort,
                x => x.SelectedManufacturer,
                (searchText, selectedSort, selectedManufacturer)
                    => (searchText, selectedSort, selectedManufacturer))
            .Select(method => Filter(method.searchText, method.selectedSort, method.selectedManufacturer))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(sortedList => ListProducts = new(sortedList));
    }

    private IEnumerable<Product> Filter(string searchText, string selectedSort, string selectedManufacturer)
    {
        var sortedList = string.IsNullOrWhiteSpace(searchText)
            ? LocalDB.Products
            : LocalDB.Products.Where(p => p.Name!.ToLower().Contains(searchText.ToLower()) ||
                                          p.Description!.ToLower().Contains(searchText.ToLower())
                                    );
            
        switch (selectedSort)
        {
            case "Релевантность":
                sortedList = sortedList.OrderBy(p => p.Id);
                break;
            case "Подешевле":
                sortedList = sortedList.OrderBy(p => p.Price);
                break;
            case "Подороже":
                sortedList = sortedList.OrderByDescending(p => p.Price);
                break;
        }

        if (selectedManufacturer != "Все производители")
        {
            Manufacturer manufacturer = LocalDB.Manufacturers.First(m => m.Name == SelectedManufacturer);
            sortedList = sortedList.Where(p => p.Manufacturer == manufacturer);
        }

        return sortedList;

    }
    
}