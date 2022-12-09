namespace InNLBurgeren.Models;

public class User
{
    public User(int id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }

    public int Id { get; set; }

    public string Username { get; set; }
    
    public string Email { get; set; }

}