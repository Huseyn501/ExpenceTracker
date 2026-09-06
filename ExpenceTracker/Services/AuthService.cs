using ExpenceTracker.Data;
using ExpenceTracker.DTOs.UserDTOs;
using ExpenceTracker.Models;
using ExpenceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenceTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly IPasswordHasher<User> _passwordHash;

        public AuthService(AppDbContext context, IConfiguration config, IPasswordHasher<User> passwordHash)
        {
            _context = context;
            _config = config;
            _passwordHash = passwordHash;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto Dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == Dto.Email);
                if(user == null) return null;
            var result = _passwordHash.VerifyHashedPassword(user, user.Password, Dto.Passoword);
            if (result == PasswordVerificationResult.Failed) return null;

            return GenerateAuthResponce(user);
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto Dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == Dto.Email))
                return null;
            var user = new User()
            {
                Name = Dto.Name,
                Email = Dto.Email,
            };

            user.Password = _passwordHash.HashPassword(user, Dto.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return GenerateAuthResponce(user);


        }

        private AuthResponseDto GenerateAuthResponce(User user)
        {
            var claims = new[]
         {
                new Claim(ClaimTypes.NameIdentifier, user.Id), 
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponseDto()
            {
                UserId = user.Id,
                UserName = user.Name,
                Token = tokenString,
            };
        }
    
    }
}
