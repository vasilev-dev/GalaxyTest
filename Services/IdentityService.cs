using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GalaxyTest.Contexts;
using GalaxyTest.Models;
using GalaxyTest.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using AppDbContext = GalaxyTest.Contexts.AppDbContext;


namespace GalaxyTest.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return new AuthResult
                {
                    Errors = new [] { $"User not exists!" }
                };
            }

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
            {
                return new AuthResult
                {
                    Errors = new[] {"Username or(and) password are wrong!"}
                };
            }

            return await GetAuthResultAsync(user);
        }

        public async Task<AuthResult> RegisterAsync(string username, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(username);

            if (existingUser != null)
            {
                return new AuthResult
                {
                    Errors = new[] { $"User with username {username} already exist" }
                };
            }

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = username
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return await GetAuthResultAsync(newUser);
        }


        private async Task<AuthResult> GetAuthResultAsync(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id)
            };

            var usersClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(usersClaims);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
