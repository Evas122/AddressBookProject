using System;

namespace AddressBook.Core.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}