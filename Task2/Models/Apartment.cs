using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Task2.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public int NumberOfResidents { get; set; }
        public double FullArea { get; set; }
        public double LivingArea { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public int PrimaryResidentId { get; set; }
        public Resident PrimaryResident { get; set; }

        public ICollection<Resident> Residents { get; set; }
        
        


    }
}
