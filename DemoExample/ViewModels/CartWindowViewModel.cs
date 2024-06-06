using System.Collections.ObjectModel;
using System.Linq;
using DemoExample.Models;
using ReactiveUI;

namespace DemoExample.ViewModels;

public class CartWindowViewModel : ViewModelBase
{
    private ObservableCollection<Product> _cart = new();
    
    public ObservableCollection<Product> Cart
    {
        get => _cart;
        set => this.RaiseAndSetIfChanged(ref _cart, value);
    }

    public CartWindowViewModel()
    {
        foreach (var productId in Session.Cart)
        {
            Cart.Add(LocalDB.Products.First(p => p.Id == productId));
        }
    }
}