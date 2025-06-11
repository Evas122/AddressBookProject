using AddressBook.Core.Dtos;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Extensions.Mappings
{
    public static class CityExtension
    {
        public static CityDto ToDto(this City city)
        {
            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                ZipCode = city.ZipCode,
            };
        }

        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                Id = dto.Id,
                Name = dto.Name,
                ZipCode = dto.ZipCode,
            };
        }
    }
}