using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class SeatsPRoblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableTrainSeats",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Train");

            migrationBuilder.RenameColumn(
                name: "RemainingSeats",
                table: "Train",
                newName: "NumberOfSeats");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeatsAvailable",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5"),
                column: "NumberOfSeats",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5"),
                column: "NumberOfSeats",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8"),
                column: "NumberOfSeats",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeatsAvailable",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "NumberOfSeats",
                table: "Train",
                newName: "RemainingSeats");

            migrationBuilder.AddColumn<int>(
                name: "AvailableTrainSeats",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseID",
                table: "Train",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("006e9d56-99d2-43f2-a231-db7197cdf6d5"),
                columns: new[] { "AvailableTrainSeats", "RemainingSeats" },
                values: new object[] { 16, 0 });

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("21e9557f-99d2-40b2-b0e1-2bcf97b226d5"),
                columns: new[] { "AvailableTrainSeats", "CourseID", "RemainingSeats" },
                values: new object[] { 9, new Guid("e46e9067-da5d-4b27-8608-8cb757c57197"), 0 });

            migrationBuilder.UpdateData(
                table: "Train",
                keyColumn: "TrainId",
                keyValue: new Guid("d5fc5911-b45e-4134-acc0-8a35531faee8"),
                columns: new[] { "AvailableTrainSeats", "RemainingSeats" },
                values: new object[] { 8, 0 });
        }
    }
}
