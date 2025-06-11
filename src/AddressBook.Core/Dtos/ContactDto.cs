namespace AddressBook.Core.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
    }
}