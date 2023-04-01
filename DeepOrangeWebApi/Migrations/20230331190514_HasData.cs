using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepOrangeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class HasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "DirectionId", "DirectionName" },
                values: new object[] { 1, ".NET" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "LastName", "Name" },
                values: new object[] { 1, "Honcharov", "Mykyta" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "DirectionId", "TechnologyName" },
                values: new object[] { 1, 1, "ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "EmployeeTechnologies",
                columns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeTechnologies",
                keyColumns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "DirectionId",
                keyValue: 1);
        }
    }
}
