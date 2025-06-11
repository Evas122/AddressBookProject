using AddressBook.Core.Dtos;
using AddressBook.Core.Extensions.Mappings;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<CityDto> GetAllCities()
        {
            return _cityRepository.GetAll().Select(c => c.ToDto());
        }

        public CityDto GetCityById(int id)
        {
            var city = _cityRepository.GetById(id);
            return city.ToDto();
        }

        public void AddCity(CityDto dto)
        {
            var city = dto.ToEntity();
            _cityRepository.AddCity(city);
        }

        public void UpdateCity(CityDto dto)
        {
            var city = dto.ToEntity();
            _cityRepository.UpdateCity(city);
        }

        public void RemoveCity(int id)
        {
            _cityRepository.RemoveCity(id);
        }
    }
}