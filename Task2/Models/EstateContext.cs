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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            
            modelBuilder.Entity<House>()
                .HasKey(h => h.Id);

            modelBuilder.Entity<House>()
                .Property(h => h.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<House>()
                .HasMany(h => h.Apartments)
                .WithOne(a => a.House)
                .HasForeignKey(a => a.HouseId);

            modelBuilder.Entity<Apartment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Apartment>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Residents)
                .WithOne(r => r.Apartment)
                .HasForeignKey(r => r.ApartmentId);

            modelBuilder.Entity<Resident>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Resident>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            //seed for Houses
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Number = "123",
                    Street = "Elm Street",
                    City = "Springfield",
                    Country = "USA",
                    Postcode = "12345"
                },
                new House
                {
                    Id = 2,
                    Number = "456",
                    Street = "Maple Avenue",
                    City = "Springfield",
                    Country = "USA",
                    Postcode = "67890"
                }
            );

            //seed for Apartments

            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    Id = 1,
                    Number = 5,
                    Floor = 2,
                    Rooms = 1,
                    NumberOfResidents = 2,
                    FullArea = 40.5,
                    LivingArea = 38.5,
                    HouseId = 1

                },
                new Apartment
                {
                    Id = 2,
                    Number = 3,
                    Floor = 2,
                    Rooms = 2,
                    NumberOfResidents = 2,
                    FullArea = 70.5,
                    LivingArea = 68.5,
                    HouseId = 1
                },
                new Apartment
                {
                    Id = 3,
                    Number = 1,
                    Floor = 1,
                    Rooms = 3,
                    NumberOfResidents = 2,
                    FullArea = 93.5,
                    LivingArea = 86.5,
                    HouseId = 2
                },
                new Apartment
                {
                    Id = 4,
                    Number = 2,
                    Floor = 1,
                    Rooms = 2,
                    NumberOfResidents = 1,
                    FullArea = 80.5,
                    LivingArea = 68.5,
                    HouseId = 2,
                },
                new Apartment
                {
                Id = 5,
                Number = 6,
                Floor = 2,
                Rooms = 1,
                NumberOfResidents = 1,
                FullArea = 50,
                LivingArea = 45.9,
                HouseId = 2
        }
        );
            
            //seed for Residents

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
                    IsOwner = true
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
                    IsOwner = true
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
                    IsOwner = false
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
                    IsOwner = true
                }
                );
        }
    }

}
