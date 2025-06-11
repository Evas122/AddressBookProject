using AddressBook.Core.Dtos;
using AddressBook.Core.Entities;

namespace AddressBook.Core.Extensions.Mappings
{
    public static class ContactExtension
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                BirthDate = contact.BirthDate,
                PhoneNumber = contact.PhoneNumber,
                IsActive = contact.IsActive,
                CityId = contact.CityId
            };
        }

        public static Contact ToEntity(this ContactDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
                IsActive = dto.IsActive,
                CityId = dto.CityId
            };
        }
    }
}