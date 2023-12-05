using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThump.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Sansevieria plants are characterized by their long, upright, and sword-shaped leaves", "Sansevieria" },
                    { 2, "commonly known as peace lilies, is a genus of flowering plants in the family Araceae. ", "Spathiphyllum" },
                    { 3, "is a popular and hardy indoor plant known for its tolerance of low light conditions", "Zamioculcas" }
                });

            migrationBuilder.InsertData(
                table: "instructions",
                columns: new[] { "id", "instructions", "plant_id" },
                values: new object[,]
                {
                    { 1, "Let soil dry.", 1 },
                    { 2, "Avoid overwatering.", 1 },
                    { 3, "Keep soil moist.", 2 },
                    { 4, "Water when top dry.", 2 },
                    { 5, " Let soil dry then water.", 3 },
                    { 6, "Water sparingly.", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_instructions_plant_id",
                table: "instructions",
                column: "plant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instructions");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
