using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThump.Migrations
{
    /// <inheritdoc />
    public partial class initial_seeda : Migration
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Sansevieria" },
                    { 2, "Spathiphyllum" },
                    { 3, "Zamioculcas" }
                });

            migrationBuilder.InsertData(
                table: "instructions",
                columns: new[] { "id", "instructions", "plant_id" },
                values: new object[,]
                {
                    { 1, "Allow soil to dry between waterings, avoid overwatering.", 1 },
                    { 2, "Keep soil consistently moist but not soggy; water when the top inch of soil feels dry.", 2 },
                    { 3, " Allow the soil to dry out between waterings; water sparingly.", 3 }
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
