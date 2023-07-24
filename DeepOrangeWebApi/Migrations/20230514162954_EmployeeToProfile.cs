using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepOrangeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeToProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTechnologies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "TechnologyId",
                keyValue: 1);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "DirectionId",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTechnologies",
                columns: table => new
                {
                    ProfilesProfileId = table.Column<int>(type: "integer", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTechnologies", x => new { x.ProfilesProfileId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_ProfileTechnologies_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileTechnologies_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTechnologies_TechnologiesTechnologyId",
                table: "ProfileTechnologies",
                column: "TechnologiesTechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileTechnologies");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTechnologies",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "integer", nullable: false),
                    TechnologiesTechnologyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTechnologies", x => new { x.EmployeesEmployeeId, x.TechnologiesTechnologyId });
                    table.ForeignKey(
                        name: "FK_EmployeeTechnologies_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTechnologies_Technologies_TechnologiesTechnologyId",
                        column: x => x.TechnologiesTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "DirectionId", "DirectionName" },
                values: new object[,]
                {
                    { 1, "PHP" },
                    { 2, "Python" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "LastName", "Name" },
                values: new object[] { 1, "Honcharov", "Mykyta" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "DirectionId", "TechnologyName" },
                values: new object[,]
                {
                    { 1, 1, "Magento" },
                    { 2, 2, "Flask" },
                    { 3, 2, "NumPy" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTechnologies",
                columns: new[] { "EmployeesEmployeeId", "TechnologiesTechnologyId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTechnologies_TechnologiesTechnologyId",
                table: "EmployeeTechnologies",
                column: "TechnologiesTechnologyId");
        }
    }
}
