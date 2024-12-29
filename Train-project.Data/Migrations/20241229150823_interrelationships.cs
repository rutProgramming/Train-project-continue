using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Train_project.Data.Migrations
{
    public partial class interrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    EmployedFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeCode);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationGPSCoordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StationType = table.Column<int>(type: "int", nullable: false),
                    NumberOfPlatforms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainLine = table.Column<int>(type: "int", nullable: false),
                    NumberOfCars = table.Column<int>(type: "int", nullable: false),
                    TrainStatus = table.Column<bool>(type: "bit", nullable: true),
                    RegularRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.TrainID);
                });

            migrationBuilder.CreateTable(
                name: "PublicInquiry",
                columns: table => new
                {
                    InquiryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionInquiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusInquiry = table.Column<bool>(type: "bit", nullable: true),
                    TreatedBy = table.Column<int>(type: "int", nullable: true),
                    ComplainantsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainantsPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicInquiry", x => x.InquiryId);
                    table.ForeignKey(
                        name: "FK_PublicInquiry_Employee_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PublicInquiry_Employee_TreatedBy",
                        column: x => x.TreatedBy,
                        principalTable: "Employee",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TrainRoute",
                columns: table => new
                {
                    TrainRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    TrainId = table.Column<int>(type: "int", nullable: true),
                    StationId = table.Column<int>(type: "int", nullable: true),
                    FirstTrain = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastTrain = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubstituteDriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainRoute", x => x.TrainRouteId);
                    table.ForeignKey(
                        name: "FK_TrainRoute_Employee_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrainRoute_Employee_SubstituteDriverId",
                        column: x => x.SubstituteDriverId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrainRoute_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "StationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainRoute_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "TrainID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicInquiry_DriverId",
                table: "PublicInquiry",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicInquiry_TreatedBy",
                table: "PublicInquiry",
                column: "TreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoute_DriverId",
                table: "TrainRoute",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoute_StationId",
                table: "TrainRoute",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoute_SubstituteDriverId",
                table: "TrainRoute",
                column: "SubstituteDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainRoute_TrainId",
                table: "TrainRoute",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicInquiry");

            migrationBuilder.DropTable(
                name: "TrainRoute");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
