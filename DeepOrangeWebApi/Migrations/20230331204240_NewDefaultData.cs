using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepOrangeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class NewDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Directions",
                keyColumn: "DirectionId",
                keyValue: 1,
                column: "DirectionName",
                value: "PHP");

            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "DirectionId", "DirectionName" },
                values: new object[] { 2, "Python" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1,
                column: "TechnologyName",
                value: "Magento");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "DirectionId", "TechnologyName" },
                values: new object[,]
                {
                    { 2, 2, "Flask" },
                    { 3, 2, "NumPy" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTechnologies",
                columns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeTechnologies",
                keyColumns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeTechnologies",
                keyColumns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "DirectionId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Directions",
                keyColumn: "DirectionId",
                keyValue: 1,
                column: "DirectionName",
                value: ".NET");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1,
                column: "TechnologyName",
                value: "ASP.NET Core");
        }
    }
}
