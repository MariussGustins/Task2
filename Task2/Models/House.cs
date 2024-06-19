using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Task2.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }


}
