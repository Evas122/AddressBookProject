using AddressBook.Core.Entities;
using System.Collections.Generic;

namespace AddressBook.Core.Interfaces.Repositories
{
    public interface ICityRepository
    {
        void AddCity(City city);
        IEnumerable<City> GetAll();
        City GetById(int id);
        void RemoveCity(int id);
        void UpdateCity(City city);
    }
}