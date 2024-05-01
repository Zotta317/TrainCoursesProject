using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainCourses",
                table: "TrainCourses");

            migrationBuilder.DropColumn(
                name: "Booked",
                table: "TrainCourses");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "TrainCourses",
                newName: "TrainId");

            migrationBuilder.AddColumn<string>(
                name: "ArrivingCity",
                table: "TrainCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableDate",
                table: "TrainCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainCourses",
                table: "TrainCourses",
                columns: new[] { "CourseId", "TrainId" });

            migrationBuilder.CreateTable(
                name: "CourseSeats",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSeats", x => new { x.SeatId, x.CourseId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainCourses",
                table: "TrainCourses");

            migrationBuilder.DropColumn(
                name: "ArrivingCity",
                table: "TrainCourses");

            migrationBuilder.DropColumn(
                name: "AvailableDate",
                table: "TrainCourses");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "TrainCourses",
                newName: "SeatId");

            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "TrainCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainCourses",
                table: "TrainCourses",
                columns: new[] { "SeatId", "CourseId" });

            migrationBuilder.CreateTable(
                name: "TrainCourse",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivingCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainCourse", x => new { x.CourseId, x.TrainId });
                });
        }
    }
}
