using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
