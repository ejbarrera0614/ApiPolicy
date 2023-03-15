using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurancePoliciesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coverage",
                columns: new[] { "ID", "Name", "Description" },
                values: new object[,]
                {
                    { 1, "choque", "resguardo contra daños con otro vehículo" },
                    { 2, "accidente", "resguardo contra accidente" },
                    { 3, "robo", "resguardo contra hurto" },
                    { 4, "lavado", "lavados mensuales en cadena de lava autos" },
                    { 5, "grúa", "servicio de grúa" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "Name", "BirthDate", "City", "DocumentIdentity", "Address" },
                values: new Object[,] {
                    { 1, "Julian", DateTime.Parse("2003-09-01"), "Armenia", "12345", "Torre 2 1204" },
                    { 2, "Julian 2", DateTime.Parse("2003-09-02"), "Armenia 2", "12346", "Torre 3 1304" }
                });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "ID", "Name", "PolicyNumber", "MaxCoverage", "DateInit", "DateEnd" },
                values: new Object[,] {
                    { 1,"Póliza Heavy", "33F", 10000, DateTime.Parse("2023-02-01"), DateTime.Parse("2023-04-04") },
                    { 2,"Póliza Full", "44F", 40000, DateTime.Parse("2023-01-01"), DateTime.Parse("2023-03-04") },
                    { 3,"Póliza Soft", "44G", 4000, DateTime.Parse("2023-01-01"), DateTime.Parse("2023-06-04") }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "ID", "NumberPlate", "CustomerID", "HaveItInspection", "Model" },
                values: new Object[,] {
                    { 1, "TTE 24H", 1, false, 2022 },
                    { 2, "TTE 25H", 1, true, 2012 },
                    { 3, "TTE 26H", 2, false, 2002 }
                });

            migrationBuilder.InsertData(
                table: "PolicyVehicle",
                columns: new[] { "ID", "VehicleID", "PolicyID", "DateGot" },
                values: new Object[,] {
                    { 1, 1, 1, DateTime.Parse("2023-02-02") },
                    { 2, 1, 2, DateTime.Parse("2023-02-02") },
                    { 3, 2, 1, DateTime.Parse("2023-01-02") }
                });

            migrationBuilder.InsertData(
                table: "PolicyCoverage",
                columns: new[] { "ID", "PolicyID", "CoverageID" },
                values: new Object[,] {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 1, 5 },
                    { 4, 2, 2 },
                    { 5, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coverage",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4, 5 }); ;

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Policy",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "PolicyVehicle",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "PolicyCoverage",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3, 4, 5 }); ;
        }
    }
}
