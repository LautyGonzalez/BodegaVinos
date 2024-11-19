using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User? AuthenticateUser(string username, string password);
    }
}
