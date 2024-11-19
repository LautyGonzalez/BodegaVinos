using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;
using BodegaVinos.Interfaces.Services;
using System.Collections.Generic;

namespace BodegaVinos.Services
{
    public class WineService : IWineService
    {
        private readonly IWineRepository _wineRepository;

        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public IEnumerable<Wine> GetAllWines() => _wineRepository.GetAll();

        public Wine GetWineById(int id) => _wineRepository.GetById(id);

        public void AddWine(Wine wine) => _wineRepository.Add(wine);

        public void UpdateWine(Wine wine) => _wineRepository.Update(wine);

        public void DeleteWine(int id) => _wineRepository.Delete(id);
        public IEnumerable<Wine> GetWineByVariety(string variety) => _wineRepository.GetWineByVariety(variety);

        public Wine UpdateStockById(int id, int newStock) => _wineRepository.UpdateStockById(id, newStock);
    }
}
