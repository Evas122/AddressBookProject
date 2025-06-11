using AddressBook.Core.Dtos;
using AddressBook.Core.Extensions.Mappings;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Services
{
    /// <summary>
    /// Service responsible for managing contact-related operations.
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="contactRepository">Repository for contact data operations.</param>
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Retrieves all contacts optionally filtered by a search term.
        /// </summary>
        /// <param name="searchTerm">Optional term to filter contacts by first name, last name, phone number, city name, or zip code.</param>
        /// <returns>A collection of <see cref="ContactViewDto"/> matching the search criteria.</returns>
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

        /// <summary>
        /// Retrieves a contact by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>A <see cref="ContactDto"/> representing the contact.</returns>
        public ContactDto GetContactById(int id)
        {
            var contact = _contactRepository.GetById(id);
            return contact.ToDto();
        }

        /// <summary>
        /// Adds a new contact based on the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object containing contact details.</param>
        public void AddContact(ContactDto dto)
        {
            var contact = dto.ToEntity();
            _contactRepository.AddContact(contact);
        }

        /// <summary>
        /// Updates an existing contact using the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object with updated contact information.</param>
        public void UpdateContact(ContactDto dto)
        {
            var contact = dto.ToEntity();
            _contactRepository.UpdateContact(contact);
        }

        /// <summary>
        /// Removes a contact by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to remove.</param>
        public void RemoveContact(int id)
        {
            _contactRepository.RemoveContact(id);
        }
    }
}