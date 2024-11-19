using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;
using BodegaVinos.Interfaces.Services;
using BodegaVinos.Repositories;

namespace BodegaVinos.Services
{
    public class CataService : ICataService
    {
        private readonly ICataRepository _cataRepository;

        public CataService(ICataRepository cataRepository) => _cataRepository = cataRepository;

        public void CreateCata(Cata cata)
        {
            if (cata.Date <= DateTime.Now)
            {
                throw new ArgumentException("La fecha de la cata debe ser futura");
            }

            _cataRepository.Add(cata);
        }

        public IEnumerable<Cata> GetAllCatasDisp()
        {
            return _cataRepository.GetAll();
        }

        public void UpdateCata(Cata cata)
        {
            _cataRepository.Update(cata);
        }
    }
}
