using System.Collections.Generic;
using DemoExample.Models;

namespace DemoExample;

public static class Session
{
    public static User User { get; set; }

    public static List<int> Cart { get; set; } = new();
}