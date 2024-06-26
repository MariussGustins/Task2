namespace Task2.DTOs
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public int NumberOfResidents { get; set; }
        public double FullArea { get; set; }
        public double LivingArea { get; set; }
        public int HouseId { get; set; }
        public ICollection<ResidentDto> Residents { get; set; }
        public int? PrimaryResidentId { get; set; }
    }
}
