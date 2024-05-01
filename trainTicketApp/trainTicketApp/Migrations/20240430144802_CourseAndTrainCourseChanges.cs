using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class CourseAndTrainCourseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "AvailableDate",
                table: "TrainCourses",
                newName: "LeavingDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArrivingCity",
                table: "TrainCourses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivingDate",
                table: "TrainCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AvaillableSeats",
                table: "TrainCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Leavingcity",
                table: "TrainCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "LeavingCity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ArrivingCity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivingDate",
                table: "TrainCourses");

            migrationBuilder.DropColumn(
                name: "AvaillableSeats",
                table: "TrainCourses");

            migrationBuilder.DropColumn(
                name: "Leavingcity",
                table: "TrainCourses");

            migrationBuilder.RenameColumn(
                name: "LeavingDate",
                table: "TrainCourses",
                newName: "AvailableDate");

            migrationBuilder.AlterColumn<string>(
                name: "ArrivingCity",
                table: "TrainCourses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeavingCity",
                table: "Course",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArrivingCity",
                table: "Course",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainId",
                table: "Course",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
