using BodegaVinos.Entities;
using BodegaVinos.Interfaces;

namespace BodegaVinos.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly List<Wine> _wines = new List<Wine>();
        private int _nextId = 1;

        public IEnumerable<Wine> GetAll() => _wines;

        public Wine GetById(int id) => _wines.FirstOrDefault(w => w.Id == id);

        public void Add(Wine wine)
        {
            wine.Id = _nextId++;
            _wines.Add(wine);
        }

        public void Update(Wine wine)
        {
            var index = _wines.FindIndex(w => w.Id == wine.Id);
            if (index != -1)
                _wines[index] = wine;
        }

        public void Delete(int id)
        {
            var wine = GetById(id);
            if (wine != null)
                _wines.Remove(wine);
        }
    }
}