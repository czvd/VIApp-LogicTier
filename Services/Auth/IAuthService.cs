using Entities;

namespace Services;

public interface IAuthService
{
    User Login(string email, string password);
}