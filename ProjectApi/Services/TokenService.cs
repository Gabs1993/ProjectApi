using BasicApi.Data;
using BasicApi.Interface;
using Microsoft.IdentityModel.Tokens;
using ProjectApi.Data;
using ProjectApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectApi.Services
{
    public class TokenServices : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly Context _context;

        public TokenServices(IConfiguration configuration, Context context)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["chaveSecreta"]));
            _context = context;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email),
            };

            var credenciais = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciais,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }

        public string Login(string email, string providedPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            if (VerifyPassword(providedPassword, user.Password))
            {
                return CreateToken(user);
            }

            return null;
        }
    }
}
