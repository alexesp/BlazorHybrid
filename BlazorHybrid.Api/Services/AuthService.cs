using BlazorHybrid.Api.Data;
using BlazorHybrid.Api.Data.Entities;
using BlazorHybrid.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorHybrid.Api.Services
{
    public class AuthService
    {
        private readonly QuizContext _context;
        private IPasswordHasher<User> _passwordHasher;

        public AuthService(QuizContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .AsNoTracking().FirstOrDefaultAsync(u => u.Email == dto.Username);

            if (user == null)
            {
                return;
            }
          var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if(passwordResult == PasswordVerificationResult.Failed)
            {
                return;
            }
        }
    }
}
