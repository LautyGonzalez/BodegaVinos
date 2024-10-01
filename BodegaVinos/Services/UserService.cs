using BodegaVinos.Interfaces;
using BodegaVinos.Entities;

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
    }
}
