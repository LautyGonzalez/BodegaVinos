using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces.Respository
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetAll();
        Wine GetById(int id);
        void Add(Wine wine);
        void Update(Wine wine);
        void Delete(int id);
        IEnumerable<Wine> GetWineByVariety(string variety);

        Wine UpdateStockById(int id, int newStock);
    }
}
