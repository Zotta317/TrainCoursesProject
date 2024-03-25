using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class LostSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "SeatId", "Booked", "CarrigeId", "CourseID", "SeatName", "TrainID" },
                values: new object[,]
                {
                    { new Guid("24caf5d7-e2db-44b1-b145-e2eab29a22a3"), false, new Guid("389e75ce-284b-49bb-b093-688fb1983465"), new Guid("00000000-0000-0000-0000-000000000000"), "B13", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("b53a0c7d-1405-4a68-a6a6-a9cf7af6a3a7"), false, new Guid("389e75ce-284b-49bb-b093-688fb1983465"), new Guid("00000000-0000-0000-0000-000000000000"), "B15", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("c5a40b9a-5d93-4223-95cf-0090bd3bd0fb"), false, new Guid("389e75ce-284b-49bb-b093-688fb1983465"), new Guid("00000000-0000-0000-0000-000000000000"), "B16", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") },
                    { new Guid("e71f128b-5aa1-49b3-af04-618808d0a6af"), false, new Guid("389e75ce-284b-49bb-b093-688fb1983465"), new Guid("00000000-0000-0000-0000-000000000000"), "B14", new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("24caf5d7-e2db-44b1-b145-e2eab29a22a3"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("b53a0c7d-1405-4a68-a6a6-a9cf7af6a3a7"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("c5a40b9a-5d93-4223-95cf-0090bd3bd0fb"));

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("e71f128b-5aa1-49b3-af04-618808d0a6af"));
        }
    }
}
