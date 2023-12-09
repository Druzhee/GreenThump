using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb.Migrations
{
    /// <inheritdoc />
    public partial class initialandseed : Migration
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
                    { 1, "Known for its beautiful and fragrant flowers.", "Rose" },
                    { 2, "Known for its large, yellow flowers.", "Sunflower" },
                    { 3, " A fragrant herb with purple flowers.", "Lavender " },
                    { 4, "known as Mother in law's Tongue.", "Snake Plant " },
                    { 5, "These deciduous trees are well-known for their distinctive.", "Maple Tree" },
                    { 6, "A bulbous plant with vibrant, cup-shaped flowers.", "Tulip" },
                    { 7, "A fast-growing grass that forms tall, woody stems.", "Bamboo" },
                    { 8, "Adapted to arid environments, cacti are known for their water-storing capabilities and unique.", "Cactus " }
                });

            migrationBuilder.InsertData(
                table: "instructions",
                columns: new[] { "id", "instructions", "plant_id" },
                values: new object[,]
                {
                    { 1, "Well-drained soil.", 1 },
                    { 2, "Sunlight.", 1 },
                    { 3, "Keep soil moist.", 2 },
                    { 4, "Shade.", 2 },
                    { 5, "Full sun.", 3 },
                    { 6, "Regular water.", 3 },
                    { 7, " Full sun", 4 },
                    { 8, "Well-drained soil.", 4 },
                    { 9, "Low light.", 5 },
                    { 10, "Infrequent water", 5 },
                    { 11, "Full Sun", 6 },
                    { 12, "Acidic soil.", 6 },
                    { 13, "Full Sun.", 7 },
                    { 14, "Sparse water.", 7 },
                    { 15, "Full Sun.", 8 },
                    { 16, "Minimal Water.", 8 }
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
