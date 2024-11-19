using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces.Services
{
    public interface ICataService
    {
        IEnumerable<Cata> GetAllCatasDisp();

        void CreateCata(Cata cata);

        void UpdateCata(Cata cata);

    }
}
