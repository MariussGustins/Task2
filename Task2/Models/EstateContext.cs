using Microsoft.EntityFrameworkCore;

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
        }
    }

}
