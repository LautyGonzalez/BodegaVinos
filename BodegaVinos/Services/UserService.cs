using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;
using BodegaVinos.Interfaces.Services;

namespace BodegaVinos.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();

        public User GetUserById(int id) => _userRepository.GetById(id);

        public void AddUser(User user) => _userRepository.Add(user);

        public void UpdateUser(User user) => _userRepository.Update(user);

        public void DeleteUser(int id) => _userRepository.Delete(id);

        public User? AuthenticateUser(string username, string password)
        {
            User? userToReturn = _userRepository.Get(username);
            if (userToReturn is not null && userToReturn.Password == password)
                return userToReturn;
            return null;
        }
    }
}
