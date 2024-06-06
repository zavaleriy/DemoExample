namespace DemoExample.Models;

public class User
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Roles Role { get; set; } = Roles.User;
}