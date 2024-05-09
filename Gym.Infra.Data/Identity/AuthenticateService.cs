using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Gym.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;

        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration, IRoleRepository roleRepository)
        {
            _context = context;
            _configuration = configuration;
            _roleRepository = roleRepository;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return false;
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != user.PasswordHash[x]) return false;
            }

            return true;
        }

        public async Task<string> GenerateToken(string email, Guid id)
        {
            var user = await GetUserByEmail(email);
            var role = await _roleRepository.GetById(user.RoleId);

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email.ToLower()),
                new Claim("name", user.Name.ToLower()),
                new Claim("role", role.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> UserExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if(user == null)
            {
                throw new Exception($"Usuário não encontrado pelo Email: {email}");
            }

            return user;
        }
    }
}
