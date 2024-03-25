using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrige",
                columns: table => new
                {
                    CarrigeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrige", x => x.CarrigeId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivingCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeavingCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    PlatformID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.PlatformID);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrigeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarrigeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeavingCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivingCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainType = table.Column<int>(type: "int", nullable: false),
                    AvailableTrainSeats = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.TrainId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carrige",
                columns: new[] { "CarrigeId", "AvailableSeats", "CourseID", "Name", "TrainID" },
                values: new object[,]
                {
                    { new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "AA3", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), 4, new Guid("00000000-0000-0000-0000-000000000000"), "BB1", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("33a987e8-5767-486a-92ba-d0269009763e"), 2, new Guid("00000000-0000-0000-0000-000000000000"), "CC3", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("389e75ce-284b-49bb-b093-688fb1983465"), 4, new Guid("00000000-0000-0000-0000-000000000000"), "BB4", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "AA1", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "AA2", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("7bf45095-fba6-47b7-b380-996233626448"), 4, new Guid("00000000-0000-0000-0000-000000000000"), "BB3", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("993a0e29-9326-402f-9134-cd153e3df275"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "CC2", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "CC1", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), 4, new Guid("00000000-0000-0000-0000-000000000000"), "BB2", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "SeatId", "Booked", "CarrigeId", "CourseID", "SeatName", "TrainID" },
                values: new object[,]
                {
                    { new Guid("002be73c-0c94-4f61-9776-3350e27453c8"), false, new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), new Guid("00000000-0000-0000-0000-000000000000"), "A3", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("0b882cd9-c7f6-4e46-853f-05e966d644ba"), false, new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), new Guid("00000000-0000-0000-0000-000000000000"), "B2", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("17d3dd2e-63f1-47dd-9e59-f3e489894954"), false, new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), new Guid("00000000-0000-0000-0000-000000000000"), "A5", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("1b155670-a5ab-44cd-a2a0-bf265453e663"), false, new Guid("33a987e8-5767-486a-92ba-d0269009763e"), new Guid("00000000-0000-0000-0000-000000000000"), "C8", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("2c922ec6-c82a-4fd5-afd1-e379e7b63b80"), false, new Guid("993a0e29-9326-402f-9134-cd153e3df275"), new Guid("00000000-0000-0000-0000-000000000000"), "C6", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("43165ed7-4812-4659-8901-0f6f70cd5856"), false, new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), new Guid("00000000-0000-0000-0000-000000000000"), "A4", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("454333dd-d175-47dc-acb1-9312f6e7376a"), false, new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), new Guid("00000000-0000-0000-0000-000000000000"), "C3", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("4bc6fa95-7b90-44fb-a758-696176db4109"), false, new Guid("7bf45095-fba6-47b7-b380-996233626448"), new Guid("00000000-0000-0000-0000-000000000000"), "B12", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("520de61f-dc9e-4747-8b1c-42aa70979bff"), false, new Guid("993a0e29-9326-402f-9134-cd153e3df275"), new Guid("00000000-0000-0000-0000-000000000000"), "C4", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("525cf6a0-644e-33cb-bc08-e12c5266b8a7"), false, new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), new Guid("00000000-0000-0000-0000-000000000000"), "A1", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("554321fc-9d5c-47f6-9f79-b3fa70cf08ea"), false, new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), new Guid("00000000-0000-0000-0000-000000000000"), "B3", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("6dbe5a17-dd43-4299-bd09-0f89b40326d0"), false, new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), new Guid("00000000-0000-0000-0000-000000000000"), "A7", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("7915717f-20a2-4f03-ac6c-21d3cd326a04"), false, new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), new Guid("00000000-0000-0000-0000-000000000000"), "C2", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("7bee3ef2-6033-4e25-89bf-fdc8e9494e2c"), false, new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), new Guid("00000000-0000-0000-0000-000000000000"), "B8", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("813a3db7-f01a-4482-914a-bce5a4d638bb"), false, new Guid("525ce5a0-644e-49cb-bc08-e12c5266b8a7"), new Guid("00000000-0000-0000-0000-000000000000"), "A2", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("88fb29e9-53ad-490f-bf06-66bf0e7e9a19"), false, new Guid("6aa81f80-1a04-47ab-ac46-150b893526a8"), new Guid("00000000-0000-0000-0000-000000000000"), "A6", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("9a4b7f11-6e29-4ed2-939c-b5c44c47ce33"), false, new Guid("993a0e29-9326-402f-9134-cd153e3df275"), new Guid("00000000-0000-0000-0000-000000000000"), "C5", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("9d0f9f2f-3840-4329-93ce-693329bb0bc1"), false, new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), new Guid("00000000-0000-0000-0000-000000000000"), "A9", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("a9d3b0d4-2594-4949-acae-b542413600aa"), false, new Guid("7bf45095-fba6-47b7-b380-996233626448"), new Guid("00000000-0000-0000-0000-000000000000"), "B11", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ad9aa746-05df-40d4-8880-677d4f026b81"), false, new Guid("0bfdf344-31ff-4e75-a389-70315c001833"), new Guid("00000000-0000-0000-0000-000000000000"), "A8", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("afc39e45-e4d6-4666-9159-1494c1a18a39"), false, new Guid("33a987e8-5767-486a-92ba-d0269009763e"), new Guid("00000000-0000-0000-0000-000000000000"), "C7", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") },
                    { new Guid("b2e10c30-8e6c-40fd-89a7-9627bf5fe541"), false, new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), new Guid("00000000-0000-0000-0000-000000000000"), "B7", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("b51224ff-b75c-4e04-9a12-0e8bf96a43d5"), false, new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), new Guid("00000000-0000-0000-0000-000000000000"), "B6", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("cdb585b4-55ba-4aea-b5a5-9a47d8ef68f7"), false, new Guid("fed20eac-3aa0-4a9f-a9b7-b5af494471d7"), new Guid("00000000-0000-0000-0000-000000000000"), "B5", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("d9ebadde-29e9-4121-aa55-d22817c601e9"), false, new Guid("7bf45095-fba6-47b7-b380-996233626448"), new Guid("00000000-0000-0000-0000-000000000000"), "B10", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("daa7eb6d-6e8e-4ae7-a342-2884861275d0"), false, new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), new Guid("00000000-0000-0000-0000-000000000000"), "B4", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"), false, new Guid("150f25f7-6e91-4880-b6db-c7b60ff6a801"), new Guid("00000000-0000-0000-0000-000000000000"), "B1", new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5") },
                    { new Guid("eed81cd4-5958-4872-8e0a-da1ca0ac368a"), false, new Guid("7bf45095-fba6-47b7-b380-996233626448"), new Guid("00000000-0000-0000-0000-000000000000"), "B9", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("ff6370b6-c194-4acc-8ef9-70339fb5fa13"), false, new Guid("e61c724e-942a-4b85-8e74-d165d64f01ee"), new Guid("00000000-0000-0000-0000-000000000000"), "C1", new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8") }
                });

            migrationBuilder.InsertData(
                table: "Train",
                columns: new[] { "TrainId", "AvailableTrainSeats", "CourseID", "TrainName", "TrainType" },
                values: new object[,]
                {
                    { new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5"), 16, new Guid("00000000-0000-0000-0000-000000000000"), "Model Y", 0 },
                    { new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5"), 9, new Guid("e46e9067-da5d-4b27-8608-8cb757c57197"), "Model X", 0 },
                    { new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8"), 8, new Guid("00000000-0000-0000-0000-000000000000"), "Model Z", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carrige");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
