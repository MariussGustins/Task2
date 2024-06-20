namespace Task2.DTOs
{
    public class ResidentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateOnly Birthday { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsOwner { get; set; }
    }
}
