using BodegaVinos.Entities;
using BodegaVinos.Interfaces;

namespace BodegaVinos.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        private int _nextId = 1;

        public IEnumerable<User> GetAll() => _users;

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
                _users[index] = user;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
                _users.Remove(user);
        }
    }
}