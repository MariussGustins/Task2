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
    [Migration("20240620155646_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

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

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("Task2.Models.Apartment", b =>
                {
                    b.HasOne("Task2.Models.House", "House")
                        .WithMany("Apartments")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
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
#pragma warning restore 612, 618
        }
    }
}
