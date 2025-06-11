using AddressBook.Core.Dtos;
using AddressBook.Core.Extensions.Mappings;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<ContactViewDto> GetAllContacts(string searchTerm = null)
        {
            var contacts = _contactRepository.GetAllFromView();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                contacts = contacts.Where(c =>
                    (c.FirstName?.ToLower().Contains(searchTerm) ?? false) ||
                    (c.LastName?.ToLower().Contains(searchTerm) ?? false) ||
                    (c.PhoneNumber?.ToLower().Contains(searchTerm) ?? false) ||
                    (c.CityName?.ToLower().Contains(searchTerm) ?? false) ||
                    (c.ZipCode?.ToLower().Contains(searchTerm) ?? false));
            }

            return contacts;
        }

        public ContactDto GetContactById(int id)
        {
            var contact = _contactRepository.GetById(id);
            return contact.ToDto();
        }

        public void AddContact(ContactDto dto)
        {
            var contact = dto.ToEntity();
            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(ContactDto dto)
        {
            var contact = dto.ToEntity();
            _contactRepository.UpdateContact(contact);
        }

        public void RemoveContact(int id)
        {
            _contactRepository.RemoveContact(id);
        }
    }
}