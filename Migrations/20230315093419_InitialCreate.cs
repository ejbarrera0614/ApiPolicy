using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurancePoliciesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIdentity = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaxCoverage = table.Column<int>(type: "int", nullable: false),
                    DateInit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Model = table.Column<int>(type: "int", nullable: false),
                    HaveItInspection = table.Column<bool>(type: "bit", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoveragePolicy",
                columns: table => new
                {
                    CoveragesID = table.Column<int>(type: "int", nullable: false),
                    PoliciesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePolicy", x => new { x.CoveragesID, x.PoliciesID });
                    table.ForeignKey(
                        name: "FK_CoveragePolicy_Coverage_CoveragesID",
                        column: x => x.CoveragesID,
                        principalTable: "Coverage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoveragePolicy_Policy_PoliciesID",
                        column: x => x.PoliciesID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicy",
                columns: table => new
                {
                    CustomersID = table.Column<int>(type: "int", nullable: false),
                    PoliciesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicy", x => new { x.CustomersID, x.PoliciesID });
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Customer_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPolicy_Policy_PoliciesID",
                        column: x => x.PoliciesID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyCoverage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyID = table.Column<int>(type: "int", nullable: false),
                    CoverageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCoverage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PolicyCoverage_Coverage_CoverageID",
                        column: x => x.CoverageID,
                        principalTable: "Coverage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyCoverage_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyVehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    PolicyID = table.Column<int>(type: "int", nullable: false),
                    DateGot = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyVehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PolicyVehicle_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyVehicle_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoveragePolicy_PoliciesID",
                table: "CoveragePolicy",
                column: "PoliciesID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DocumentIdentity",
                table: "Customer",
                column: "DocumentIdentity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicy_PoliciesID",
                table: "CustomerPolicy",
                column: "PoliciesID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyNumber",
                table: "Policy",
                column: "PolicyNumber",
                unique: true,
                filter: "[PolicyNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCoverage_CoverageID",
                table: "PolicyCoverage",
                column: "CoverageID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCoverage_PolicyID",
                table: "PolicyCoverage",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyVehicle_PolicyID",
                table: "PolicyVehicle",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyVehicle_VehicleID",
                table: "PolicyVehicle",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CustomerID",
                table: "Vehicle",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_NumberPlate",
                table: "Vehicle",
                column: "NumberPlate",
                unique: true,
                filter: "[NumberPlate] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoveragePolicy");

            migrationBuilder.DropTable(
                name: "CustomerPolicy");

            migrationBuilder.DropTable(
                name: "PolicyCoverage");

            migrationBuilder.DropTable(
                name: "PolicyVehicle");

            migrationBuilder.DropTable(
                name: "Coverage");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
