﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trainTicketApp.Data;

#nullable disable

namespace trainTicketApp.Migrations
{
    [DbContext(typeof(TraintDataApi.TrainDbContext))]
    partial class TrainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("trainTicketApp.Model.Carrige", b =>
                {
                    b.Property<Guid>("CarrigeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarrigeID");

                    b.ToTable("Carrige");

                    b.HasData(
                        new
                        {
                            CarrigeID = new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"),
                            AvailableSeats = 3,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "AA1",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"),
                            AvailableSeats = 3,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "AA2",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("0bfdf344-31ff-4e75-a389-70315c001833"),
                            AvailableSeats = 3,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "AA3",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"),
                            AvailableSeats = 4,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "BB1",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"),
                            AvailableSeats = 4,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "BB2",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("7bf45095-fba6-47b7-b380-996233626448"),
                            AvailableSeats = 4,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "BB3",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("389e75ce-284b-49bb-b093-688fb1983465"),
                            AvailableSeats = 4,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "BB4",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            CarrigeID = new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"),
                            AvailableSeats = 3,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "CC1",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            CarrigeID = new Guid("993a0e29-9326-402f-9134-cd153e3df275"),
                            AvailableSeats = 3,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "CC2",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            CarrigeID = new Guid("33a987e8-5767-486a-92ba-d0269009763e"),
                            AvailableSeats = 2,
                            CourseId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "CC3",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        });
                });

            modelBuilder.Entity("trainTicketApp.Model.Course", b =>
                {
                    b.Property<Guid>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArivingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArrivingCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeavingCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LeavingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfSeatsAvailable")
                        .HasColumnType("int");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("trainTicketApp.Model.Profile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("trainTicketApp.Model.Seat", b =>
                {
                    b.Property<Guid>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrigeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SeatID");

                    b.ToTable("Seat");

                    b.HasData(
                        new
                        {
                            SeatID = new Guid("525cf6a0-644e-33cb-bc08-e12c5266b8a7"),
                            CarrigeId = new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"),
                            SeatName = "A1",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("813a3db7-f01a-4482-914a-bce5a4d638bb"),
                            CarrigeId = new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"),
                            SeatName = "A2",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("002be73c-0c94-4f61-9776-3350e27453c8"),
                            CarrigeId = new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"),
                            SeatName = "A3",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("43165ed7-4812-4659-8901-0f6f70cd5856"),
                            CarrigeId = new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"),
                            SeatName = "A4",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("17d3dd2e-63f1-47dd-9e59-f3e489894954"),
                            CarrigeId = new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"),
                            SeatName = "A5",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("88fb29e9-53ad-490f-bf06-66bf0e7e9a19"),
                            CarrigeId = new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"),
                            SeatName = "A6",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("6dbe5a17-dd43-4299-bd09-0f89b40326d0"),
                            CarrigeId = new Guid("0bfdf344-31ff-4e75-a389-70315c001833"),
                            SeatName = "A7",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("ad9aa746-05df-40d4-8880-677d4f026b81"),
                            CarrigeId = new Guid("0bfdf344-31ff-4e75-a389-70315c001833"),
                            SeatName = "A8",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("9d0f9f2f-3840-4329-93ce-693329bb0bc1"),
                            CarrigeId = new Guid("0bfdf344-31ff-4e75-a389-70315c001833"),
                            SeatName = "A9",
                            TrainId = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5")
                        },
                        new
                        {
                            SeatID = new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"),
                            CarrigeId = new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"),
                            SeatName = "B1",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("0b882cd9-c7f6-4e46-853f-05e966d644ba"),
                            CarrigeId = new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"),
                            SeatName = "B2",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("554321fc-9d5c-47f6-9f79-b3fa70cf08ea"),
                            CarrigeId = new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"),
                            SeatName = "B3",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("daa7eb6d-6e8e-4ae7-a342-2884861275d0"),
                            CarrigeId = new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"),
                            SeatName = "B4",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("cdb585b4-55ba-4aea-b5a5-9a47d8ef68f7"),
                            CarrigeId = new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"),
                            SeatName = "B5",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("b51224ff-b75c-4e04-9a12-0e8bf96a43d5"),
                            CarrigeId = new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"),
                            SeatName = "B6",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("b2e10c30-8e6c-40fd-89a7-9627bf5fe541"),
                            CarrigeId = new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"),
                            SeatName = "B7",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("7bee3ef2-6033-4e25-89bf-fdc8e9494e2c"),
                            CarrigeId = new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"),
                            SeatName = "B8",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("eed81cd4-5958-4872-8e0a-da1ca0ac368a"),
                            CarrigeId = new Guid("7bf45095-fba6-47b7-b380-996233626448"),
                            SeatName = "B9",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("d9ebadde-29e9-4121-aa55-d22817c601e9"),
                            CarrigeId = new Guid("7bf45095-fba6-47b7-b380-996233626448"),
                            SeatName = "B10",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("a9d3b0d4-2594-4949-acae-b542413600aa"),
                            CarrigeId = new Guid("7bf45095-fba6-47b7-b380-996233626448"),
                            SeatName = "B11",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("4bc6fa95-7b90-44fb-a758-696176db4109"),
                            CarrigeId = new Guid("7bf45095-fba6-47b7-b380-996233626448"),
                            SeatName = "B12",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("24caf5d7-e2db-44b1-b145-e2eab29a22a3"),
                            CarrigeId = new Guid("389e75ce-284b-49bb-b093-688fb1983465"),
                            SeatName = "B13",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("e71f128b-5aa1-49b3-af04-618808d0a6af"),
                            CarrigeId = new Guid("389e75ce-284b-49bb-b093-688fb1983465"),
                            SeatName = "B14",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("b53a0c7d-1405-4a68-a6a6-a9cf7af6a3a7"),
                            CarrigeId = new Guid("389e75ce-284b-49bb-b093-688fb1983465"),
                            SeatName = "B15",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("c5a40b9a-5d93-4223-95cf-0090bd3bd0fb"),
                            CarrigeId = new Guid("389e75ce-284b-49bb-b093-688fb1983465"),
                            SeatName = "B16",
                            TrainId = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5")
                        },
                        new
                        {
                            SeatID = new Guid("ff6370b6-c194-4acc-8ef9-70339fb5fa13"),
                            CarrigeId = new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"),
                            SeatName = "C1",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("7915717f-20a2-4f03-ac6c-21d3cd326a04"),
                            CarrigeId = new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"),
                            SeatName = "C2",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("454333dd-d175-47dc-acb1-9312f6e7376a"),
                            CarrigeId = new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"),
                            SeatName = "C3",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("520de61f-dc9e-4747-8b1c-42aa70979bff"),
                            CarrigeId = new Guid("993a0e29-9326-402f-9134-cd153e3df275"),
                            SeatName = "C4",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("9a4b7f11-6e29-4ed2-939c-b5c44c47ce33"),
                            CarrigeId = new Guid("993a0e29-9326-402f-9134-cd153e3df275"),
                            SeatName = "C5",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("2c922ec6-c82a-4fd5-afd1-e379e7b63b80"),
                            CarrigeId = new Guid("993a0e29-9326-402f-9134-cd153e3df275"),
                            SeatName = "C6",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("afc39e45-e4d6-4666-9159-1494c1a18a39"),
                            CarrigeId = new Guid("33a987e8-5767-486a-92ba-d0269009763e"),
                            SeatName = "C7",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        },
                        new
                        {
                            SeatID = new Guid("1b155670-a5ab-44cd-a2a0-bf265453e663"),
                            CarrigeId = new Guid("33a987e8-5767-486a-92ba-d0269009763e"),
                            SeatName = "C8",
                            TrainId = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8")
                        });
                });

            modelBuilder.Entity("trainTicketApp.Model.Ticket", b =>
                {
                    b.Property<Guid>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TicketID");

                    b.HasIndex("ProfileId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("trainTicketApp.Model.Train", b =>
                {
                    b.Property<Guid>("TrainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainType")
                        .HasColumnType("int");

                    b.HasKey("TrainID");

                    b.ToTable("Train");

                    b.HasData(
                        new
                        {
                            TrainID = new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5"),
                            NumberOfSeats = 9,
                            TrainName = "Model X",
                            TrainType = 0
                        },
                        new
                        {
                            TrainID = new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5"),
                            NumberOfSeats = 16,
                            TrainName = "Model Y",
                            TrainType = 0
                        },
                        new
                        {
                            TrainID = new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8"),
                            NumberOfSeats = 8,
                            TrainName = "Model Z",
                            TrainType = 0
                        });
                });

            modelBuilder.Entity("trainTicketApp.Model.TrainCourse", b =>
                {
                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.HasKey("SeatId", "CourseId");

                    b.ToTable("TrainCourses");
                });

            modelBuilder.Entity("trainTicketApp.Model.TrainPlatforms", b =>
                {
                    b.Property<Guid>("PlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformID");

                    b.ToTable("TrainPlatforms");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("trainTicketApp.Model.Ticket", b =>
                {
                    b.HasOne("trainTicketApp.Model.Profile", null)
                        .WithMany("Tickets")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("trainTicketApp.Model.Profile", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
