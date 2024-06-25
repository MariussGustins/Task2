using Microsoft.AspNetCore.Mvc;

namespace Task2.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateOnly Birthday { get; set; }

        public int PhoneNumber { get; set; }
        public string Email {  get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        
        public bool IsOwner { get; set; }
        
        // public ICollection<Apartment> Apartments { get; set; }
    }
}
