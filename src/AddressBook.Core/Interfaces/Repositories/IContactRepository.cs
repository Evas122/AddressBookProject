using AddressBook.Core.Dtos;
using AddressBook.Core.Entities;
using System.Collections.Generic;

namespace AddressBook.Core.Interfaces.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        IEnumerable<ContactViewDto> GetAllFromView();
        Contact GetById(int id);
        void RemoveContact(int id);
        void UpdateContact(Contact contact);
    }
}