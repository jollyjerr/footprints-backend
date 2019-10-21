using System;
using System.Threading.Tasks;
using footprints.Models;

namespace footprints.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<User> Register(User userToCreate, string password, Vehicle vehicleToCreate, House houseToCreate);
    }
}