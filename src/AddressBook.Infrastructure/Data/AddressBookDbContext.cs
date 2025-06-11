using AddressBook.Core.Entities;
using System.Data.Entity;

namespace AddressBook.Infrastructure.Data
{
    /// <summary>
    /// Entity Framework database context for the Address Book application.
    /// </summary>
    public class AddressBookDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookDbContext"/> class
        /// using the default connection string named "DefaultConnection".
        /// </summary>
        public AddressBookDbContext() : base("name=DefaultConnection") { }

        /// <summary>
        /// Gets or sets the DbSet representing contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing cities.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Configures the relationships and mappings for the model.
        /// Sets required relationship between Contact and City.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
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