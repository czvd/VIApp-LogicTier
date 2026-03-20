using Entities;

namespace Services;

public class AuthService : IAuthService
{
    // Fake users (since no DB yet)
    private List<User> users = new List<User>
    {
        new User { Email = "111111@via.dk", Password = "1234", Role = "Student" },
        new User { Email = "alan@via.dk", Password = "admin", Role = "Admin" }
    };

    public User Login(string email, string password)
    {
        ValidateEmail(email);

        var user = users.FirstOrDefault(u => u.Email == email);

        if (user == null)
            throw new Exception("User not found");

        if (user.Password != password)
            throw new Exception("Wrong password");

        return user;
    }
    
    private void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new Exception("Invalid email format");

        if (!email.EndsWith("@via.dk"))
            throw new Exception("Only @via.dk emails are allowed");
    }
}