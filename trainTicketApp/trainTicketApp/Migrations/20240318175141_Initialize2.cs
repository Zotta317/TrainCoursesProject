using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class Initialize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"),
                column: "TrainID",
                value: new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Seat",
                keyColumn: "SeatId",
                keyValue: new Guid("ea803373-4bd7-4f6d-9511-0c2ca0e2239f"),
                column: "TrainID",
                value: new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5"));
        }
    }
}
