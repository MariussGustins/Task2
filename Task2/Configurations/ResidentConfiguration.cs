using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Models;

namespace Task2.Configurations
{
    public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.LastName).IsRequired();
            builder.Property(r => r.PersonalNumber).IsRequired();
            builder.Property(r => r.Birthday).IsRequired();
            builder.Property(r => r.PhoneNumber).IsRequired();
            builder.Property(r => r.Email).IsRequired();

            
            // Relationships
            builder.HasMany(r => r.Apartments)
                .WithOne(a => a.PrimaryResident)
                .HasForeignKey(a => a.PrimaryResidentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}