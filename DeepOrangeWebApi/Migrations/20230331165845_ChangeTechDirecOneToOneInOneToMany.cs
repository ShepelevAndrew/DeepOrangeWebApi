using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepOrangeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTechDirecOneToOneInOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Technologies_TechnologyId",
                table: "Directions");

            migrationBuilder.DropIndex(
                name: "IX_Directions_TechnologyId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Directions");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_DirectionId",
                table: "Technologies",
                column: "DirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Directions_DirectionId",
                table: "Technologies",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "DirectionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Directions_DirectionId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_DirectionId",
                table: "Technologies");

            migrationBuilder.AddColumn<int>(
                name: "TechnologyId",
                table: "Directions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Directions_TechnologyId",
                table: "Directions",
                column: "TechnologyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_Technologies_TechnologyId",
                table: "Directions",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
