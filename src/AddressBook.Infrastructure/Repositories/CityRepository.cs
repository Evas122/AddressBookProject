using AddressBook.Core.Entities;
using AddressBook.Core.Exceptions;
using AddressBook.Core.Interfaces.Repositories;
using AddressBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Infrastructure.Repositories
{

    public class CityRepository : ICityRepository
    {
        private readonly AddressBookDbContext _dbContext;

        public CityRepository(AddressBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<City> GetAll()
        {
            return _dbContext.Cities.ToList();
        }

        public City GetById(int id)
        {
            var city = _dbContext.Cities.Find(id);
            if (city == null)
            {
                throw new EntityNotFoundException($"City with ID {id} not found.");
            }
            return city;
        }

        public void AddCity(City city)
        {
            try
            {
                _dbContext.Cities.Add(city);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to add city.", ex);
            }
        }

        public void UpdateCity(City city)
        {
            var existing = _dbContext.Cities.Find(city.Id);
            if (existing == null)
            {
                throw new EntityNotFoundException($"City with ID {city.Id} not found.");
            }

            try
            {
                _dbContext.Entry(existing).CurrentValues.SetValues(city);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to update city.", ex);
            }
        }

        public void RemoveCity(int id)
        {
            var city = _dbContext.Cities.Find(id);
            if (city == null)
            {
                throw new EntityNotFoundException($"City with ID {id} not found.");
            }

            try
            {
                _dbContext.Cities.Remove(city);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to remove city.", ex);
            }
        }
    }
}