using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces.Services
{
    public interface IWineService
    {
        IEnumerable<Wine> GetAllWines();
        Wine GetWineById(int id);
        void AddWine(Wine wine);
        void UpdateWine(Wine wine);
        void DeleteWine(int id);

        IEnumerable<Wine> GetWineByVariety(string variety);

        Wine UpdateStockById(int id, int newStock);
    }
}
