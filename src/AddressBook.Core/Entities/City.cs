using System.Collections.Generic;

namespace AddressBook.Core.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}