using System;
using System.Threading.Tasks;
using footprints.Models;

namespace footprints.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<User> Register(User userToCreate, string password);
    }
}