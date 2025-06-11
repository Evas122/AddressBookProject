using AddressBook.Core.Entities;
using System.Data.Entity;

namespace AddressBook.Infrastructure.Data
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext() : base("name=DefaultConnection") { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasRequired(c => c.City)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CityId);

            base.OnModelCreating(modelBuilder);
        }

    }
}