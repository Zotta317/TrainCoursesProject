using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class TicketUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ArrivingCity",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CarrigeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LeavingCity",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LeavingTime",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProfileId",
                table: "Ticket",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_ProfileId",
                table: "Ticket",
                column: "ProfileId",
                principalTable: "User",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_ProfileId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ProfileId",
                table: "Ticket");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ArrivingCity",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarrigeId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "LeavingCity",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingTime",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PlatformId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
