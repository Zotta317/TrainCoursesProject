using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class ChangingDbEntitiesCollumnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Train",
                newName: "TrainID");

            migrationBuilder.RenameColumn(
                name: "TrainID",
                table: "Ticket",
                newName: "TrainId");

            migrationBuilder.RenameColumn(
                name: "SeatID",
                table: "Ticket",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "PlatformID",
                table: "Ticket",
                newName: "PlatformId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Ticket",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CarrigeID",
                table: "Ticket",
                newName: "CarrigeId");

            migrationBuilder.RenameColumn(
                name: "LeavingDate",
                table: "Ticket",
                newName: "LeavingTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "Ticket",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "TrainID",
                table: "Seat",
                newName: "TrainId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Seat",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Seat",
                newName: "SeatID");

            migrationBuilder.RenameColumn(
                name: "TrainID",
                table: "Course",
                newName: "TrainId");

            migrationBuilder.RenameColumn(
                name: "PlatformID",
                table: "Course",
                newName: "PlatformId");

            migrationBuilder.RenameColumn(
                name: "LeavingDate",
                table: "Course",
                newName: "LeavingTime");

            migrationBuilder.RenameColumn(
                name: "ArivingDate",
                table: "Course",
                newName: "ArivingTime");

            migrationBuilder.RenameColumn(
                name: "TrainID",
                table: "Carrige",
                newName: "TrainId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Carrige",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CarrigeId",
                table: "Carrige",
                newName: "CarrigeID");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainID",
                table: "Train",
                newName: "TrainId");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Ticket",
                newName: "TrainID");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Ticket",
                newName: "SeatID");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Ticket",
                newName: "PlatformID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Ticket",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "CarrigeId",
                table: "Ticket",
                newName: "CarrigeID");

            migrationBuilder.RenameColumn(
                name: "LeavingTime",
                table: "Ticket",
                newName: "LeavingDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Ticket",
                newName: "ArrivalDate");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Seat",
                newName: "TrainID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Seat",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "SeatID",
                table: "Seat",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Course",
                newName: "TrainID");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "Course",
                newName: "PlatformID");

            migrationBuilder.RenameColumn(
                name: "LeavingTime",
                table: "Course",
                newName: "LeavingDate");

            migrationBuilder.RenameColumn(
                name: "ArivingTime",
                table: "Course",
                newName: "ArivingDate");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "Carrige",
                newName: "TrainID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Carrige",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "CarrigeID",
                table: "Carrige",
                newName: "CarrigeId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
