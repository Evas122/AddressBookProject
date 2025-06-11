using AddressBook.Core.Dtos;
using System.Collections.Generic;

namespace AddressBook.Core.Interfaces.Services
{
    public interface ICityService
    {
        void AddCity(CityDto dto);
        IEnumerable<CityDto> GetAllCities();
        CityDto GetCityById(int id);
        void RemoveCity(int id);
        void UpdateCity(CityDto dto);
    }
}