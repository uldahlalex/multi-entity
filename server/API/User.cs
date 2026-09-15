namespace API;

public class User
{
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string Username { get; set; }
}