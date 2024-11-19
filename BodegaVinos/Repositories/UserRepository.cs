using BodegaVinos.Data;
using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;


namespace BodegaVinos.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BodegaContext _context;

        public UserRepository(BodegaContext context)
        {
            _context = context;
        }


        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public User? Get(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}