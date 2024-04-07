using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trainTicketApp.Migrations
{
    public partial class RemakePlatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "TrainPlatforms",
                columns: table => new
                {
                    PlatformID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainPlatforms", x => x.PlatformID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainPlatforms");

            migrationBuilder.CreateTable(
                name: "TrainPlatform",
                columns: table => new
                {
                    PlatformID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainPlatform", x => x.PlatformID);
                });
        }
    }
}
