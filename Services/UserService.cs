using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UserService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher) : IUserService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            return verificationResult == PasswordVerificationResult.Success ? user : null;
        }

        public async Task<User> Create(User user, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                return null;

            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
