using System.Collections.Generic;
using BodegaVinos.Entities;

namespace BodegaVinos.Interfaces
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetAll();
        Wine GetById(int id);
        void Add(Wine wine);
        void Update(Wine wine);
        void Delete(int id);
    }
}
