using System;
using System.Collections.Generic;
using DemoExample.Helpers;
using DemoExample.Models;

namespace DemoExample;

public class LocalDB
{
    public static readonly List<User> Users = new()
    {
        new User { Login = "user", Password = "userUser"},
        new User { Login = "manager", Password = "coolManager", Role = Roles.Manager},
        new User { Login = "admin", Password = "admin123", Role = Roles.Admin}
    };

    public static readonly List<Manufacturer> Manufacturers = new()
    {
        new Manufacturer { Id = 1, Name = "Apple" },
        new Manufacturer { Id = 2, Name = "Samsung" },
        new Manufacturer { Id = 3, Name = "Xiaomi" },
        new Manufacturer { Id = 4, Name = "Unknown" }
    };

    public static List<Product> Products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Apple iPhone 15 128 ГБ черный", 
            Manufacturer = Manufacturers[0], 
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Condimentum lacinia quis vel eros donec ac odio tempor orci.",
            Price = 85_899,
            StockQuantity = 10,
            Image = ImageHelper.LoadFromResource(new Uri("avares://DemoExample/Assets/Products/iphone15.png"))
        },
        new Product
        {
            Id = 2,
            Name = "Samsung Galaxy S23 Ultra 256 ГБ черный",
            Manufacturer = Manufacturers[1],
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Condimentum lacinia quis vel eros donec ac odio tempor orci.",
            Price = 99_999,
            StockQuantity = 3,
            Image = ImageHelper.LoadFromResource(new Uri("avares://DemoExample/Assets/Products/galaxys23.png"))
        },
        new Product
        {
            Id = 3,
            Name = "Xiaomi 13T 256 ГБ черный",
            Manufacturer = Manufacturers[2],
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Condimentum lacinia quis vel eros donec ac odio tempor orci.",
            Price = 45_999,
            StockQuantity = 13,
            Image = ImageHelper.LoadFromResource(new Uri("avares://DemoExample/Assets/Products/xiaomi13t.png"))
        },
        new Product
        {
            Id = 4,
            Name = "Нереальный телефон 120super 32 ТБ белый",
            Manufacturer = Manufacturers[3],
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus. Vitae et leo duis ut diam quam nulla porttitor massa.",
            Price = 11_999,
            StockQuantity = 0
        }
    };

}