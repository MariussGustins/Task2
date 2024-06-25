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
    [Migration("20240621112413_AddIsOwnerColumn")]
    partial class AddIsOwnerColumn
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

                    b.Property<int?>("ResidentId")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("PrimaryResidentId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Floor = 2,
                            FullArea = 40.5,
                            HouseId = 1,
                            LivingArea = 38.5,
                            Number = 5,
                            NumberOfResidents = 2,
                            Rooms = 1
                        },
                        new
                        {
                            Id = 2,
                            Floor = 2,
                            FullArea = 70.5,
                            HouseId = 1,
                            LivingArea = 68.5,
                            Number = 3,
                            NumberOfResidents = 2,
                            Rooms = 2
                        },
                        new
                        {
                            Id = 3,
                            Floor = 1,
                            FullArea = 93.5,
                            HouseId = 2,
                            LivingArea = 86.5,
                            Number = 1,
                            NumberOfResidents = 2,
                            Rooms = 3
                        },
                        new
                        {
                            Id = 4,
                            Floor = 1,
                            FullArea = 80.5,
                            HouseId = 2,
                            LivingArea = 68.5,
                            Number = 2,
                            NumberOfResidents = 1,
                            Rooms = 2
                        },
                        new
                        {
                            Id = 5,
                            Floor = 2,
                            FullArea = 50.0,
                            HouseId = 2,
                            LivingArea = 45.899999999999999,
                            Number = 6,
                            NumberOfResidents = 1,
                            Rooms = 1
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Springfield",
                            Country = "USA",
                            Number = "123",
                            Postcode = "12345",
                            Street = "Elm Street"
                        },
                        new
                        {
                            Id = 2,
                            City = "Springfield",
                            Country = "USA",
                            Number = "456",
                            Postcode = "67890",
                            Street = "Maple Avenue"
                        });
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
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("PersonalNumber")
                        .IsUnique();

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
                            PersonalNumber = "12345-67890",
                            PhoneNumber = 27497659
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
                            PersonalNumber = "09876-54321",
                            PhoneNumber = 274547639
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
                            PersonalNumber = "24680-13579",
                            PhoneNumber = 23494655
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
                            PersonalNumber = "13579-24680",
                            PhoneNumber = 26497153
                        });
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
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Task2.Models.Resident", null)
                        .WithMany("Apartments")
                        .HasForeignKey("ResidentId");

                    b.Navigation("House");

                    b.Navigation("PrimaryResident");
                });

            modelBuilder.Entity("Task2.Models.Resident", b =>
                {
                    b.HasOne("Task2.Models.Apartment", "Apartment")
                        .WithMany("Residents")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("Task2.Models.Apartment", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("Task2.Models.House", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("Task2.Models.Resident", b =>
                {
                    b.Navigation("Apartments");
                });
#pragma warning restore 612, 618
        }
    }
}
