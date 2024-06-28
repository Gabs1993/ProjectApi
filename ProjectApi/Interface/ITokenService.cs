
using ProjectApi.Models;

namespace BasicApi.Interface
{
    public interface ITokenService
    {
        string CreateToken(User user);
        bool VerifyPassword(string providedPassword, string hashedPassword);
        string Login(string email, string providedPassword);
    }
}
