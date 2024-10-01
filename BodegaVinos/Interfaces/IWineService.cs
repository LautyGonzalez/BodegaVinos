using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces
{
    public interface IWineService
    {
        IEnumerable<Wine> GetAllWines();
        Wine GetWineById(int id);
        void AddWine(Wine wine);
        void UpdateWine(Wine wine);
        void DeleteWine(int id);
    }
}
