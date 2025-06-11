using AddressBook.Core.Dtos;
using AddressBook.Core.Extensions.Mappings;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Services
{
    /// <summary>
    /// Service responsible for managing city-related operations.
    /// </summary>
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityService"/> class.
        /// </summary>
        /// <param name="cityRepository">Repository for city data operations.</param>
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        /// <summary>
        /// Retrieves all cities as DTOs.
        /// </summary>
        public IEnumerable<CityDto> GetAllCities()
        {
            return _cityRepository.GetAll().Select(c => c.ToDto());
        }

        /// <summary>
        /// Retrieves a city by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the city.</param>
        /// <returns>A <see cref="CityDto"/> representing the city.</returns>
        public CityDto GetCityById(int id)
        {
            var city = _cityRepository.GetById(id);
            return city.ToDto();
        }

        /// <summary>
        /// Adds a new city based on the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object containing city details.</param>
        public void AddCity(CityDto dto)
        {
            var city = dto.ToEntity();
            _cityRepository.AddCity(city);
        }

        /// <summary>
        /// Updates an existing city using the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object with updated city information.</param>
        public void UpdateCity(CityDto dto)
        {
            var city = dto.ToEntity();
            _cityRepository.UpdateCity(city);
        }

        /// <summary>
        /// Removes a city by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the city to remove.</param>
        public void RemoveCity(int id)
        {
            _cityRepository.RemoveCity(id);
        }
    }
}