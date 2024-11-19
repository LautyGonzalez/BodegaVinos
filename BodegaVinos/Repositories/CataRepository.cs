using BodegaVinos.Data;
using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Repositories
{
    public class CataRepository : ICataRepository
    {
        private readonly BodegaContext _context;

        public CataRepository(BodegaContext context)
        {
            _context = context;
        }

        public IEnumerable<Cata> GetAll()
        {
            return _context.Catas
                .Include(c => c.Wines)
                .ToList();
        }

        public Cata GetById(int id)
        {
            return _context.Catas
                .Include(c => c.Wines)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Cata cata)
        {
            _context.Catas.Add(cata);
            _context.SaveChanges();
        }

        public void Update(Cata cata)
        {
            var existingCata = _context.Catas
                .Include(c => c.Wines)
                .FirstOrDefault(c => c.Id == cata.Id);

            if (existingCata != null)
            {

                _context.Entry(existingCata).CurrentValues.SetValues(cata);

                existingCata.Wines.Clear();
                foreach (var wine in cata.Wines)
                {
                    existingCata.Wines.Add(wine);
                }

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var cata = _context.Catas.Find(id);
            if (cata != null)
            {
                _context.Catas.Remove(cata);
                _context.SaveChanges();
            }
        }
    }
}