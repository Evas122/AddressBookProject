using AddressBook.Infrastructure.Data;

namespace AddressBook.Infrastructure.Repositories
{
    public class CityRepository
    {
        private readonly AddressBookDbContext _dbContext;

        public CityRepository(AddressBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



    }
}