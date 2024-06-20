namespace Task2.DTOs
{
    public class ApartmentDto
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public int NumberOfResidents { get; set; }
        public double FullArea { get; set; }
        public double LivingArea { get; set; }
        public ICollection<ResidentDto> Residents { get; set; }
        public int? PrimaryResidentId { get; set; }
    }
}
