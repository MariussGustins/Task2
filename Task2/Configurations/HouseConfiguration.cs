using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Models;

namespace Task2.Configurations
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).ValueGeneratedOnAdd();
            builder.Property(h => h.Number).IsRequired();
            builder.Property(h => h.Street).IsRequired();
            builder.Property(h => h.City).IsRequired();
            builder.Property(h => h.Country).IsRequired();
            builder.Property(h => h.Postcode).IsRequired();

            
            builder.HasMany(h => h.Apartments)
                .WithOne(a => a.House)
                .HasForeignKey(a => a.HouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}