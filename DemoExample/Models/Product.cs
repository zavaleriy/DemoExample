using System;
using Avalonia.Media.Imaging;
using DemoExample.Helpers;

namespace DemoExample.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Bitmap? Image { get; set; } =
        ImageHelper.LoadFromResource(new Uri("avares://DemoExample/Assets/picture.png"));
    public Product Clone() => (Product)this.MemberwiseClone();
}