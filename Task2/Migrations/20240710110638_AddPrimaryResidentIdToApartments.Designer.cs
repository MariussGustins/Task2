﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task2.Models;

#nullable disable

namespace Task2.Migrations
{
    [DbContext(typeof(EstateContext))]
    [Migration("20240710110638_AddPrimaryResidentIdToApartments")]
    partial class AddPrimaryResidentIdToApartments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task2.Models.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<double>("FullArea")
                        .HasColumnType("float");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<double>("LivingArea")
                        .HasColumnType("float");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfResidents")
                        .HasColumnType("int");

                    b.Property<int?>("PrimaryResidentId")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("PrimaryResidentId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Task2.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Task2.Models.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsOwner");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("PersonalNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Residents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApartmentId = 1,
                            Birthday = new DateOnly(1985, 4, 23),
                            Email = "john.doe@example.com",
                            IsOwner = true,
                            LastName = "Doe",
                            Name = "John",
                            Password = "DefaultPassword123",
                            PersonalNumber = "12345-67890",
                            PhoneNumber = 27497659,
                            UserId = 2,
                            Username = "JohnDoe"
                        },
                        new
                        {
                            Id = 2,
                            ApartmentId = 2,
                            Birthday = new DateOnly(1985, 8, 20),
                            Email = "jane.smith@example.com",
                            IsOwner = true,
                            LastName = "Smith",
                            Name = "Jane",
                            Password = "DefaultPassword123",
                            PersonalNumber = "09876-54321",
                            PhoneNumber = 274547639,
                            UserId = 3,
                            Username = "JaneSmith"
                        },
                        new
                        {
                            Id = 3,
                            ApartmentId = 2,
                            Birthday = new DateOnly(1982, 10, 12),
                            Email = "michael.johnson@example.com",
                            IsOwner = false,
                            LastName = "Johnson",
                            Name = "Michael",
                            Password = "DefaultPassword123",
                            PersonalNumber = "24680-13579",
                            PhoneNumber = 23494655,
                            UserId = 4,
                            Username = "MichealJohnson"
                        },
                        new
                        {
                            Id = 4,
                            ApartmentId = 3,
                            Birthday = new DateOnly(1995, 3, 25),
                            Email = "emily.williams@example.com",
                            IsOwner = true,
                            LastName = "Williams",
                            Name = "Emily",
                            Password = "DefaultPassword123",
                            PersonalNumber = "13579-24680",
                            PhoneNumber = 26497153,
                            UserId = 5,
                            Username = "EmilyWilliams"
                        });
                });

            modelBuilder.Entity("Task2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Task2.Models.Apartment", b =>
                {
                    b.HasOne("Task2.Models.House", "House")
                        .WithMany("Apartments")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task2.Models.Resident", "PrimaryResident")
                        .WithMany()
                        .HasForeignKey("PrimaryResidentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("House");

                    b.Navigation("PrimaryResident");
                });

            modelBuilder.Entity("Task2.Models.Resident", b =>
                {
                    b.HasOne("Task2.Models.Apartment", "Apartment")
                        .WithMany("Residents")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Task2.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Task2.Models.Resident", "UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Apartment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task2.Models.Apartment", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("Task2.Models.House", b =>
                {
                    b.Navigation("Apartments");
                });
#pragma warning restore 612, 618
        }
    }
}
