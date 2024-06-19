namespace Task2.Models
{
    public class HouseDto
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public ICollection<ApartmentDto> Apartments { get; set; }
    }
}
