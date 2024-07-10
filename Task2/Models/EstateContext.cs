using Microsoft.EntityFrameworkCore;
using Task2.Configurations;

namespace Task2.Models
{
    public class EstateContext : DbContext
    {
        public EstateContext(DbContextOptions<EstateContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Resident>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Resident>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Resident>()
                .Property(r => r.IsOwner)
                .HasColumnName("IsOwner")
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<Resident>()
                .HasIndex(r => r.PersonalNumber)
                .IsUnique();

            // Define the relationship between Resident and User
            modelBuilder.Entity<Resident>()
                .HasOne(r => r.User)
                .WithOne()
                .HasForeignKey<Resident>(r => r.UserId)
                .IsRequired(false) // Allow nullable UserId for now
                .OnDelete(DeleteBehavior.SetNull); // Set UserId to null if User is deleted

            // Seed data for Residents (without UserId initially)
            modelBuilder.Entity<Resident>().HasData(
                new Resident
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    PersonalNumber = "12345-67890",
                    Birthday = new DateOnly(1985, 4, 23),
                    PhoneNumber = 27497659,
                    Email = "john.doe@example.com",
                    ApartmentId = 1,
                    IsOwner = true,
                    UserId = 2,
                    Username = "JohnDoe",
                    Password = "DefaultPassword123"
                },
                new Resident
                {
                    Id = 2,
                    Name = "Jane",
                    LastName = "Smith",
                    PersonalNumber = "09876-54321",
                    Birthday = new DateOnly(1985, 8, 20),
                    PhoneNumber = 274547639,
                    Email = "jane.smith@example.com",
                    ApartmentId = 2,
                    IsOwner = true,
                    UserId = 3,
                    Username = "JaneSmith",
                    Password = "DefaultPassword123"
                },
                new Resident
                {
                    Id = 3,
                    Name = "Michael",
                    LastName = "Johnson",
                    PersonalNumber = "24680-13579",
                    Birthday = new DateOnly(1982, 10, 12),
                    PhoneNumber = 23494655,
                    Email = "michael.johnson@example.com",
                    ApartmentId = 2,
                    IsOwner = false,
                    UserId = 4,
                    Username = "MichealJohnson",
                    Password = "DefaultPassword123"
                },
                new Resident
                {
                    Id = 4,
                    Name = "Emily",
                    LastName = "Williams",
                    PersonalNumber = "13579-24680",
                    Birthday = new DateOnly(1995, 3, 25),
                    PhoneNumber = 26497153,
                    Email = "emily.williams@example.com",
                    ApartmentId = 3,
                    IsOwner = true,
                    UserId = 5,
                    Username = "EmilyWilliams",
                    Password = "DefaultPassword123"
                }
            );
        }
    }
}
