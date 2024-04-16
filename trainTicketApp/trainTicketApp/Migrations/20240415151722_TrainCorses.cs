using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class TrainCorses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "booked",
                table: "TrainCourses",
                newName: "Booked");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainId",
                table: "Seat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "Booked",
                table: "TrainCourses",
                newName: "booked");
        }
    }
}
