using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces.Respository
{
    public interface ICataRepository
    {
        IEnumerable<Cata> GetAll();

        void Add(Cata cata);

        void Update(Cata cata);

    }
}
