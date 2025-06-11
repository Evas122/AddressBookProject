using System;

namespace AddressBook.Core.Dtos
{
    public class ContactViewDto
    {
        public int Id { get; set; }                  
        public string FirstName { get; set; }         
        public string LastName { get; set; }         
        public string PhoneNumber { get; set; }       
        public DateTime BirthDate { get; set; }       
        public bool IsActive { get; set; }            
        public string CityName { get; set; }           
        public string ZipCode { get; set; }           
    }
}