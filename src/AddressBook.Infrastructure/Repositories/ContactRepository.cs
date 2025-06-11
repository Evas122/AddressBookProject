using AddressBook.Core.Dtos;
using AddressBook.Core.Entities;
using AddressBook.Core.Exceptions;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookDbContext _dbContext;

        public ContactRepository(AddressBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ContactViewDto> GetAllFromView()
        {
            return _dbContext.Database.SqlQuery<ContactViewDto>("SELECT * FROM ContactView")
                .ToList();
        }

        public void AddContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Add(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to add contact.", ex);
            }
        }

        public void RemoveContact(int id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact == null)
            {
                throw new EntityNotFoundException($"Contact with ID {id} not found.");
            }

            try
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to remove contact.", ex);
            }
        }

        public void UpdateContact(Contact contact)
        {
            var existing = _dbContext.Contacts.Find(contact.Id);
            if (existing == null)
            {
                throw new EntityNotFoundException($"Contact with ID {contact.Id} not found.");
            }

            try
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to update contact.", ex);
            }
        }

        public Contact GetById(int id)
        {
            var contact = _dbContext.Contacts.Find(id);
            if (contact == null)
            {
                throw new EntityNotFoundException($"Contact with ID {id} not found.");
            }
            return contact;
        }
    }
}