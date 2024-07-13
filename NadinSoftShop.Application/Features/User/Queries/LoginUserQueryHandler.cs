using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NadinSoftShop.Application.Contracts.User;
using NadinSoftShop.Domain.User.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NadinSoftShop.Application.Features.User.Queries
{
    public class LoginUserQueryHandler : ILoginUserQueryHandler
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginUserQueryHandler(SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> LoginUserHandler(string email, string password)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);

            if (loginResult.Succeeded)
            {
                return GenerateToken(email);
            }

            return "Username or password is invalid!";
        }

        private string GenerateToken(string email)
        {
            var userId = _userManager.Users
                .FirstOrDefault(x => x.Email == email).Id;

            var claims = new[] {
                new Claim("UserName", email),
                new Claim("Email", email),
                new Claim("UserId", userId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}