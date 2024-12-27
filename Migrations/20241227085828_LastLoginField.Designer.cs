﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CorporateOffers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CorporateOffers.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241227085828_LastLoginField")]
    partial class LastLoginField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CityOffer", b =>
                {
                    b.Property<int>("CitiesId")
                        .HasColumnType("integer")
                        .HasColumnName("CityId");

                    b.Property<int>("OffersId")
                        .HasColumnType("integer")
                        .HasColumnName("OfferId");

                    b.HasKey("CitiesId", "OffersId");

                    b.HasIndex("OffersId");

                    b.ToTable("cityToOffer", (string)null);

                    b.HasData(
                        new
                        {
                            CitiesId = 1,
                            OffersId = 1
                        },
                        new
                        {
                            CitiesId = 2,
                            OffersId = 1
                        },
                        new
                        {
                            CitiesId = 3,
                            OffersId = 1
                        },
                        new
                        {
                            CitiesId = 1,
                            OffersId = 2
                        },
                        new
                        {
                            CitiesId = 2,
                            OffersId = 2
                        },
                        new
                        {
                            CitiesId = 4,
                            OffersId = 2
                        },
                        new
                        {
                            CitiesId = 3,
                            OffersId = 3
                        },
                        new
                        {
                            CitiesId = 4,
                            OffersId = 3
                        },
                        new
                        {
                            CitiesId = 1,
                            OffersId = 4
                        },
                        new
                        {
                            CitiesId = 3,
                            OffersId = 4
                        },
                        new
                        {
                            CitiesId = 2,
                            OffersId = 5
                        },
                        new
                        {
                            CitiesId = 3,
                            OffersId = 5
                        },
                        new
                        {
                            CitiesId = 4,
                            OffersId = 5
                        });
                });

            modelBuilder.Entity("CorporateOffers.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Отдых"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дети"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Отели"
                        });
                });

            modelBuilder.Entity("CorporateOffers.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Москва"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Санкт-Петербург"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Иркутск"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Новосибирск"
                        });
                });

            modelBuilder.Entity("CorporateOffers.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Annotation")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("CompanyUrl")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("DiscountSize")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.PrimitiveCollection<List<string>>("Links")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("OfferType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("offers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Annotation = "annotation",
                            CategoryId = 1,
                            CompanyUrl = "url",
                            Description = "description",
                            EndDate = new DateTime(2024, 12, 28, 8, 58, 27, 546, DateTimeKind.Utc).AddTicks(5071),
                            ImagePath = "",
                            Links = new List<string> { "link1", "link2" },
                            Name = "name",
                            OfferType = 0,
                            StartDate = new DateTime(2024, 12, 27, 8, 58, 27, 546, DateTimeKind.Utc).AddTicks(3764),
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            Annotation = "annotation2",
                            CategoryId = 1,
                            CompanyUrl = "url2",
                            Description = "description2",
                            DiscountSize = 10,
                            EndDate = new DateTime(2024, 12, 29, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1107),
                            ImagePath = "",
                            Links = new List<string>(),
                            Name = "name2",
                            OfferType = 1,
                            StartDate = new DateTime(2024, 12, 27, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1104),
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            Annotation = "annotation3",
                            CategoryId = 2,
                            Description = "description3",
                            DiscountSize = 10,
                            EndDate = new DateTime(2024, 12, 30, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1162),
                            ImagePath = "",
                            Links = new List<string> { "link3" },
                            OfferType = 1,
                            StartDate = new DateTime(2024, 12, 27, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1161),
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            Annotation = "annotation4",
                            CategoryId = 1,
                            CompanyUrl = "url4",
                            Description = "description4",
                            EndDate = new DateTime(2024, 12, 31, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1193),
                            ImagePath = "",
                            Links = new List<string> { "link" },
                            Name = "name4",
                            OfferType = 0,
                            StartDate = new DateTime(2024, 12, 28, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1190),
                            Status = 2
                        },
                        new
                        {
                            Id = 5,
                            Annotation = "annotation5",
                            CategoryId = 2,
                            CompanyUrl = "url5",
                            Description = "description5",
                            EndDate = new DateTime(2025, 1, 1, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1204),
                            ImagePath = "",
                            Links = new List<string> { "link" },
                            Name = "name5",
                            OfferType = 0,
                            StartDate = new DateTime(2024, 12, 29, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1202),
                            Status = 0
                        });
                });

            modelBuilder.Entity("CorporateOffers.Entities.TokenBlacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.ToTable("tokenBlacklist", (string)null);
                });

            modelBuilder.Entity("CorporateOffers.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("bytea");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "email@gmail.com",
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            Password = new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 },
                            Role = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "email",
                            FirstName = "Marina",
                            LastName = "Ivanova",
                            Password = new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 },
                            Role = 0
                        });
                });

            modelBuilder.Entity("CityOffer", b =>
                {
                    b.HasOne("CorporateOffers.Entities.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorporateOffers.Entities.Offer", null)
                        .WithMany()
                        .HasForeignKey("OffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorporateOffers.Entities.Offer", b =>
                {
                    b.HasOne("CorporateOffers.Entities.Category", "Category")
                        .WithMany("Offers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CorporateOffers.Entities.Category", b =>
                {
                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
