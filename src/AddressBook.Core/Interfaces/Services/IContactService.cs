using AddressBook.Core.Dtos;
using System.Collections.Generic;

namespace AddressBook.Core.Interfaces.Services
{
    public interface IContactService
    {
        void AddContact(ContactDto dto);
        IEnumerable<ContactViewDto> GetAllContacts(string searchTerm = null);
        ContactDto GetContactById(int id);
        void RemoveContact(int id);
        void UpdateContact(ContactDto dto);
    }
}