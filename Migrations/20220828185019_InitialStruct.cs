using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanhiaAerea.Migrations
{
    public partial class InitialStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarriedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaintenanceType = table.Column<int>(type: "int", nullable: false),
                    AirlaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Airplanes_AirlaneId",
                        column: x => x.AirlaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flyings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Destiny = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DepartureTimeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTimeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    PilotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flyings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flyings_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flyings_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateTimeNotification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlyingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cancellations_Flyings_FlyingId",
                        column: x => x.FlyingId,
                        principalTable: "Flyings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_FlyingId",
                table: "Cancellations",
                column: "FlyingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flyings_AirplaneId",
                table: "Flyings",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flyings_PilotId",
                table: "Flyings",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_AirlaneId",
                table: "Maintenances",
                column: "AirlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_Registration",
                table: "Pilots",
                column: "Registration",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancellations");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "Flyings");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
