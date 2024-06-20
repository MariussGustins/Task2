using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Models;

namespace Task2.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Number).IsRequired();
            builder.Property(a => a.Floor).IsRequired();

            // Relationships
            builder.HasOne(a => a.House)
                .WithMany(h => h.Apartments)
                .HasForeignKey(a => a.HouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}