using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class TrainCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booked",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Seat");

            migrationBuilder.CreateTable(
                name: "TrainCourses",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    booked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainCourses");

            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "Seat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Seat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TrainId",
                table: "Seat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
